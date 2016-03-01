using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.BreakTemplates;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.SpecificationTemplates.Base;
using WTS.WorkSuite.PlannedSupply.BreakTemplates;
using WTS.WorkSuite.PlannedSupply.BreakTemplates.Edit;
using WTS.WorkSuite.PlannedSupply.BreakTemplates.New.GetCreateRequest;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.BreakTemplates.Fields.TemplateName
{
    [TestClass]
    public class TemplateName_for_a_break_template
                        : PlannedSupplySpecification
    {
        [TestMethod]
        public void should_default_to_empty_on_create()
        {
            var get_new_break_template = DependencyResolver.resolve<IGetNewBreakTemplateRequest>();

            var new_break_template_request = get_new_break_template
                                                        .execute()
                                                        ;

            new_break_template_request.template_name.Should().BeEmpty();
        }

        [TestMethod]
        public void should_default_to_empty_on_update()
        {
            BreakTemplateHelper break_template_helper = DependencyResolver.resolve<BreakTemplateHelper>();
            BreakTemplate break_template = break_template_helper
                                                            .add()
                                                            .entity
                                                            ;

            var request_command = DependencyResolver.resolve<WTS.WorkSuite.PlannedSupply.BreakTemplates.Edit.GetUpdateRequest.IGetUpdateBreakTemplateRequest>();
            UpdateBreakTemplateRequest update_break_template_request = request_command
                                                                                    .execute(new BreakTemplateIdentity { template_id = break_template.id })
                                                                                    .result
                                                                                    ;

            update_break_template_request.template_name.Should().BeNull();
        }
    }
}