using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.HR.Framework.Models;
using WTS.WorkSuite.HR.HR.ReferenceData.Generic.Queries;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Base.Fixtures;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.ReferenceTemplate.Generic;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.Base;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Queries.GetDetailsOfAllReferenceData {

    public abstract class Returns_all_entries<E, Eb, R, F>
                             : HRSpecification
                    where E  : ReferenceDataModel, new()
                    where Eb : ReferenceDataBuilder<E>
                    where R  : ReferenceDataDetails
                    where F  : IsAQueryForASetFixture<E, Eb, R> {
        
        
        [TestMethod]
        public void Returns_an_empty_list_if_there_are_no_entries () {

            fixture.execute_query();

            fixture.response.result.Any().Should().BeFalse();
        }


        [TestMethod]
        public void returns_ordered_by_description_in_ascending_order () {
            fixture.add().description( "Dylan" );
            fixture.add().description( "Ermintrude" );
            fixture.add().description( "Zebedee" );
            fixture.add().description( "Brian" );
            fixture.add().description( "Florence" );

            fixture.execute_query();

            var response = fixture.response.result.ToList();
            var expected = response.OrderBy( x => x.description );

            response.Should().ContainInOrder( expected );
        }


        protected override void test_setup() {

            base.test_setup();

            fixture = DependencyResolver.resolve<F>();
        }

        protected F fixture;
    }
}