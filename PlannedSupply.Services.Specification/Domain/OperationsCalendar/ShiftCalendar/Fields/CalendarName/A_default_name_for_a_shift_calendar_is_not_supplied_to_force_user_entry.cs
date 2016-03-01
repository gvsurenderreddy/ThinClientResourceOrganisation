using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.Edit;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.Edit.GetUpdateRequest;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.New;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.New.GetCreateRequest;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.PlannedSupply.OperationsCalendars;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.PlannedSupply.OperationsCalendars.ShiftCalendars;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.SpecificationTemplates.Base;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.Fields.CalendarName
{
    [TestClass]
    public class A_default_name_for_a_shift_calendar_is_not_supplied_to_force_user_entry
                        : PlannedSupplySpecification
    {
        [TestMethod]
        public void calendar_name_defaults_to_empty_on_create() {

            var operational_calendar = operational_calendar_helper
                                          .add()
                                          .calendar_name("An operational calendar")
                                          .entity
                                          ;

            var command = DependencyResolver.resolve<IGetNewShiftCalendarRequest>();

            var request = command.execute(new ShiftCalendarIdentity {
                operations_calendar_id = operational_calendar.id
            });

            request.calendar_name.Should().BeEmpty();
        }

        [TestMethod]
        public void calendar_name_is_mapped_to_correctly_in_an_update_request() {
            // arrange
            var operation_calendar = operational_calendar_helper
                                        .add();

            var shift_calendar = operation_calendar
                                    .add_shift_calendar();
                
            var command = DependencyResolver.resolve<IGetUpdateShiftCalendarRequest>();
            
            // act
            var response = command.execute( new ShiftCalendarIdentity {
                operations_calendar_id = operation_calendar.entity.id,
                shift_calendar_id = shift_calendar.entity.id,                
            });

            // assert
            response.result.calendar_name.Should().Be( shift_calendar.entity.calendar_name );
        }


        protected override void test_setup() {
            base.test_setup();

            operational_calendar_helper = DependencyResolver.resolve<OperationsCalendarHelper>();            
        }

        private OperationsCalendarHelper operational_calendar_helper;
    }
}