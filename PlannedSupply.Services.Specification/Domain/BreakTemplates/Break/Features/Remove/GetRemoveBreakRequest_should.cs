using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Service.Specification.Helpers.Request;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.SpecificationTemplates.Base;
using WTS.WorkSuite.PlannedSupply.BreakTemplates.Break;
using WTS.WorkSuite.PlannedSupply.BreakTemplates.Break.Remove;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.BreakTemplates.Break.Features.Remove
{
    [TestClass]
    public class GetRemoveBreakRequest_should
                    : PlannedSupplySpecification
    {
        [TestMethod]
        public void return_a_valid_remove_break_request()
        {
            BreakIdentity break_identity = break_identity_request_helper
                                                            .given_a_valid_request()
                                                            ;

            RemoveBreakRequest request = get_remove_break_request
                                                    .execute(break_identity)
                                                    .result
                                                    ;

            request.template_id.Should().Be(break_identity.template_id);
            request.break_id.Should().Be(break_identity.break_id);
        }

        protected override void test_setup()
        {
            base.test_setup();

            get_remove_break_request = DependencyResolver.resolve<IGetRemoveBreakRequest>();
            break_identity_request_helper = DependencyResolver.resolve<IRequestHelper<BreakIdentity>>();
        }

        private IGetRemoveBreakRequest get_remove_break_request;
        private IRequestHelper<BreakIdentity> break_identity_request_helper;
    }
}