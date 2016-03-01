using System.Collections.Generic;
using WTS.WorkSuite.HR.Framework.Models;
using WTS.WorkSuite.HR.HR.ReferenceData.Generic.Queries;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Base.Fixtures;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.ReferenceTemplate.Generic;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Queries.GetDetailsOfAllReferenceData {

    public abstract class GetDetailsOfAllReferenceDataFixture<E,R,C,Eb,Er,Eh> 
                             : IsAQueryForASetFixture<E,Eb,R>
                    where E  : ReferenceDataModel, new() 
                    where Eb : ReferenceDataBuilder<E> 
                    where Er : FakeReferenceDataRepository<E>
                    where Eh : ReferenceDataHelper<E,Eb,Er>
                    where R  : ReferenceDataDetails
                    where C  : IGetDetailsOfAllReferenceData<R> {

        public Eb add () {
            return helper.add();
        }

        public void execute_query () {
            response = query.execute();
        }

        public Response<IEnumerable<R>> response { get; private set; }

        protected GetDetailsOfAllReferenceDataFixture
                    ( Eh the_helper 
                    , C the_query ) {

            helper = Guard.IsNotNull( the_helper, "the_helper" );
            query = Guard.IsNotNull( the_query, "the_query" );
        }

        private readonly Eh helper;
        private readonly C query;
    }
}