using System.Collections.Generic;
using System.Linq;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.PlannedSupply.OperationsCalendars;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.PlannedSupply.OperationsCalendars;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.PlannedSupply.OperationsCalendars.ShiftCalendars;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.PlannedSupply.OperationsCalendars.ShiftCalendars.ShiftCalendarPatterns;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.SpecificationTemplates.Base;
using WTS.WorkSuite.PlannedSupply.ShiftCalendarPatterns;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.ShiftCalendarPatterns.Features
{
    public class ReorderShiftCalendarPatternSpecifiction : PlannedSupplySpecification
    {
        protected override void test_setup()
        {
            base.test_setup();

            shift_calendar_identity_helper = new ShiftCalendarIdentityHelper();
            var shift_calendar_pattern_identity = shift_calendar_identity_helper.get_identity();

            fake_operations_calendar_repository = DependencyResolver.resolve<FakeOperationsCalendarRepository>();
            operational_calendar = fake_operations_calendar_repository
                                        .Entities
                                        .Single(oc => oc.id == shift_calendar_pattern_identity.operations_calendar_id)
                                        ;

            shift_calendar = operational_calendar
                                .ShiftCalendars
                                .Single(sc => sc.id == shift_calendar_pattern_identity.shift_calendar_id)
                                ;

            var shift_calendar_patterns = new List<ShiftCalendarPattern>();
            pattern_one = create_pattern(1, "One");
            pattern_two = create_pattern(2, "Two");
            pattern_three = create_pattern(3, "Three");
            pattern_four = create_pattern(4, "Four");
            pattern_five = create_pattern(5, "Five");
            pattern_six = create_pattern(6, "Six");

            shift_calendar_patterns.Add(pattern_one);
            shift_calendar_patterns.Add(pattern_two);
            shift_calendar_patterns.Add(pattern_three);
            shift_calendar_patterns.Add(pattern_four);
            shift_calendar_patterns.Add(pattern_five);
            shift_calendar_patterns.Add(pattern_six);
            shift_calendar.ShiftCalendarPatterns = shift_calendar_patterns;
        }

        protected ShiftCalendarPattern create_pattern(int priority, string name)
        {
            return new ShiftCalendarPatternBuilder().pattern_name(name).priority(priority).entity;
        }

        private ShiftCalendarIdentityHelper shift_calendar_identity_helper;
        private FakeOperationsCalendarRepository fake_operations_calendar_repository;

        protected ShiftCalendars.ShiftCalendar shift_calendar;
        protected OperationalCalendar operational_calendar;
        protected ShiftCalendarPattern pattern_one;
        protected ShiftCalendarPattern pattern_two;
        protected ShiftCalendarPattern pattern_three;
        protected ShiftCalendarPattern pattern_four;
        protected ShiftCalendarPattern pattern_five;
        protected ShiftCalendarPattern pattern_six;
    }
}