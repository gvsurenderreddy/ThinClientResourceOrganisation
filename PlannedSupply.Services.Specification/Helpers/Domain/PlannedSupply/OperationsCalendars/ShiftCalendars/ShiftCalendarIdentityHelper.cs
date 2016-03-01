using System.Linq;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar;
using WTS.WorkSuite.PlannedSupply.OperationsCalendars;

namespace WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.PlannedSupply.OperationsCalendars.ShiftCalendars
{
    public class ShiftCalendarIdentityHelper
    {
        public ShiftCalendarIdentity get_identity()
        {
            return new ShiftCalendarIdentity
            {
                operations_calendar_id = operations_calendar.id,
                shift_calendar_id = shift_calendar.id
            };
        }

        public ShiftCalendarIdentityHelper()
        {
            shift_calendar_builder = DependencyResolver.resolve<ShiftCalendarBuilder>();
            operational_calendar_helper = DependencyResolver.resolve<OperationsCalendarHelper>();

            var operations_calendar_builder = operational_calendar_helper
                                                    .add();

            operations_calendar_builder
                    .add_shift_calendar(shift_calendar_builder.calendar_name("Shift calendar A").entity)
                    ;

            operations_calendar = operations_calendar_builder.entity;

            shift_calendar = operations_calendar
                                    .ShiftCalendars
                                    .Single()
                                    ;
        }

        private OperationsCalendarHelper operational_calendar_helper;
        private ShiftCalendarBuilder shift_calendar_builder;

        private OperationalCalendar operations_calendar;
        private WorkSuite.PlannedSupply.ShiftCalendars.ShiftCalendar shift_calendar;
    }
}