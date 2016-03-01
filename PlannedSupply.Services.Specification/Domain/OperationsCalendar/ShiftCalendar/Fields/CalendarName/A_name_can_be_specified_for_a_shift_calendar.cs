using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.New;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.New.Create;
using WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.Features.Edit;
using WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.Features.New;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.PlannedSupply.OperationsCalendars;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.SpecificationTemplates.Base;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.SpecificationTemplates.ForDomainLogic;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.Fields.CalendarName
{
    public class A_name_can_be_specified_for_a_shift_calendar
    {
        [TestClass]
        public class On_create
                            : FieldIsMappedCorrectlySpecification<NewShiftCalendarRequest,
                                                                    NewShiftCalendarResponse,
                                                                    NewShiftCalendarFixture,
                                                                    PlannedSupply.ShiftCalendars.ShiftCalendar
                                                                    >
        {
            protected override bool validate(NewShiftCalendarRequest request,
                                                PlannedSupply.ShiftCalendars.ShiftCalendar entity
                                            )
            {
                return request.calendar_name == entity.calendar_name;
            }
        }

        [TestClass]
        public class On_update
                        : PlannedSupplySpecification
        {
            [TestMethod]
            public void when_tries_to_update_a_shift_calendar()
            {
                // Add a shift calendar to an operations calendar and populate the request.
                var request = fixture.request;

                var operations_calendar = fake_operations_repository
                                                .Entities
                                                .Single(oc => oc.id == request.operations_calendar_id)
                                                ;

                fixture.execute_command();

                var shift_calendar = operations_calendar
                                        .ShiftCalendars
                                        .Single()
                                        ;

                shift_calendar.calendar_name.Should().Be(request.calendar_name);
            }

            protected override void test_setup()
            {
                base.test_setup();

                fixture = DependencyResolver.resolve<UpdateShiftCalendarFixture>();

                fake_operations_repository = DependencyResolver.resolve<FakeOperationsCalendarRepository>();
            }

            private UpdateShiftCalendarFixture fixture;
            private FakeOperationsCalendarRepository fake_operations_repository;
        }
    }
}