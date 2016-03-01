using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.SpecificationTemplates.Base;
using WTS.WorkSuite.PlannedSupply.BreakTemplates;
using WTS.WorkSuite.PlannedSupply.BreakTemplates.Queries.GetAll;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.BreakTemplates.Features.Queries.GetAll
{
    [TestClass]
    public class GetAllBreakTemplates_should_correctly_maps_the_field
                        : PlannedSupplySpecification
    {
        [TestMethod]
        public void template_name()
        {
            BreakTemplate break_template = _get_all_break_templates_fixture
                                                            .add_break_template()
                                                            .template_name("A shift breakk template")
                                                            .entity
                                                            ;

            var the_break_template = _get_all_break_templates_details
                                                    .execute()
                                                    .result
                                                    .Single()
                                                    ;

            break_template.template_name.Should().Be(the_break_template.template_name);
        }

        public void is_hidden()
        {
            BreakTemplate break_template = _get_all_break_templates_fixture
                                                            .add_break_template()
                                                            .is_hidden(true)
                                                            .entity
                                                            ;

            var the_break_template = _get_all_break_templates_details
                                                    .execute()
                                                    .result
                                                    .Single()
                                                    ;

            break_template.is_hidden.Should().Be(the_break_template.is_hidden);
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