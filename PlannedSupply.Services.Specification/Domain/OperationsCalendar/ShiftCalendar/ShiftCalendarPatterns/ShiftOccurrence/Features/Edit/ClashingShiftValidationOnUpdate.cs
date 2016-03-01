using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence.Edit;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.SpecificationTemplates.ForDomainLogic;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.ShiftCalendarPatterns.ShiftOccurrence.Features.Edit
{
        [TestClass]
        public class ClashingShiftValidationOnUpdate : CheckClashingshiftsBetweenPeerSpecification <  EditSingleShiftOccurrenceRequest
                                                                                                    , EditSingleShiftOccurrenceResponse
                                                                                                    , EditSingleShiftOccurrenceFixture>
        {
        }

}