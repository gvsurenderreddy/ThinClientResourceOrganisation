using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.BreakTemplates.Breaks;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.SpecificationTemplates.Base;
using WTS.WorkSuite.PlannedSupply.BreakTemplates;
using WTS.WorkSuite.PlannedSupply.BreakTemplates.Queries.GetById;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.BreakTemplates.Features.Queries.GetById
{
    [TestClass]
    public class GetBreakTemplateById_should_map_the_field
                        : PlannedSupplySpecification
    {
        [TestMethod]
        public void template_name()
        {
            string template_name = "A shift breakk template";
            BreakTemplate break_template = _fixture
                                                            .add_break_template()
                                                            .template_name(template_name)
                                                            .entity
                                                            ;

            var response = _get_break_template_by_id
                                .execute(new BreakTemplateIdentity { template_id = break_template.id })
                                ;

            response.result.template_name.Should().Be(template_name);
        }

        [TestMethod]
        public void all_breaks()
        {
            BreakBuilder break_builder = new BreakBuilder(new Breaks.Break());
            var breakk = break_builder.entity;

            string template_name = "A shift breakk template";
            BreakTemplate break_template = _fixture
                                                            .add_break_template()
                                                            .template_name(template_name)
                                                            .add_break(breakk)
                                                            .entity
                                                            ;

            var response = _get_break_template_by_id
                                .execute(new BreakTemplateIdentity { template_id = break_template.id })
                                ;

            response.result.all_breaks.Count().Should().Be(1);
        }

        protected override void test_setup()
        {
            base.test_setup();

            _get_break_template_by_id = DependencyResolver.resolve<IGetBreakTemplateDetailsById>();
            _fixture = new GetBreakTemplateByIdFixture();
        }

        private IGetBreakTemplateDetailsById _get_break_template_by_id;
        private GetBreakTemplateByIdFixture _fixture;
    }
}