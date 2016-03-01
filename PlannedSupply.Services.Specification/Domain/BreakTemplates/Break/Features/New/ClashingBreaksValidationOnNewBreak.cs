using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.PlannedSupply.BreakTemplates.Break.New;
using WTS.WorkSuite.PlannedSupply.BreakTemplates.Break.New.Create;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.SpecificationTemplates.ForDomainLogic;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.BreakTemplates.Break.Features.New
{
    public class ClashingBreaksValidationOnNewBreak

    {
        [TestClass]
        public class OnCreate : CheckBatchOfViolationSpecification < NewBreakRequest
                                                                    , NewBreakResponse
                                                                    , NewBreakFixture >
        {
            public OnCreate()
                : base((request, new_break_off_set_request,new_break_duration_request) =>
                {
                    request.off_set = new_break_off_set_request;
                    request.duration = new_break_duration_request;
                }) { }
        }
    }
}
