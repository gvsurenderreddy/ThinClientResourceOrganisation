using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence.ShiftBreaks.New;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.SpecificationTemplates.ForDomainLogic;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.ShiftCalendarPatterns.ShiftOccurrence.ShiftBreaks.Features.NewShiftBreak
{
    [TestClass]
    public class NewShiftBreak_should_commit_changes : CommandCommitedChangesSpecification<NewShiftBreakRequest,
                                                                                            NewShiftBreakResponse,
                                                                                            NewShiftBreakFixture>
    {
        [TestMethod]
        public void and_the_new_shift_break_exists()
        {
            fixture.execute_command();

            Assert.IsNotNull(fixture.entity);
        }
    }
}
