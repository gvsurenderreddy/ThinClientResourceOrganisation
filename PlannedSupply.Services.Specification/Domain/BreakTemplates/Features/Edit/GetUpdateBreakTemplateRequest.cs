using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.BreakTemplates;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.SpecificationTemplates.Base;
using WTS.WorkSuite.PlannedSupply.BreakTemplates;
using WTS.WorkSuite.PlannedSupply.BreakTemplates.Edit;
using WTS.WorkSuite.PlannedSupply.BreakTemplates.Edit.GetUpdateRequest;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.BreakTemplates.Features.Edit
{
    [TestClass]
    public class GetUpdateBreakTemplateRequest
                        : PlannedSupplySpecification
    {
        [TestMethod]
        public void should_return_a_valid_get_update_break_template_request()
        {
            BreakTemplateHelper break_template_helper = DependencyResolver.resolve<BreakTemplateHelper>();

            BreakTemplate break_template = break_template_helper
                                                            .add()
                                                            .entity
                                                            ;

            IGetUpdateBreakTemplateRequest get_update_break_template_request = DependencyResolver.resolve<IGetUpdateBreakTemplateRequest>();
            UpdateBreakTemplateRequest update_break_template_request = get_update_break_template_request
                                                                                        .execute(new BreakTemplateIdentity { template_id = break_template.id })
                                                                                        .result
                                                                                        ;
            update_break_template_request.template_id.Should().Be(break_template.id);
            update_break_template_request.is_hidden.Should().Be(break_template.is_hidden);
        }
    }
}