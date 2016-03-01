using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.Library.DomainTypes.Time;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence.Edit;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence.New;
using WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.ShiftCalendarPatterns.ShiftOccurrence.Features.Edit;
using WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.ShiftCalendarPatterns.ShiftOccurrence.Features.New;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.SpecificationTemplates.ForDomainLogic;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.ShiftCalendarPatterns.ShiftOccurrence.Fields.StartTime
{
    public class Start_time_should_be_mandatory
    {

        [TestClass]
        public class On_create
                        : MandatoryTimeFieldSpecification < NewShiftOccurrenceRequest
                                            , NewShiftOccurrenceResponse
                                            , NewShiftOccurrenceFixture >
        {
            public On_create()
                : base((request, time_request) => request.start_time = new TimeRequest() { hours = time_request.hours, minutes = time_request.minutes })
            {
            }
        }

        [TestClass]
        public class OnUpdateForSingleShiftOccurrence : MandatoryTimeFieldSpecification < EditSingleShiftOccurrenceRequest
                                                                                        , EditSingleShiftOccurrenceResponse
                                                                                        , EditSingleShiftOccurrenceFixture>
        {
            public OnUpdateForSingleShiftOccurrence() 
               : base((request, time_request) => request.start_time = time_request)
            {
            }

        }
    }
}