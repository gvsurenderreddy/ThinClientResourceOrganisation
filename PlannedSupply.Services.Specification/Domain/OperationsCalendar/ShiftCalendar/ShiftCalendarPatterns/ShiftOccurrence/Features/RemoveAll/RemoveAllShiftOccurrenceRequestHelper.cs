using System;
using WorkSuite.Library.Service.Specification.Helpers.Request;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.PlannedSupply.OperationsCalendars;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.PlannedSupply.OperationsCalendars.ShiftCalendars;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.PlannedSupply.OperationsCalendars.ShiftCalendars.ShiftCalendarPatterns;
using WTS.WorkSuite.PlannedSupply.TimeAllocationOccurrences;
using WTS.WorkSuite.PlannedSupply.TimeAllocations;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.ShiftCalendarPatterns.ShiftOccurrence.Features.RemoveAll
{

    public class RemoveAllShiftOccurrenceRequestHelper : IRequestHelper < ShiftOccurrenceIdentity>
    {
        public ShiftOccurrenceIdentity given_a_valid_request()
        {
            var time_allocation_first= new TimeAllocation()
            {
                colour = "12,13,14",
                duration_in_seconds = 40,
                start_time_in_seconds_from_midnight = 60,
                title = "A time allocation",
                id = 1
            };

            var time_allocation_second = new TimeAllocation()
            {
                colour = "12,13,14",
                duration_in_seconds = 40,
                start_time_in_seconds_from_midnight = 60,
                title = "c time allocation",
                id = 2
            };
           
            var time_allocation_occurrence_first = new TimeAllocationOccurrence()
            {
                id = -111,
                start_date = DateTime.Now.Date,
                time_allocation =time_allocation_first
            };

            var time_allocation_occurrence_second = new TimeAllocationOccurrence()
            {
                id = -222,
                start_date = DateTime.Now.Date,
                time_allocation = time_allocation_first
            };

            var time_allocation_occurrence_third= new TimeAllocationOccurrence()
            {
                id = -333,
                start_date = DateTime.Now.Date,
                time_allocation = time_allocation_second
            };

            var shift_calendar_pattern_A =shift_calendar_pattern_helper
                                      .add()
                                      .pattern_name("Shift calendar pattern A")
                                      .number_of_resources(1)
                                      .priority(1)
                                      .add_occurrence(time_allocation_occurrence_first )
                                      .add_occurrence(time_allocation_occurrence_second)
                                      .entity
                                      ;

            var shift_calendar_A = shift_calendar_helper
                                                .add()
                                                .calendar_name("Shift calendar A")
                                                .add_shift_calendar_pattern(shift_calendar_pattern_A)
                                                .entity
                                                ;
           

            var shift_calendar_pattern_B = shift_calendar_pattern_helper
                                     .add()
                                     .pattern_name("Shift calendar pattern B")
                                     .number_of_resources(1)
                                     .priority(1)
                                     .entity
                                     ;
            var shift_calendar_B= shift_calendar_helper
                                    .add()
                                    .calendar_name("Shift calendar B")
                                    .add_shift_calendar_pattern(shift_calendar_pattern_B)
                                    .entity
                                    ;


            var shift_calendar_pattern_C = shift_calendar_pattern_helper
                                     .add()
                                     .pattern_name("Shift calendar pattern C")
                                     .number_of_resources(1)
                                     .priority(1)
                                     .add_occurrence(time_allocation_occurrence_third)
                                     .entity
                                     ;

            var shift_calendar_C = shift_calendar_helper
                                    .add()
                                    .calendar_name("Shift calendar C")
                                    .add_shift_calendar_pattern(shift_calendar_pattern_C)
                                    .entity
                                    ;


            var shift_calendar_pattern_D = shift_calendar_pattern_helper
                                   .add()
                                   .pattern_name("Shift calendar pattern D")
                                   .number_of_resources(1)
                                   .priority(1)
                                   .add_occurrence(time_allocation_occurrence_first)
                                      .add_occurrence(time_allocation_occurrence_second)
                                   .entity
                                   ;

            var shift_calendar_D = shift_calendar_helper
                                    .add()
                                    .calendar_name("Shift calendar D")
                                    .add_shift_calendar_pattern(shift_calendar_pattern_D)
                                    .entity
                                    ;
            var operational_calendar = operational_calendar_helper
                                   .add()
                                   .calendar_name("An operations calendar")
                                   .add_shift_calendar(shift_calendar_A)
                                   .add_shift_calendar(shift_calendar_B)
                                   .add_shift_calendar(shift_calendar_C)
                                   .add_shift_calendar(shift_calendar_D)
                                   .entity
                                   ;
            

           return new ShiftOccurrenceIdentity
           {
               operations_calendar_id = operational_calendar.id,
               shift_calendar_id = shift_calendar_A.id,
               shift_calendar_pattern_id = shift_calendar_pattern_A.id,
               shift_occurrence_id = time_allocation_occurrence_first.id
           };

        }

        public RemoveAllShiftOccurrenceRequestHelper ( OperationsCalendarHelper the_operational_calendar_helper
                                                     , ShiftCalendarHelper the_shift_calendar_helper
                                                     , ShiftCalendarPatternHelper the_shift_calendar_pattern_helper)
        {
            operational_calendar_helper = Guard.IsNotNull(the_operational_calendar_helper, "the_operational_calendar_helper");
            shift_calendar_helper = Guard.IsNotNull(the_shift_calendar_helper, "the_shift_calendar_helper");
            shift_calendar_pattern_helper = Guard.IsNotNull(the_shift_calendar_pattern_helper, "the_shift_calendar_pattern_helper"); 
        }

        private readonly OperationsCalendarHelper operational_calendar_helper;
        private readonly ShiftCalendarHelper shift_calendar_helper;
        private readonly ShiftCalendarPatternHelper shift_calendar_pattern_helper;
    }
}