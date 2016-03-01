using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.New;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.New.Create;
using WTS.WorkSuite.PlannedSupply.OperationsCalendars;
using WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.Features.Edit;
using WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.Features.New;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.PlannedSupply.OperationsCalendars;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.PlannedSupply.OperationsCalendars.ShiftCalendars;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.SpecificationTemplates.Base;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.SpecificationTemplates.ForDomainLogic;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.Fields.CalendarName
{
    public class A_shift_calendar_name_should_be_unique
    {
        [TestClass]
        public class On_create
                            : UniqueTextFieldSpecification<NewShiftCalendarRequest,
                                                            NewShiftCalendarResponse,
                                                            NewShiftCalendarFixture
                                                            >
        {
            protected override void create_entity_with_value(string the_value)
            {
                var shift_calendar_helper = DependencyResolver.resolve<ShiftCalendarHelper>();
                ShiftCalendars.ShiftCalendar a_shift_calendar = shift_calendar_helper
                                                                                    .add()
                                                                                    .calendar_name(the_value)
                                                                                    .entity;

                var operational_calendar_repository = DependencyResolver.resolve<FakeOperationsCalendarRepository>();
                OperationalCalendar an_operational_calendar = operational_calendar_repository
                                                                    .Entities
                                                                    .Single()
                                                                    ;
                an_operational_calendar.ShiftCalendars.Add(a_shift_calendar);
            }

            protected override void set_request_value(string the_value)
            {
                fixture.request.calendar_name = the_value;
            }

            protected override string value
            {
                get { return "Shift calendar B"; }
            }
        }

        [TestClass]
        public class On_update
                        : PlannedSupplySpecification
        {
            [TestMethod]
            public void when_tries_to_update_a_shift_calendar_with_the_same_calendar_name_as_another_shift_calendar()
            {
                // Add a shift calendar to an operations calendar and populate the request.
                var request = fixture.request;

                var operations_calendar = fake_operations_repository
                                                .Entities
                                                .Single(oc => oc.id == request.operations_calendar_id)
                                                ;

                // Add another shift calaendar to the same operations calendar.
                operations_calendar.ShiftCalendars.Add(shift_calendar_builder.calendar_name(request.calendar_name).entity);

                // Now update the first shift calendar's calendar name with second shift calendar's calendar name.
                fixture.execute_command();

                // should fail to update.
                fixture
                    .update_response
                    .Match(

                        has_value:
                            response => response.has_errors.Should().Be(true),

                        nothing:
                            () => Assert.Fail()

                    );
            }

            protected override void test_setup()
            {
                base.test_setup();

                fixture = DependencyResolver.resolve<UpdateShiftCalendarFixture>();

                fake_operations_repository = DependencyResolver.resolve<FakeOperationsCalendarRepository>();
                shift_calendar_builder = DependencyResolver.resolve<ShiftCalendarBuilder>();
            }

            private UpdateShiftCalendarFixture fixture;
            private FakeOperationsCalendarRepository fake_operations_repository;
            private ShiftCalendarBuilder shift_calendar_builder;
        }
    }
}