using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.PlannedSupply.BreakTemplates.Break.Edit;
using WTS.WorkSuite.PlannedSupply.BreakTemplates.Break.Edit.Update;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.SpecificationTemplates.ForDomainLogic;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.BreakTemplates.Break.Features.Edit
{
    public class ClashingBreaksValidationOnUpdate
    {
        [TestClass]
        public class OnUpdate : CheckBatchOfViolationSpecification<UpdateBreakRequest
                                                                   , UpdateBreakResponse
                                                                   , UpdateBreakFixture>
        {
            public OnUpdate()
                : base((request, new_break_request_start_after, new_break_request_duration) =>
                {
                    request.off_set = new_break_request_start_after;
                    request.duration = new_break_request_duration;

                }) { }
        }
    }
   
}
