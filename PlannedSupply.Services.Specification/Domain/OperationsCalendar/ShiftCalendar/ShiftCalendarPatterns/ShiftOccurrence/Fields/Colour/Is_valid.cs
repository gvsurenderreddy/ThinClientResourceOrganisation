using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence.Edit;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence.New;
using WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.ShiftCalendarPatterns.ShiftOccurrence.Features.Edit;
using WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.ShiftCalendarPatterns.ShiftOccurrence.Features.New;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.SpecificationTemplates.ForDomainLogic;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.ShiftCalendarPatterns.ShiftOccurrence.Fields.Colour
{
    public class Is_valid
    {
        [TestClass]
        public class OnCreate : ColourPickerRgbSpecification<NewShiftOccurrenceRequest
                                                                                    , NewShiftOccurrenceResponse
                                                                                    , NewShiftOccurrenceFixture>
        {
            public  OnCreate() 
                            : base((request,colour_request) => request.colour = colour_request) 
             { }
        }

        [TestClass]
        public class OnUpdateForSingleShiftOccurrence
                                         : ColourPickerRgbSpecification<EditSingleShiftOccurrenceRequest
                                                                        , EditSingleShiftOccurrenceResponse
                                                                        , EditSingleShiftOccurrenceFixture>
        {
            public OnUpdateForSingleShiftOccurrence () 
                             : base((request, colour_request) => request.colour = colour_request)
            {
            }

        }
    }
}