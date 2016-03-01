using System;
using System.Linq;
using Content.Services.HR.Messages;
using WTS.WorkSuite.HR.Framework.Models;
using WTS.WorkSuite.HR.HR.ReferenceData.Generic.Edit.Update;
using WTS.WorkSuite.HR.HR.ReferenceData.Generic.Events;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral.Events;
using WTS.WorkSuite.Library.DomainTypes.Primitives.Sanitisation;
using WTS.WorkSuite.Library.DomainTypes.Primitives.Validation;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.HR.ReferenceData.Generic.Edit
{

    /// <summary>
    ///     Standard implementation of an IUpdateReferenceData command. Validates 
    /// the request, loads the entity, if it does not exist it reports this as an error
    /// otherwise it updates entity and commits the changes.
    /// 
    /// </summary>
    /// <typeparam name="E">
    ///     The concrete reference data entity type, it must be a descendent of
    /// <see cref="ReferenceDataModel"></see>
    /// </typeparam>
    /// <typeparam name="P">
    ///     The create request type.
    /// </typeparam>
    /// <typeparam name="Q">
    ///     The response which must be a Response object with a response type that 
    /// is at descendent of the create request response.
    /// </typeparam>   
    /// <typeparam name="V">
    ///     The event published from this command.
    /// </typeparam>   
    public class UpdateReferenceData<E, P, Q, V>
                    : IUpdateReferenceData<P, Q>
        where E : ReferenceDataModel
        where P : UpdateReferenceDataRequest, new()
        where Q : UpdateReferenceDataResponse, new()
        where V : ReferenceDataUpdatedEvent, new()
    {


        public Q execute
                    (P the_request)
        {

            return this.set_request(the_request)
                       .sanatise_request()
                       .validate()
                       .load_entity()
                       .update()
                       .commit()
                       .publish_entity_updated_event()
                       .build_response()
                       ;
        }


        public UpdateReferenceData
                    (IUnitOfWork the_unit_of_work
                    , IEntityRepository<E> the_repository
                    , IEventPublisher<V> the_update_reference_data_event_publisher
                    , Validator the_validator)
        {

            unit_of_work = Guard.IsNotNull(the_unit_of_work, "the_unit_of_work");
            repository = Guard.IsNotNull(the_repository, "the_repository");
            validator = Guard.IsNotNull(the_validator, "the_validator");
            update_reference_data_event_publisher = Guard.IsNotNull(the_update_reference_data_event_publisher, "the_update_reference_data_event_publisher");
        }


        private UpdateReferenceData<E, P, Q, V> set_request
                                                (P the_request)
        {

            Guard.IsNotNull(the_request, "request");

            request = the_request;

            return this;
        }

        private UpdateReferenceData<E, P, Q, V> sanatise_request()
        {

            Guard.IsNotNull(request, "request");

            request = new P
            {
                id = request.id,
                description = request.description.normalise_for_persistence(),
                is_hidden = request.is_hidden,
            };

            return this;
        }

        private UpdateReferenceData<E, P, Q, V> validate()
        {

            if (response_builder.has_errors) return this;

            Guard.IsNotNull(request, "request");

            validator.field("description")
                     .is_madatory(request.description, ValidationMessages.error_01_0003)
                     .does_not_exceed_the_maximum_number_of_characters_for_a_text_field(request.description, ValidationMessages.error_01_0001)
                     .premise_holds(!repository
                                         .Entities
                                         .Any(e => e.description.Equals(request.description, StringComparison.InvariantCultureIgnoreCase) && e.id != request.id)
                                   , ValidationMessages.error_00_0018)
                     ;


            response_builder.add_errors(validator.errors);

            if (response_builder.has_errors)
            {
                response_builder.add_error(ValidationMessages.warning_03_0001);
            }

            return this;
        }

        private UpdateReferenceData<E, P, Q, V> load_entity()
        {

            if (response_builder.has_errors) return this;

            Guard.IsNotNull(request, "request");

            entity = repository
                      .Entities
                      .FirstOrDefault(e => e.id == request.id)
                      ;

            if (entity == null)
            {
                response_builder.add_error(ValidationMessages.reference_data_entry_not_found);
            }

            // to do: NOTE - The error handling needs to have some input
            //               from Tim as to what he wants to happen in the 
            //               front end in the event of this situation we 
            //               can then work out what the error message 
            //               should be.

            return this;
        }

        private UpdateReferenceData<E, P, Q, V> update()
        {

            if (response_builder.has_errors) return this;

            Guard.IsNotNull(entity, "entity");

            // to do: create a function to sanitise a string.  
            entity.description = request.description;
            entity.is_hidden = request.is_hidden;

            return this;
        }

        private UpdateReferenceData<E, P, Q, V> commit()
        {

            if (response_builder.has_errors) return this;

            Guard.IsNotNull(entity, "entity");

            unit_of_work.Commit();
            response_builder.add_message(ValidationMessages.update_was_successfull);

            return this;
        }

        private UpdateReferenceData<E, P, Q, V> publish_entity_updated_event()
        {

            if (response_builder.has_errors) return this;

            Guard.IsNotNull(entity, "entity");

            update_reference_data_event_publisher.publish(new V()
            {
                id = entity.id,
                description = entity.description
            });
            return this;
        }


        private Q build_response()
        {

            return response_builder.build();
        }


        private readonly IUnitOfWork unit_of_work;
        private readonly IEntityRepository<E> repository;
        private readonly IEventPublisher<V> update_reference_data_event_publisher;
        private readonly Validator validator;
        private readonly ResponseBuilder<Q> response_builder = new ResponseBuilder<Q>();

        private P request;
        private E entity;
    }
}