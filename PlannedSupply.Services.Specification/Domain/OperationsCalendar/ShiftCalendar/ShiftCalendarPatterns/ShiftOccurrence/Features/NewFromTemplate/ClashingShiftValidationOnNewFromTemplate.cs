using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence.NewFromTemplate;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.SpecificationTemplates.ForDomainLogic;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.ShiftCalendarPatterns.ShiftOccurrence.Features.NewFromTemplate
{
        [TestClass]
    public class ClashingShiftValidationOnNewFromTemplate : CheckClashingshiftsBetweenPeerSpecification < NewShiftOccurrenceFromShiftTemplateRequest,
                                                                                                          NewShiftOccurrenceFromShiftTemplateResponse,
                                                                                                          NewShiftOccurrenceFromShiftTemplateFixture>
        {
        }

}