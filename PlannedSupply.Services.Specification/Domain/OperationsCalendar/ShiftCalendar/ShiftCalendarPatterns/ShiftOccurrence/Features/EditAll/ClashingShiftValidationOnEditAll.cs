using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence.EditAll;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.SpecificationTemplates.ForDomainLogic;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.ShiftCalendarPatterns.ShiftOccurrence.Features.EditAll
{
        [TestClass]
    public class ClashingShiftValidationOnEditAll : CheckClashingshiftsBetweenPeerSpecification < EditAllShiftOccurrencesRequest
                                                                                                , EditAllShiftOccurrencesResponse
                                                                                                , EditAllShiftOccurrencesFixture>
        {
        }

}