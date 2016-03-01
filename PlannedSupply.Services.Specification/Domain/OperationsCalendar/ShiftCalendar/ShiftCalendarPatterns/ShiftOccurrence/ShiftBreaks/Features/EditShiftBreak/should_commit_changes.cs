using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence.ShiftBreaks.Edit;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.SpecificationTemplates.ForDomainLogic;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.ShiftCalendarPatterns.ShiftOccurrence.ShiftBreaks.Features.EditShiftBreak
{
    [TestClass]
    public class EditShiftBreak_should_commit_changes : CommandCommitedChangesSpecification<EditShiftBreakRequest,
                                                                                            EditShiftBreakResponse,
                                                                                            EditShiftBreakFixture>
    {
        [TestMethod]
        public void and_the_edit_shift_break_exists()
        {
            fixture.execute_command();

            Assert.IsNotNull(fixture.entity);
        }
    }
}
