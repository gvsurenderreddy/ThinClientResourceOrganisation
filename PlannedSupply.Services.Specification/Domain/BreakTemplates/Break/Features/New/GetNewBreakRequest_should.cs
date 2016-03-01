using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.BreakTemplates;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.SpecificationTemplates.Base;
using WTS.WorkSuite.PlannedSupply.BreakTemplates;
using WTS.WorkSuite.PlannedSupply.BreakTemplates.Break;
using WTS.WorkSuite.PlannedSupply.BreakTemplates.Break.New;
using WTS.WorkSuite.PlannedSupply.BreakTemplates.Break.New.GetCreateRequest;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.BreakTemplates.Break.Features.New
{
    [TestClass]
    public class GetNewBreakRequest_should
                        : PlannedSupplySpecification
    {
        [TestMethod]
        public void return_a_valid_new_break_request()
        {
            BreakTemplate break_template = _break_template_helper
                                                                .add()
                                                                .entity
                                                                ;

            NewBreakRequest new_break_request = _get_new_break_request
                                                                                .execute(new BreakIdentity { template_id = break_template.id })
                                                                                ;

            new_break_request.off_set.hours.Should().BeEmpty();
            new_break_request.off_set.minutes.Should().BeEmpty();

            new_break_request.duration.hours.Should().BeEmpty();
            new_break_request.duration.minutes.Should().BeEmpty();

            new_break_request.is_paid.Should().BeFalse();
        }

        protected override void test_setup()
        {
            base.test_setup();

            _break_template_helper = DependencyResolver.resolve<BreakTemplateHelper>();
            _get_new_break_request = DependencyResolver.resolve<IGetNewBreakRequest>();
        }

        private IGetNewBreakRequest _get_new_break_request;
        private BreakTemplateHelper _break_template_helper;
    }
}