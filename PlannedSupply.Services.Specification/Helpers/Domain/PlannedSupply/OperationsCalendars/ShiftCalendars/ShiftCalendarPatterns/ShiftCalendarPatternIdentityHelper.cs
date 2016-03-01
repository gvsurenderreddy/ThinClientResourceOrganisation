using System.Linq;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern;
using WTS.WorkSuite.PlannedSupply.OperationsCalendars;
using WTS.WorkSuite.PlannedSupply.ShiftCalendarPatterns;

namespace WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.PlannedSupply.OperationsCalendars.ShiftCalendars.ShiftCalendarPatterns
{
    public class ShiftCalendarPatternIdentityHelper
    {
        public ShiftCalendarPatternIdentity get_identity()
        {
            return new ShiftCalendarPatternIdentity
            {
                operations_calendar_id = operations_calendar.id,
                shift_calendar_id = shift_calendar.id,
                shift_calendar_pattern_id = shift_calendar_pattern.id
            };
        }

        public ShiftCalendarPatternIdentityHelper()
        {
            shift_calendar_identity_helper = new ShiftCalendarIdentityHelper();
            var shift_calendar_identity = shift_calendar_identity_helper.get_identity();

            fake_operations_calendar_repository = DependencyResolver.resolve<FakeOperationsCalendarRepository>();
            operations_calendar = fake_operations_calendar_repository
                                        .Entities
                                        .Single(oc => oc.id == shift_calendar_identity.operations_calendar_id)
                                        ;

            shift_calendar = operations_calendar
                                .ShiftCalendars
                                .Single(sc => sc.id == shift_calendar_identity.shift_calendar_id)
                                ;

            shift_calendar_pattern_builder = DependencyResolver.resolve<ShiftCalendarPatternBuilder>();
            shift_calendar_pattern = shift_calendar_pattern_builder.pattern_name("Shift calendar pattern A").entity;

            shift_calendar.ShiftCalendarPatterns.Add(shift_calendar_pattern);
        }

        private ShiftCalendarIdentityHelper shift_calendar_identity_helper;
        private FakeOperationsCalendarRepository fake_operations_calendar_repository;
        private ShiftCalendarPatternBuilder shift_calendar_pattern_builder;

        private OperationalCalendar operations_calendar;
        private WorkSuite.PlannedSupply.ShiftCalendars.ShiftCalendar shift_calendar;
        private ShiftCalendarPattern shift_calendar_pattern;
    }
}