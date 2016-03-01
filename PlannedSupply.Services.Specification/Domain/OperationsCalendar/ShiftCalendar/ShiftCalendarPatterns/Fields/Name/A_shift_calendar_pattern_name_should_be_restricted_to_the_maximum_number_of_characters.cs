using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.Edit;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.Edit.Update;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.New;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.New.Create;
using WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.ShiftCalendarPatterns.Features.Edit;
using WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.ShiftCalendarPatterns.Features.New;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.SpecificationTemplates.ForDomainLogic;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.ShiftCalendarPatterns.Fields.Name
{
    public class A_shift_calendar_pattern_name_should_be_restricted_to_the_maximum_number_of_characters
    {
        [TestClass]
        public class On_create
                        : TextFieldDoesNotExceedDefaultMaximumNumberOfCharactersSpecification<NewShiftCalendarPatternRequest,
                                                                                                NewShiftCalendarPatternResponse,
                                                                                                NewShiftCalendarPatternFixture
                                                                                             >
        {
            public On_create()
                : base((request, value) => request.pattern_name = value) { }
        }

        [TestClass]
        public class On_update
                        : TextFieldDoesNotExceedDefaultMaximumNumberOfCharactersSpecification<UpdateShiftCalendarPatternRequest,
                                                                                                UpdateShiftCalendarPatternResponse,
                                                                                                UpdateShiftCalendarPatternFixture
                                                                                             >
        {
            public On_update()
                : base((request, value) => request.pattern_name = value) { }
        }
    }
}