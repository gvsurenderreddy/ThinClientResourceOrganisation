using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.Edit;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.Edit.Update;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.New;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.New.Create;
using WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.Features.Edit;
using WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.Features.New;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.SpecificationTemplates.ForDomainLogic;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.Fields.CalendarName
{
    public class A_name_can_be_specified_for_an_operations_calendar
    {
        [TestClass]
        public class On_create
                            : FieldIsMappedCorrectlySpecification<NewOperationsCalendarRequest,
                                                                    NewOperationsCalendarResponse,
                                                                    NewOperationsCalendarFixture,
                                                                    OperationsCalendars.OperationalCalendar
                                                                 >
        {
            protected override bool validate(NewOperationsCalendarRequest request,
                                                OperationsCalendars.OperationalCalendar entity
                                            )
            {
                return request.calendar_name == entity.calendar_name;
            }
        }

        [TestClass]
        public class On_update
                            : FieldIsMappedCorrectlySpecification<UpdateOperationsCalendarRequest,
                                                                    UpdateOperationsCalendarResponse,
                                                                    UpdateOperationsCalendarFixture,
                                                                    OperationsCalendars.OperationalCalendar
                                                                 >
        {
            protected override bool validate(UpdateOperationsCalendarRequest request,
                                                OperationsCalendars.OperationalCalendar entity
                                            )
            {
                return request.calendar_name == entity.calendar_name;
            }
        }
    }
}