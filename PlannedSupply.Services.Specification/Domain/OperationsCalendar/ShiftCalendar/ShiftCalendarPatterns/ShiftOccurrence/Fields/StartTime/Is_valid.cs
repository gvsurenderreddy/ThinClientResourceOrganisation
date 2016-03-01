using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence.Edit;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence.New;
using WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.ShiftCalendarPatterns.ShiftOccurrence.Features.Edit;
using WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.ShiftCalendarPatterns.ShiftOccurrence.Features.New;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.SpecificationTemplates.ForDomainLogic;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.ShiftCalendarPatterns.ShiftOccurrence.Fields.StartTime
{
    public class Is_valid
    {
        [TestClass]
        public class OnCreate : TwentyFourHourClockTimeSpecification < NewShiftOccurrenceRequest
                                                                     , NewShiftOccurrenceResponse
                                                                     , NewShiftOccurrenceFixture>
        {
            public OnCreate()
                : base((request, time_request) => request.start_time = time_request)
            {
            }
        }

        [TestClass]
        public class OnUpdateForSingleShiftOccurrence : TwentyFourHourClockTimeSpecification < EditSingleShiftOccurrenceRequest
                                                                                             , EditSingleShiftOccurrenceResponse
                                                                                             , EditSingleShiftOccurrenceFixture>
                                 
        {
            public OnUpdateForSingleShiftOccurrence() 
                  : base((request , time_request) => request.start_time =time_request) { }

        }
    }
}