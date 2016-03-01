using WorkSuite.Library.Persistence;
using WorkSuite.Library.Service.Specification.Helpers.Request;
using WTS.WorkSuite.HR.Framework.Models;
using WTS.WorkSuite.HR.HR.ReferenceData.Generic;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.ReferenceTemplate.Generic;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Queries.GetDetailsOfASpecificReferenceData {

    public abstract class GetDetailsOfASpecificReferenceDataRequestHelper<E,Eb>
                             : IRequestHelper<ReferenceDataIdentity> 
                    where E  : ReferenceDataModel, new( ) 
                    where Eb : ReferenceDataBuilder<E> {


        public Eb builder {
                    get; private set;
        }

        public ReferenceDataIdentity given_a_valid_request () {

            return new ReferenceDataIdentity {
                id = builder.entity.id,
            };
        }

        protected GetDetailsOfASpecificReferenceDataRequestHelper 
                    ( IEntityRepository<E> the_repository 
                    , Eb the_builder ) {
            
            repository = Guard.IsNotNull( the_repository, "the_repository" );
            builder = Guard.IsNotNull( the_builder, "the_builder" );

            builder
                .description( "A description" )
                .is_hidden( false )
                ;

            repository
                .add( builder.entity );
        }

        private readonly IEntityRepository<E> repository;
    }
}