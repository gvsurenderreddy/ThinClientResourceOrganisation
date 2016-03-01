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
    public class A_shift_calendar_name_should_be_mandatory
    {
        [TestClass]
        public class On_create
                            : MandatoryTextFieldSpecification<NewShiftCalendarRequest,
                                                                NewShiftCalendarResponse,
                                                                NewShiftCalendarFixture
                                                             >
        {
            public On_create()
                : base((request, value) => request.calendar_name = value) { }
        }

        [TestClass]
        public class On_update
                            : MandatoryTextFieldSpecification<UpdateShiftCalendarRequest,
                                UpdateShiftCalendarResponse,
                                UpdateShiftCalendarFixture
                                >
        {
            public On_update()
                : base((request, value) => request.calendar_name = value) { }
        }
    }
}