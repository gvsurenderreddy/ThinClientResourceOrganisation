using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence.ShiftBreaks.ApplyFromTemplate;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.SpecificationTemplates.ForDomainLogic;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.ShiftCalendarPatterns.ShiftOccurrence.ShiftBreaks.Features.ApplyFromTemplate
{
    [TestClass]
    public class ApplyShiftBreaksFromBreakTemplate_should_commit_changes : CommandCommitedChangesSpecification<ApplyShiftBreaksFromBreakTemplateRequest,
                                                                                                                ApplyShiftBreaksFromBreakTemplateResponse,
                                                                                                                ApplyShiftBreaksFromBreakTemplateFixture>
    {

    }
}
