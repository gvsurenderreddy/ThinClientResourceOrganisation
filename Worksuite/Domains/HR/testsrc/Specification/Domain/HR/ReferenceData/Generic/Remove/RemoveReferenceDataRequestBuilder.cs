using WorkSuite.Library.Persistence;
using WorkSuite.Library.Service.Specification.Helpers.Request;
using WTS.WorkSuite.HR.Framework.Models;
using WTS.WorkSuite.HR.HR.ReferenceData.Generic.Remove;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Remove {


    public abstract class RemoveReferenceDataRequestBuilder<E,P>
                   : IRequestHelper<P> 
           where E : ReferenceDataModel, new() 
           where P : RemoveReferenceDataRequest, new() {


        public P given_a_valid_request () {

            var entity = new E {
                    description = "Mr",
                    is_hidden = false,
                };

            repository.add( entity );

            return new P
            {
                id = entity.id,
            };
        }


        protected RemoveReferenceDataRequestBuilder
                    ( IEntityRepository<E> the_repository ) {
           
            repository = Guard.IsNotNull( the_repository, "the_title_repository" );
        }

        private readonly IEntityRepository<E> repository;
    }         
}