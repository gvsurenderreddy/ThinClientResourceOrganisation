using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.SpecificationTemplates.Base;
using WTS.WorkSuite.PlannedSupply.BreakTemplates.Queries.GetAll;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.BreakTemplates.Features.Queries.GetAll
{
    [TestClass]
    public class GetAllBreakTemplates_should_order_all_break_templates_by
                        : PlannedSupplySpecification
    {
        [TestMethod]
        public void template_name()
        {
            var break_template_R = _get_all_break_templates_fixture
                                            .add_break_template()
                                            .template_name("A shift breakk template R")
                                            .entity
                                            ;

            var break_template_Z = _get_all_break_templates_fixture
                                            .add_break_template()
                                            .template_name("A shift breakk template Z")
                                            .entity
                                            ;

            var break_template_A = _get_all_break_templates_fixture
                                            .add_break_template()
                                            .template_name("A shift breakk template A")
                                            .is_hidden(true)
                                            .entity
                                            ;

            var response = _get_all_break_templates_details
                                .execute()
                                .result
                                .ToList()
                                ;

            var top_break_template = response.First();
            var bottom_break_template = response.Last();

            top_break_template.template_name.Should().Be(break_template_A.template_name);
            bottom_break_template.template_name.Should().Be(break_template_Z.template_name);
            response.Count.Should().Be(3);
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