using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.SpecificationTemplates.Base;
using WTS.WorkSuite.PlannedSupply.BreakTemplates.Queries.GetAll;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.BreakTemplates.Features.Queries.GetAll
{
    [TestClass]
    public class GetAllBreakTemplates_should_return
                    : PlannedSupplySpecification
    {
        [TestMethod]
        public void an_empty_set_when_there_are_no_break_templates()
        {
            var response = _get_all_break_templates_details
                                .execute()
                                ;

            response.result.Should().BeEmpty();
        }

        [TestMethod]
        public void all_break_templates()
        {
            _get_all_break_templates_fixture
                    .add_break_template()
                    .template_name("Breakk template A")
                    ;

            _get_all_break_templates_fixture
                    .add_break_template()
                    .template_name("Breakk template B")
                    ;

            var response = _get_all_break_templates_details
                                .execute()
                                ;

            response.result.Count().Should().Be(2);
        }

        protected override void test_setup()
        {
            base.test_setup();

            _get_all_break_templates_details = DependencyResolver.resolve<IGetAllBreakTemplatesDetails>();
            _get_all_break_templates_fixture = new GetAllBreakTemplatesFixture();
        }

        private GetAllBreakTemplatesFixture _get_all_break_templates_fixture;
        private IGetAllBreakTemplatesDetails _get_all_break_templates_details;
    }
}