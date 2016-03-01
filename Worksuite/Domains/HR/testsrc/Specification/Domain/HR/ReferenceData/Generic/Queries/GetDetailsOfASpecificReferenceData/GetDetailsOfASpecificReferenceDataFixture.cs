using WTS.WorkSuite.HR.Framework.Models;
using WTS.WorkSuite.HR.HR.ReferenceData.Generic.Queries;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Base.Fixtures;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.ReferenceTemplate.Generic;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Queries.GetDetailsOfASpecificReferenceData {


    public abstract class GetDetailsOfASpecificReferenceDataFixture<E,R,C,Eb,Rb> 
                             : IsAQueryForAnEntityFixture<E,Eb,R>
                    where E  : ReferenceDataModel, new() 
                    where R  : ReferenceDataDetails 
                    where C  : IGetDetailsOfASpecificReferenceData<R>
                    where Eb : ReferenceDataBuilder<E> 
                    where Rb : GetDetailsOfASpecificReferenceDataRequestHelper<E,Eb> {


        public Eb entity { get; private set; }

        public void execute_query () {
            response = query.execute( request_builder.given_a_valid_request( ) );
        }

        public Response<R> response { get; private set; }


        protected GetDetailsOfASpecificReferenceDataFixture
                    ( Rb the_request_builder
                    , C the_query ) {

            request_builder = Guard.IsNotNull( the_request_builder, "the_request_builder" );
            query = Guard.IsNotNull( the_query, "the_query" );

            entity = request_builder.builder;
        }

        private readonly Rb request_builder;
        private readonly C query;
    }


}