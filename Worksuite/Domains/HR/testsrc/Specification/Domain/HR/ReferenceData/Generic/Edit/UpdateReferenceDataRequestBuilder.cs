using WorkSuite.Library.Persistence;
using WorkSuite.Library.Service.Specification.Helpers.Request;
using WTS.WorkSuite.HR.Framework.Models;
using WTS.WorkSuite.HR.HR.ReferenceData.Generic.Edit;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Edit {


    public abstract class UpdateReferenceDataRequestBuilder<E,P>
                   : IRequestHelper<P> 
           where E : ReferenceDataModel, new() 
           where P : UpdateReferenceDataRequest, new() {


        public P given_a_valid_request () {

            var entity = new E {
                    description = "Mr",
                    is_hidden = false,
                };

            repository.add( entity );

            return new P
            {
                description = entity.description,
                is_hidden = entity.is_hidden,
                id = entity.id,
            };
        }


        protected UpdateReferenceDataRequestBuilder
                    ( IEntityRepository<E> the_repository ) {
           
            repository = Guard.IsNotNull( the_repository, "the_title_repository" );
        }

        private readonly IEntityRepository<E> repository;
    }         
}