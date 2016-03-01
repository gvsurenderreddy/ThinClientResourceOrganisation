using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.SpecificationTemplates.Base;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.BreakTemplates.Break.Features.Queries.GetAll
{
    [TestClass]
    public class GetDetailsOfAllBreaks_should_return
                        : PlannedSupplySpecification
    {
        [TestMethod]
        public void an_empty_set_when_there_are_no_breaks()
        {
            _fixture
                .execute_command()
                ;

            _fixture
                .response
                .Match(

                    has_value:
                        response => response.Count.Should().Be(0),

                    nothing:
                        () => Assert.Fail()

                );
        }

        [TestMethod]
        public void all_breaks()
        {
            _fixture
                .add_break()
                .off_set_in_seconds(120)
                .duration_in_seconds(300)
                .is_paid(true)
                ;

            _fixture
                .add_break()
                .off_set_in_seconds(240)
                .duration_in_seconds(600)
                ;

            _fixture
                .execute_command()
                ;

            _fixture
                .response
                .Match(

                    has_value:
                        response => response.Count.Should().Be(2),

                    nothing:
                        () => Assert.Fail()

                );
        }

        protected override void test_setup()
        {
            base.test_setup();

            _fixture = DependencyResolver.resolve<GetDetailsOfAllBreaksFixture>();
        }

        private GetDetailsOfAllBreaksFixture _fixture;
    }
}