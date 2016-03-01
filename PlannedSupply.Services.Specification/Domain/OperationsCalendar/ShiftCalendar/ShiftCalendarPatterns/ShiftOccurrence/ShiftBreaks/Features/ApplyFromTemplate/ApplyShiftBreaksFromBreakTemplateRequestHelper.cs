using System;
using WorkSuite.Library.Service.Specification.Helpers.Request;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.BreakTemplates;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence.ShiftBreaks.ApplyFromTemplate;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.BreakTemplates;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.BreakTemplates.Breaks;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.PlannedSupply.OperationsCalendars;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.PlannedSupply.OperationsCalendars.ShiftCalendars;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.PlannedSupply.OperationsCalendars.ShiftCalendars.ShiftCalendarPatterns;
using WTS.WorkSuite.PlannedSupply.TimeAllocationOccurrences;
using WTS.WorkSuite.PlannedSupply.TimeAllocations;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.ShiftCalendarPatterns.ShiftOccurrence.ShiftBreaks.Features.ApplyFromTemplate
{
    public class ApplyShiftBreaksFromBreakTemplateRequestHelper : IRequestHelper<ApplyShiftBreaksFromBreakTemplateRequest>
    {
        public ApplyShiftBreaksFromBreakTemplateRequest given_a_valid_request()
        {

            var time_allocation = new TimeAllocation()
            {
                colour = "12,13,14",
                duration_in_seconds = 3600*24,
                start_time_in_seconds_from_midnight = 60,
                title = "A time allocation"
            };

            var time_allocation_occurrence = new TimeAllocationOccurrence()
            {
                id = -112,
                start_date = DateTime.Now.Date,
                time_allocation = time_allocation
            };

            var time_allocation_occurrence_2 = new TimeAllocationOccurrence()
            {
                id = -111,
                start_date = DateTime.Now.Date,
                time_allocation = time_allocation
            };

            var shift_calendar_pattern = shift_calendar_pattern_helper
                                                                .add()
                                                                .pattern_name("Shift calendar pattern A")
                                                                .number_of_resources(1)
                                                                .priority(1)
                                                                .add_occurrence(time_allocation_occurrence)
                                                                .add_occurrence(time_allocation_occurrence_2)
                                                                .entity
                                                                ;


            var shift_calendar = shift_calendar_helper
                                                .add()
                                                .calendar_name("Shift calendar A")
                                                .add_shift_calendar_pattern(shift_calendar_pattern)
                                                .entity
                                                ;




            var operational_calendar = operational_calendar_helper
                                    .add()
                                    .calendar_name("An operations calendar")
                                    .add_shift_calendar(shift_calendar)
                                    .add_time_allocation(time_allocation)
                                    .entity
                                    ;


            var break_template = create_break_template();


            return new ApplyShiftBreaksFromBreakTemplateRequest()
            {
                operations_calendar_id = operational_calendar.id,
                shift_calendar_id = shift_calendar.id,
                shift_calendar_pattern_id = shift_calendar_pattern.id,
                shift_occurrence_id = time_allocation_occurrence.id,
                break_template_id = break_template.id
            };
        }

        private BreakTemplate create_break_template()
        {

            var a_break = break_helper.add()
                                        .off_set_in_seconds(3600)
                                        .duration_in_seconds(3600)
                                        .is_paid(true)
                                        .entity;

            return break_template_helper
                                        .add()
                                        .template_name("A break template")
                                        .add_break(a_break)
                                        .entity
                                        ;

        }


        public ApplyShiftBreaksFromBreakTemplateRequestHelper(OperationsCalendarHelper the_operational_calendar_helper
                                                                , ShiftCalendarHelper the_shift_calendar_helper
                                                                , ShiftCalendarPatternHelper the_shift_calendar_pattern_helper
                                                                , BreakTemplateHelper the_break_template_helper
                                                                , BreakHelper the_break_helper)
        {
            operational_calendar_helper = Guard.IsNotNull(the_operational_calendar_helper, "the_operational_calendar_helper");
            shift_calendar_helper = Guard.IsNotNull(the_shift_calendar_helper, "the_shift_calendar_helper");
            shift_calendar_pattern_helper = Guard.IsNotNull(the_shift_calendar_pattern_helper, "the_shift_calendar_pattern_helper");

            break_template_helper = Guard.IsNotNull(the_break_template_helper, "the_break_template_helper");
            break_helper = Guard.IsNotNull(the_break_helper, "the_break_helper");
        }


        private readonly OperationsCalendarHelper operational_calendar_helper;
        private readonly ShiftCalendarHelper shift_calendar_helper;
        private readonly ShiftCalendarPatternHelper shift_calendar_pattern_helper;

        private readonly BreakTemplateHelper break_template_helper;
        private readonly BreakHelper break_helper;
    }
}
