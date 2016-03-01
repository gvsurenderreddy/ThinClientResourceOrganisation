using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.Library.DomainTypes.Duration;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence.Edit;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence.New;
using WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.ShiftCalendarPatterns.ShiftOccurrence.Features.Edit;
using WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.ShiftCalendarPatterns.ShiftOccurrence.Features.New;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.SpecificationTemplates.ForDomainLogic;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.ShiftCalendarPatterns.ShiftOccurrence.Fields.Duration
{
    public class duration_should_be_mandatory
    {
        [TestClass]
        public class On_create
                     : MandatoryDurationFieldSpecification<NewShiftOccurrenceRequest
                                                          , NewShiftOccurrenceResponse
                                                          , NewShiftOccurrenceFixture>
        {
            public On_create()
                : base((request, duration_request) => request.duration = new DurationRequest() { hours = duration_request.hours, minutes = duration_request.minutes }) { }
        }

        [TestClass]
        public class OnUpdateForSingleShiftOccurrence
                     : MandatoryDurationFieldSpecification < EditSingleShiftOccurrenceRequest
                                                           , EditSingleShiftOccurrenceResponse
                                                           , EditSingleShiftOccurrenceFixture>
        {
            public OnUpdateForSingleShiftOccurrence () 
                : base((request,duration_request) => request.duration=new DurationRequest(){hours = duration_request.hours , minutes =duration_request.minutes })
            {
            }

        }
    }
}