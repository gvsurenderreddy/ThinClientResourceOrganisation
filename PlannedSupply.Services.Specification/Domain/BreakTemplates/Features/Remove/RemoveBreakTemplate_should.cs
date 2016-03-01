using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.BreakTemplates;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.SpecificationTemplates.Base;
using WTS.WorkSuite.PlannedSupply.BreakTemplates;
using WTS.WorkSuite.PlannedSupply.BreakTemplates.Remove;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.BreakTemplates.Features.Remove
{
    [TestClass]
    public class RemoveBreakTemplate_should
                        : PlannedSupplySpecification
    {
        [TestMethod]
        public void remove_the_break_template()
        {
            BreakTemplate break_template = _break_template_helper
                                                            .add()
                                                            .entity
                                                            ;

            RemoveBreakTemplateRequest remove_request = _get_remove_break_template_request
                                                                    .execute(new BreakTemplateIdentity { template_id = break_template.id })
                                                                    .result
                                                                    ;

            var response = _remove_break_template
                                .execute(new BreakTemplateIdentity { template_id = remove_request.template_id })
                                ;

            response.has_errors.Should().BeFalse();
        }

        protected override void test_setup()
        {
            base.test_setup();

            _get_remove_break_template_request = DependencyResolver.resolve<IGetRemoveBreakTemplateRequest>();
            _remove_break_template = DependencyResolver.resolve<IRemoveBreakTemplate>();
            _break_template_helper = DependencyResolver.resolve<BreakTemplateHelper>();
        }

        private IGetRemoveBreakTemplateRequest _get_remove_break_template_request;
        private IRemoveBreakTemplate _remove_break_template;
        private BreakTemplateHelper _break_template_helper;
    }
}