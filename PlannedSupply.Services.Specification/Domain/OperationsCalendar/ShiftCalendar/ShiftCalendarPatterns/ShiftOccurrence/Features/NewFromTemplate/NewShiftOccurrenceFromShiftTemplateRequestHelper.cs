using System;
using WorkSuite.Library.Service.Specification.Helpers.Request;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.DomainTypes.Colour;
using WTS.WorkSuite.Library.DomainTypes.Duration;
using WTS.WorkSuite.Library.DomainTypes.Time;
using WTS.WorkSuite.PlannedSupply.BreakTemplates;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence.NewFromTemplate;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.BreakTemplates;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.BreakTemplates.Breaks;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.PlannedSupply.OperationsCalendars;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.PlannedSupply.OperationsCalendars.ShiftCalendars;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.PlannedSupply.OperationsCalendars.ShiftCalendars.ShiftCalendarPatterns;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.ShiftTemplates;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.ShiftCalendarPatterns.ShiftOccurrence.Features.NewFromTemplate
{
    public class NewShiftOccurrenceFromShiftTemplateRequestHelper : IRequestHelper<NewShiftOccurrenceFromShiftTemplateRequest>
    {

        public NewShiftOccurrenceFromShiftTemplateRequest given_a_valid_request()
        {
            var shift_calendar_pattern = shift_calendar_pattern_helper
                                                                .add()
                                                                .pattern_name("Shift calendar pattern A")
                                                                .number_of_resources(1)
                                                                .priority(1)
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
                                    .entity
                                    ;

            var shift_template = create_shift_template();
            


            return new NewShiftOccurrenceFromShiftTemplateRequest
            {
                operations_calendar_id = operational_calendar.id,
                shift_calendar_id = shift_calendar.id,
                shift_calendar_pattern_id = shift_calendar_pattern.id,
                start_date = DateTime.Now.AddMonths(2).Date,
                shift_template_id = shift_template.id
            };
        }

        private PlannedSupply.ShiftTemplates.ShiftTemplate create_shift_template()
        {

            var break_template = create_break_template();


            var duration_request = new DurationRequest() { hours = "23", minutes = "0" };
            var duration_in_second = Convert.ToInt32(duration_request.hours) * 60 * 60 +
                                     Convert.ToInt32(duration_request.minutes) * 60;

            return shift_template_helper
                               .add()
                               .shift_title("6:00-17:00")
                               .start_time(new TimeRequest() { hours = "1", minutes = "0" })
                               .duration(duration_in_second.to_duration_request())
                               .colour(new RgbColour(25, 24, 28))
                               .break_template(break_template)
                               .entity
                               ;
        }

        private BreakTemplate create_break_template()
        {

            var a_break = break_helper.add()
                                        .off_set_in_seconds(0)
                                        .duration_in_seconds(60)
                                        .is_paid(true)
                                        .entity;

            return break_template_helper
                                        .add()
                                        .template_name("A break template")
                                        .add_break(a_break)
                                        .entity
                                        ;

        }

        public NewShiftOccurrenceFromShiftTemplateRequestHelper(OperationsCalendarHelper the_operational_calendar_helper
                                                                , ShiftCalendarHelper the_shift_calendar_helper
                                                                , ShiftCalendarPatternHelper the_shift_calendar_pattern_helper
                                                                , ShiftTemplatehelper the_shift_template_helper
                                                                , BreakTemplateHelper the_break_template_helper
                                                                , BreakHelper the_break_helper)
        {
            operational_calendar_helper = Guard.IsNotNull(the_operational_calendar_helper, "the_operational_calendar_helper");
            shift_calendar_helper = Guard.IsNotNull(the_shift_calendar_helper, "the_shift_calendar_helper");
            shift_calendar_pattern_helper = Guard.IsNotNull(the_shift_calendar_pattern_helper, "the_shift_calendar_pattern_helper");
            shift_template_helper = Guard.IsNotNull(the_shift_template_helper, "the_shift_template_helper");

            break_template_helper = Guard.IsNotNull(the_break_template_helper, "the_break_template_helper");

            break_helper = Guard.IsNotNull(the_break_helper, "the_break_helper");
        }

        private readonly OperationsCalendarHelper operational_calendar_helper;
        private readonly ShiftCalendarHelper shift_calendar_helper;
        private readonly ShiftCalendarPatternHelper shift_calendar_pattern_helper;
        private readonly ShiftTemplatehelper shift_template_helper;
        private readonly BreakTemplateHelper break_template_helper;
        private readonly BreakHelper break_helper;
    }
}
