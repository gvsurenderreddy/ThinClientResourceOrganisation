using System;
using System.Linq;
using Content.Services.HR.Messages;
using WTS.WorkSuite.HR.Framework.Models;
using WTS.WorkSuite.Library.DomainTypes.DefaultValues;
using WTS.WorkSuite.Library.DomainTypes.Primitives.Sanitisation;
using WTS.WorkSuite.Library.DomainTypes.Primitives.Validation;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.HR.ReferenceData.Generic.New {

    /// <summary>
    ///     Standard implementation of an ICreateRefeenceData command. Validates 
    /// the description and then creates the new reference data entry.
    /// </summary>
    /// <typeparam name="P">
    ///     The create request type.
    /// </typeparam>
    /// <typeparam name="Q">
    ///     The response which must be a Response object with a response type that 
    /// is at descendent of the create request response.
    /// </typeparam>
    /// <typeparam name="E">
    ///     The concrete reference data entity type, it must be a descendent of
    /// <see cref="ReferenceDataModel"></see>
    /// </typeparam>
    public abstract class CreateReferenceData<E,P,Q> : ICreateReferenceData<P,Q> 
                    where E : ReferenceDataModel, new( ) 
                    where P : CreateReferenceDataRequest, new() 
                    where Q : CreateReferenceDataResponse, new( ) {


        public Q execute 
                    ( P the_request ) {

            return this
                    .set_request( the_request )
                    .sanatise_request( )
                    .validate()
                    .create_entity()
                    .commit()
                    .build_response()
                    ;
        }

        protected CreateReferenceData
                    ( IUnitOfWork the_unit_of_work
                    , Validator the_validator
                    , IEntityRepository<E> the_repository ) {

            unit_of_work = Guard.IsNotNull( the_unit_of_work, "the_unit_of_work" );
            validator = Guard.IsNotNull( the_validator, "the_validator" );
            repository = Guard.IsNotNull( the_repository, "the_repository" );

        }


        private CreateReferenceData<E,P,Q> set_request
                                                ( P the_request ) {

            Guard.IsNotNull( the_request, "the_request" );

            // Initialise the request and default the response to return a null identity 

            request = the_request;
            response_builder.set_response( new ReferenceDataIdentity { id = Null.Id} );

            return this;
        }


        private CreateReferenceData<E,P,Q> sanatise_request () {

            Guard.IsNotNull( request, "request" );

            request = new P {                
                description = request.description.normalise_for_persistence(),
                is_hidden = request.is_hidden,
            };

            return this;
        }


        private CreateReferenceData<E,P,Q> validate () {

            if ( response_builder.has_errors ) return this;

            Guard.IsNotNull( request, "request" );

            validator
                .field( "description" )
                .is_madatory(request.description, ValidationMessages.error_01_0003)
                .does_not_exceed_the_maximum_number_of_characters_for_a_text_field(request.description, ValidationMessages.error_01_0001)
                .premise_holds(
                    !repository
                         .Entities.Any(e => e.description.Equals( request.description, StringComparison.InvariantCultureIgnoreCase ))
                    , ValidationMessages.error_00_0018
                )
                ;

            response_builder.add_errors( validator.errors );

            if ( response_builder.has_errors ) {
                response_builder.add_error(ValidationMessages.warning_03_0001);
            }

            return this;
        }

        private CreateReferenceData<E,P,Q> create_entity () {

            if ( response_builder.has_errors ) return this;

            Guard.IsNotNull( request, "request" );

            // create the title
            entity = new E {
                description = request.description,
                is_hidden = request.is_hidden,
            };

            repository.add( entity );

            return this;
        }

        private CreateReferenceData<E,P,Q> commit () {
            
            if ( response_builder.has_errors ) return this;

            Guard.IsNotNull( entity, "entity" );

            unit_of_work.Commit( );

            // set the response the id of the new title
            response_builder.set_response( new ReferenceDataIdentity { id = entity.id });
            response_builder.add_message(ValidationMessages.confirmation_04_0001);

            return this;
        }

        private Q build_response () {

            return response_builder.build();
        }


        private readonly ResponseBuilder<ReferenceDataIdentity,Q> response_builder = 
            new ResponseBuilder<ReferenceDataIdentity,Q> ( );

        private readonly IUnitOfWork unit_of_work;
        private readonly Validator validator;
        private readonly IEntityRepository<E> repository;

        private P request;
        private E entity;
    }

}