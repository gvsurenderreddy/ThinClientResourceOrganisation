using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.New;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.New.Create;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.SpecificationTemplates.ForDomainLogic;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.Features.New
{
    [TestClass]
    public class New_shift_calendar_will_commit_changes
                            : CommandCommitedChangesSpecification<NewShiftCalendarRequest,
                                                                    NewShiftCalendarResponse,
                                                                    NewShiftCalendarFixture
                                                                 > { }
}