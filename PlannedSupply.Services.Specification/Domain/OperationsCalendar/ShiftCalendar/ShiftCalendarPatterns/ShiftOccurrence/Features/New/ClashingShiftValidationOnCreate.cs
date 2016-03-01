using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence.New;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.SpecificationTemplates.ForDomainLogic;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.ShiftCalendarPatterns.ShiftOccurrence.Features.New
{
        [TestClass]
    public class ClashingShiftValidationOnCreate : CheckClashingshiftsBetweenPeerSpecification  < NewShiftOccurrenceRequest
                                                                                                 , NewShiftOccurrenceResponse
                                                                                                 , NewShiftOccurrenceFixture>
        {
        }

}