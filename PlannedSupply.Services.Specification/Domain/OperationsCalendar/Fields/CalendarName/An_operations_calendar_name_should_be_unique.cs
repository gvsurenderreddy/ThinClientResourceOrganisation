using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.Edit;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.Edit.Update;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.New;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.New.Create;
using WTS.WorkSuite.PlannedSupply.OperationsCalendars;
using WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.Features.Edit;
using WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.Features.New;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.PlannedSupply.OperationsCalendars;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.SpecificationTemplates.ForDomainLogic;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.Fields.CalendarName
{
    public class An_operations_calendar_name_should_be_unique
    {
        [TestClass]
        public class On_create
                            : UniqueTextFieldSpecification<NewOperationsCalendarRequest,
                                                            NewOperationsCalendarResponse,
                                                            NewOperationsCalendarFixture
                                                          >
        {
            protected override void create_entity_with_value(string the_value)
            {
                var operational_calendar_helper = DependencyResolver.resolve<OperationsCalendarHelper>();

                operational_calendar_helper
                    .add()
                    .calendar_name(the_value)
                    ;
            }

            protected override void set_request_value(string the_value)
            {
                fixture.request.calendar_name = the_value;
            }

            protected override string value
            {
                get { return "Low seasons demand"; }
            }
        }

        [TestClass]
        public class On_update
                        : UniqueTextFieldSpecification<UpdateOperationsCalendarRequest,
                                                        UpdateOperationsCalendarResponse,
                                                        UpdateOperationsCalendarFixture
                                                      >
        {
            [TestMethod]
            public void update_operational_calendar_fixture_should_return_an_operational_calendar_entity()
            {
                OperationalCalendar operational_calendar = fixture.entity;
                Assert.IsTrue(operational_calendar.id != 0);
            }

            protected override void create_entity_with_value(string the_value)
            {
                var operational_calendar_helper = DependencyResolver.resolve<OperationsCalendarHelper>();

                operational_calendar_helper
                    .add()
                    .calendar_name(the_value)
                    ;
            }

            protected override void set_request_value(string the_value)
            {
                fixture.request.calendar_name = the_value;
            }

            protected override string value
            {
                get { return "Low seasons demand"; }
            }
        }
    }
}