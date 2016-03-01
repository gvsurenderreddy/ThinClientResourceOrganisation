using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.Library.DomainTypes.Duration;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence.Edit;
using WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.ShiftCalendarPatterns.ShiftOccurrence.Features.Edit;
using WTS.WorkSuite.PlannedSupply.Services.Domain.ShiftTemplates.Features.New;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.SpecificationTemplates.ForDomainLogic;
using WTS.WorkSuite.PlannedSupply.ShiftTemplates.New;
using WTS.WorkSuite.PlannedSupply.ShiftTemplates.New.Create;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.ShiftCalendarPatterns.ShiftOccurrence.Fields.Duration
{
    public class Is_valid
    {
        [TestClass]
        public class OnCreate : DurationInHoursAndMinutesSpecification<NewShiftTemplatesRequest
                                                                       , NewShiftTemplateResponse
                                                                       , NewShiftTemplatesFixture>
        {
            public OnCreate()
                : base((request, duration_request) => request.duration = duration_request) { }
        }

        [TestClass]
        public class OnUpdateForSingleShiftOccurrence : DurationInHoursAndMinutesSpecification < EditSingleShiftOccurrenceRequest
                                                                                               , EditSingleShiftOccurrenceResponse
                                                                                               , EditSingleShiftOccurrenceFixture>
        {
            public OnUpdateForSingleShiftOccurrence()
                : base((request, duration_request) => request.duration = new DurationRequest() { hours = duration_request.hours, minutes = duration_request.minutes })
            {
            }

        }
    }
}