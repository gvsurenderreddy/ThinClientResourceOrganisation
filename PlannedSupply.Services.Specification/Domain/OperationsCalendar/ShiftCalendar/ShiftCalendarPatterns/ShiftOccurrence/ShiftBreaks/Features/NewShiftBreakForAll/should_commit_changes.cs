using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence.ShiftBreaks.New;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.SpecificationTemplates.ForDomainLogic;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.ShiftCalendarPatterns.ShiftOccurrence.ShiftBreaks.Features.NewShiftBreakForAll
{
    [TestClass]
    public class NewShiftBreakForAll_should_commit_changes : CommandCommitedChangesSpecification<NewShiftBreakRequest,
                                                                                                    NewShiftBreakResponse,
                                                                                                    NewShiftBreakForAllFixture>
    {
        [TestMethod]
        public void and_the_new_shift_break_exists()
        {
            fixture.execute_command();

            Assert.IsNotNull(fixture.entity);
        }
    }
}
