
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence.ShiftBreaks.Remove;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.SpecificationTemplates.ForDomainLogic;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.ShiftCalendarPatterns.ShiftOccurrence.ShiftBreaks.Features.RemoveShiftBreakForAll
{
    [TestClass]
    public class RemoveShiftBreak_should_commit_changes : CommandCommitedChangesSpecification<RemoveShiftBreakRequest,
                                                                                                RemoveShiftBreakResponse,
                                                                                                RemoveShiftBreakForAllOccurrencesFixture>
    {

    }
}
