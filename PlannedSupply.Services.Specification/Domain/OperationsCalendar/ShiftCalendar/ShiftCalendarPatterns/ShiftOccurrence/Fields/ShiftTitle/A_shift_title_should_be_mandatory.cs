using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence.Edit;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence.New;
using WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.ShiftCalendarPatterns.ShiftOccurrence.Features.Edit;
using WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.ShiftCalendarPatterns.ShiftOccurrence.Features.New;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.SpecificationTemplates.ForDomainLogic;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.ShiftCalendarPatterns.ShiftOccurrence.Fields.ShiftTitle
{
    public class A_shift_title_should_be_mandatory
    {
        [TestClass]
        public class OnCreate : MandatoryTextFieldSpecification < NewShiftOccurrenceRequest
                                                                , NewShiftOccurrenceResponse
                                                                , NewShiftOccurrenceFixture>
        {
            public OnCreate()
                : base((request, value) => request.shift_title = value)
            {
            }
        }

        [TestClass]
        public class OnUpdateForSingleShiftOccurrence : MandatoryTextFieldSpecification < EditSingleShiftOccurrenceRequest
                                                                                        , EditSingleShiftOccurrenceResponse
                                                                                        , EditSingleShiftOccurrenceFixture>
        {
            public OnUpdateForSingleShiftOccurrence()
                : base((request, value) => request.shift_title = value)
            {
            }

        }
    }
}