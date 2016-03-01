using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence.ShiftBreaks.ApplyFromTemplate;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.SpecificationTemplates.ForDomainLogic;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.ShiftCalendarPatterns.ShiftOccurrence.ShiftBreaks.Features.ApplyFromTemplateForAll
{
    [TestClass]
    public class ApplyShiftBreaksFromBreakTemplate_should_commit_changes : CommandCommitedChangesSpecification<ApplyShiftBreaksFromBreakTemplateRequest,
                                                                                                                ApplyShiftBreaksFromBreakTemplateResponse,
                                                                                                                ApplyShiftBreaksFromBreakTemplateForAllFixture>
    {
        [TestMethod]
        public void response_is_not_null()
        {
            fixture.execute_command();

            Assert.IsNotNull(fixture.response.result);
        }
    }
}
