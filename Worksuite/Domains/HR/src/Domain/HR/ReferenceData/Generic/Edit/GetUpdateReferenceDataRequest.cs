using System.Linq;
using Content.Services.HR.Messages;
using WTS.WorkSuite.HR.Framework.Models;
using WTS.WorkSuite.Library.DomainTypes.DefaultValues;
using WTS.WorkSuite.Library.DomainTypes.Primitives.Sanitisation;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.HR.ReferenceData.Generic.Edit {

    public class GetUpdateReferenceDataRequest<E,R,Q>
                    : IGetUpdateReferenceDataRequest<R,Q>
            where E : ReferenceDataModel
            where R : UpdateReferenceDataRequest, new() 
            where Q : GetUpdateReferenceDataRequestResponse<R>, new() {


        public Q create 
                    ( ReferenceDataIdentity the_request ) {

            return this
                     .set_request( the_request )
                     .load_entity( )
                     .build_response(  )
                     ;
        }


        public GetUpdateReferenceDataRequest
                ( IEntityRepository<E> the_repository ) {
            
            repository = Guard.IsNotNull( the_repository, "the_repository" );
        }


        private GetUpdateReferenceDataRequest<E, R, Q> set_request 
                                                        ( ReferenceDataIdentity the_request ) {
            
            Guard.IsNotNull( the_request, "The Request can not be null" );

            request = the_request;

            response_builder.set_response( new R {
                id = Null.Id,                
            } );

            return this;
        }
        
        private GetUpdateReferenceDataRequest<E, R, Q> load_entity () {

            // If there has already been an error in the pipeline then 
            // do not try to check anything.  If it is reported as OK
            // then check the invariants and then load the reference 
            // data entity that the update request is for. If that 
            // the entity does not exist then we set this a an error
            // in the pipeline rather that a misuse error as it may
            // just be a stale request where the entity was delete
            // in between the user viewing the entities and them 
            // deciding that they wanted to edit it.

            if ( response_builder.has_errors ) return this;

            Guard.IsNotNull( request, "The Request can not be null" );

            entity = repository
                      .Entities
                      .FirstOrDefault( e => e.id == request.id )
                      ;

            if ( entity == null ) {
                response_builder.add_error( ValidationMessages.reference_data_entry_not_found );
            }

            // to do: NOTE - The error handling needs to have some input
            //               from Tim as to what he wants to happen in the 
            //               front end in the event of this situation we 
            //               can then work out what the error message 
            //               should be.
            
            return this;
        }

        private Q build_response () {

            // if there has already been an error in the pipeline then
            // do not try to build the response. If the pipeline is OK
            // then check the pre-conditions for this stage ( we have an entity )
            // set the response

            if ( response_builder.has_errors ) return response_builder.build();


            Guard.IsNotNull( entity, "The entity can not be null when building the response" );

            response_builder.set_response( new R {
                id = entity.id,
                description = entity.description.normalise_for_presentation() ,
                is_hidden= entity.is_hidden,
            } );

            return response_builder.build();
        }

        // standard builder that is used to create responses.
        private readonly ResponseBuilder<R, Q> response_builder = 
                            new ResponseBuilder<R, Q>();

        // repository used to find the entity to create the request for.  
        private readonly IEntityRepository<E> repository;

        // request that is supplied by the user, tells which
        // entity we want the update request for.
        private ReferenceDataIdentity request;

        // Entity that the update request is to be create for.
        private E entity;
    }
}