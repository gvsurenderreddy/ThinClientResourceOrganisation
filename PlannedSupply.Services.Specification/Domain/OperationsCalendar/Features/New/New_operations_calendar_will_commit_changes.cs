using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.New;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.New.Create;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.SpecificationTemplates.ForDomainLogic;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.Features.New {

    [TestClass]
    public class New_operations_calendar_will_commit_changes
                    : CommandCommitedChangesSpecification<  NewOperationsCalendarRequest,
                                                            NewOperationsCalendarResponse,
                                                            NewOperationsCalendarFixture> {}
}