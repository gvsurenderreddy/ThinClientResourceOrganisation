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
    public class An_operations_calendar_name_should_be_mandatory
    {
        [TestClass]
        public class On_create
                            : MandatoryTextFieldSpecification<  NewOperationsCalendarRequest,
                                                                NewOperationsCalendarResponse,
                                                                NewOperationsCalendarFixture
                                                             >
        {
            public On_create()
                            : base( ( request, value ) => request.calendar_name = value ) {}
        }

        [TestClass]
        public class On_update
                            : MandatoryTextFieldSpecification<  UpdateOperationsCalendarRequest,
                                                                UpdateOperationsCalendarResponse,
                                                                UpdateOperationsCalendarFixture
                                                             >
        {
            public On_update()
                            : base( ( request, value ) => request.calendar_name = value ) {}
        }
    }
}