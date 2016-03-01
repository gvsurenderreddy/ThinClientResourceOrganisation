using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.SpecificationTemplates.Base;
using WTS.WorkSuite.PlannedSupply.BreakTemplates.New;
using WTS.WorkSuite.PlannedSupply.BreakTemplates.New.GetCreateRequest;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.BreakTemplates.Features.New
{
    [TestClass]
    public class GetNewBreakTemplateRequest_should
                        : PlannedSupplySpecification
    {
        [TestMethod]
        public void return_a_valid_get_new_break_template_request()
        {
            IGetNewBreakTemplateRequest get_new_break_template_request = DependencyResolver.resolve<IGetNewBreakTemplateRequest>();

            NewBreakTemplateRequest new_break_template_request = get_new_break_template_request
                                                                                .execute()
                                                                                ;

            new_break_template_request.template_name.Should().BeEmpty();
            new_break_template_request.is_hidden.Should().BeFalse();
        }
    }
}