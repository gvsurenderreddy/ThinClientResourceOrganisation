using System;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.PlannedSupply.OperationsCalendars;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.PlannedSupply.OperationsCalendars;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.PlannedSupply.OperationsCalendars.ShiftCalendars;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.PlannedSupply.OperationsCalendars.ShiftCalendars.ShiftCalendarPatterns;
using WTS.WorkSuite.PlannedSupply.ShiftCalendarPatterns;
using WTS.WorkSuite.PlannedSupply.TimeAllocationOccurrences;
using WTS.WorkSuite.PlannedSupply.TimeAllocations;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.ShiftCalendarPatterns.ShiftOccurrence.Features
{
    public class ShiftOccurrencesFixture
    {
        public ShiftOccurrencesFixture()
        {
            operational_calendar_helper = DependencyResolver.resolve<OperationsCalendarHelper>();
            shift_calendar_helper = DependencyResolver.resolve<ShiftCalendarHelper>();
            shift_calendar_pattern_helper = DependencyResolver.resolve<ShiftCalendarPatternHelper>();

            time_allocation_first = new TimeAllocation()
            {
                colour = "12,13,14",
                start_time_in_seconds_from_midnight = 82800,
                duration_in_seconds = 21600,
                title = "A time allocation",
                id = 1
            };
            time_allocation_second = new TimeAllocation()
            {
                colour = "12,13,14",
                start_time_in_seconds_from_midnight = 25200,
                duration_in_seconds = 72000,
                title = "c time allocation",
                id = 2
            };
            time_allocation_third = new TimeAllocation()
            {
                colour = "12,13,14",
                start_time_in_seconds_from_midnight = 14400,
                duration_in_seconds = 3600,
                title = "c time allocation",
                id = 3
            };


            time_allocation_occurrence_first = new TimeAllocationOccurrence()
            {
                id = -111,
                start_date = DateTime.Now.Date,
                time_allocation = time_allocation_first
            };

            time_allocation_occurrence_second = new TimeAllocationOccurrence()
            {
                id = -222,
                start_date = DateTime.Now.Date.AddDays(1),
                time_allocation = time_allocation_second
            };

            time_allocation_occurrence_third = new TimeAllocationOccurrence()
            {
                id = -333,
                start_date = DateTime.Now.Date.AddDays(2),
                time_allocation = time_allocation_third
            };
            time_allocation_occurrence_forth = new TimeAllocationOccurrence()
            {
                id = -444,
                start_date = DateTime.Now.Date.AddDays(2),
                time_allocation = time_allocation_second
            };
            time_allocation_occurrence_fifth = new TimeAllocationOccurrence()
            {
                id = -555,
                start_date = DateTime.Now.Date.AddDays(2),
                time_allocation = time_allocation_third
            };

            shift_calendar_pattern_A = shift_calendar_pattern_helper
                                      .add()
                                      .pattern_name("Shift calendar pattern A")
                                      .number_of_resources(1)
                                      .priority(1)
                                      .add_occurrence(time_allocation_occurrence_first)
                                      .add_occurrence(time_allocation_occurrence_second)
                                      .add_occurrence(time_allocation_occurrence_third)
                                      .entity
                                      ;

            shift_calendar_A = shift_calendar_helper
                                                .add()
                                                .calendar_name("Shift calendar A")
                                                .add_shift_calendar_pattern(shift_calendar_pattern_A)
                                                .entity
                                                ;


            shift_calendar_pattern_B = shift_calendar_pattern_helper
                                     .add()
                                     .pattern_name("Shift calendar pattern B")
                                     .number_of_resources(1)
                                     .priority(1)
                                     .entity
                                     ;
            shift_calendar_B = shift_calendar_helper
                                    .add()
                                    .calendar_name("Shift calendar B")
                                    .add_shift_calendar_pattern(shift_calendar_pattern_B)
                                    .entity
                                    ;


            shift_calendar_pattern_C = shift_calendar_pattern_helper
                                     .add()
                                     .pattern_name("Shift calendar pattern C")
                                     .number_of_resources(1)
                                     .priority(1)
                                     .add_occurrence(time_allocation_occurrence_fifth)
                                     .entity
                                     ;

            shift_calendar_C = shift_calendar_helper
                                    .add()
                                    .calendar_name("Shift calendar C")
                                    .add_shift_calendar_pattern(shift_calendar_pattern_C)
                                    .entity
                                    ;


            shift_calendar_pattern_D = shift_calendar_pattern_helper
                                   .add()
                                   .pattern_name("Shift calendar pattern D")
                                   .number_of_resources(1)
                                   .priority(1)
                                   .add_occurrence(time_allocation_occurrence_forth)
                                   .entity
                                   ;

            shift_calendar_D = shift_calendar_helper
                                    .add()
                                    .calendar_name("Shift calendar D")
                                    .add_shift_calendar_pattern(shift_calendar_pattern_D)
                                    .entity
                                    ;
            operational_calendar = operational_calendar_helper
                                   .add()
                                   .calendar_name("An operations calendar")
                                   .add_shift_calendar(shift_calendar_A)
                                   .add_shift_calendar(shift_calendar_B)
                                   .add_shift_calendar(shift_calendar_C)
                                   .add_shift_calendar(shift_calendar_D)
                                   .add_time_allocation(time_allocation_first)
                                   .add_time_allocation(time_allocation_second)
                                   .entity
                                   ;            
        }

        private readonly OperationsCalendarHelper operational_calendar_helper;
        private readonly ShiftCalendarHelper shift_calendar_helper;
        private readonly ShiftCalendarPatternHelper shift_calendar_pattern_helper;

        public OperationalCalendar operational_calendar;
        public ShiftCalendars.ShiftCalendar shift_calendar_A;
        public ShiftCalendars.ShiftCalendar shift_calendar_B;
        public ShiftCalendars.ShiftCalendar shift_calendar_C;
        public ShiftCalendars.ShiftCalendar shift_calendar_D;
        public ShiftCalendarPattern shift_calendar_pattern_A;
        public ShiftCalendarPattern shift_calendar_pattern_B;
        public ShiftCalendarPattern shift_calendar_pattern_C;
        public ShiftCalendarPattern shift_calendar_pattern_D;
        public TimeAllocation time_allocation_first;
        public TimeAllocation time_allocation_second;
        public TimeAllocation time_allocation_third;
        public TimeAllocationOccurrence time_allocation_occurrence_first;
        public TimeAllocationOccurrence time_allocation_occurrence_second;
        public TimeAllocationOccurrence time_allocation_occurrence_third;
        public TimeAllocationOccurrence time_allocation_occurrence_forth;
        public TimeAllocationOccurrence time_allocation_occurrence_fifth;
    }
}