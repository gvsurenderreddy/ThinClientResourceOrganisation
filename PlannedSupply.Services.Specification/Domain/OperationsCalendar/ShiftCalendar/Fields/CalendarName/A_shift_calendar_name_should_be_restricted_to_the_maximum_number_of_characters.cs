using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.Edit;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.Edit.Update;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.New;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.New.Create;
using WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.Features.Edit;
using WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.Features.New;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.SpecificationTemplates.ForDomainLogic;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.Fields.CalendarName
{
    public class A_shift_calendar_name_should_be_restricted_to_the_maximum_number_of_characters
    {
        [TestClass]
        public class On_create
                            : TextFieldDoesNotExceedDefaultMaximumNumberOfCharactersSpecification<NewShiftCalendarRequest,
                                                                                                    NewShiftCalendarResponse,
                                                                                                    NewShiftCalendarFixture
                                                                                                 >
        {
            public On_create()
                : base((request, value) => request.calendar_name = value) { }
        }

        [TestClass]
        public class On_update
                            : TextFieldDoesNotExceedDefaultMaximumNumberOfCharactersSpecification<UpdateShiftCalendarRequest,
                                UpdateShiftCalendarResponse,
                                UpdateShiftCalendarFixture
                                >
        {
            public On_update()
                : base((request, value) => request.calendar_name = value) { }
        }
    }
}