using System.Linq;
using Content.Services.HR.Messages;
using WTS.WorkSuite.HR.Framework.Models;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.HR.ReferenceData.Generic.Remove {


    /// <summary>
    ///     Standard implementation of an IRemoveReferenceData command. Removes the
    /// entity if it is not in use otherwise it sets it to hidden.  If the entity
    /// has already been deleted this treat as the command was successful
    /// </summary>
    /// <typeparam name="E">
    ///     The concrete reference data entity type, it must be a descendent of
    /// <see cref="ReferenceDataModel"></see>
    /// </typeparam>
    /// <typeparam name="P">
    ///     The remove request type. It must be a descendent of <see cref="RemoveReferenceDataRequest"/>
    /// </typeparam>
    /// <typeparam name="Q">
    ///     The response which must be a descendent of <see cref="RemoveReferenceDataResponse"/>
    /// </typeparam>
    public abstract class RemoveReferenceData<E,P,Q>
                            : IRemoveReferenceData<P,Q> 
                    where P : RemoveReferenceDataRequest
                    where E : ReferenceDataModel             
                    where Q : RemoveReferenceDataResponse, new()  {


        public Q execute
                    ( P request ) {

            var entity = entity_repository
                            .Entities
                            .SingleOrDefault( e => e.id == request.id );

            if ( entity != null ) {

                try {
                    entity_repository.remove( entity );
                    unit_of_work.Commit();

                    response_builder.add_message( ValidationMessages.remove_was_successfull);               

                } catch {
                    // If there is an exception thrown we are assuming that it is a Referential 
                    // integrity exception so we fail safe and set to the entity to hidden and 
                    // report the error.
                    //
                    // If an exception is thrown in here then we expect the standard internal 
                    // error handler to catch this.  OK to be honest at the time of writing
                    // this we do not have the standard internal error handler set up so this
                    // is a little risky (sorry) but I do not want to litter the code with 
                    // scaffolding that I will have to take out latter.
                    entity.is_hidden = true;
                    entity_repository.Update( entity );
                    unit_of_work.Commit();

                    response_builder.add_error( ValidationMessages.remove_was_not_sccuessfull_hidden_instead);
                }                                
            }

            return response_builder.build();
        }

        protected RemoveReferenceData 
                    ( IUnitOfWork the_unit_of_work
                    , IEntityRepository<E> the_title_repository ) {

            unit_of_work = Guard.IsNotNull( the_unit_of_work, "the_unit_of_work" );
            entity_repository = Guard.IsNotNull( the_title_repository, "the_title_repository" );
        }

        private readonly ResponseBuilder<Q> response_builder = 
            new ResponseBuilder<Q>();

        private readonly IUnitOfWork unit_of_work;
        private readonly IEntityRepository<E> entity_repository;
    }
}