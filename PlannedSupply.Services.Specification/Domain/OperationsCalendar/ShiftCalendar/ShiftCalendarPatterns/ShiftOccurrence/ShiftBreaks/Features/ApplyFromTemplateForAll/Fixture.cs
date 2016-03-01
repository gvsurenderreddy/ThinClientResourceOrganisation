using System.Collections.Generic;
using System.Linq;
using WorkSuite.Library.Persistence;
using WorkSuite.Library.Service.Specification.Helpers.Request;
using WorkSuite.Library.Service.Specification.Helpers.Specifications.ForResponseCommands.VerifiedByAnEntitiesState;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.Breaks;
using WTS.WorkSuite.PlannedSupply.BreakTemplates;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.AggregateRoot;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence.ShiftBreaks.ApplyFromTemplate;
using WTS.WorkSuite.PlannedSupply.OperationsCalendars;
using WTS.WorkSuite.PlannedSupply.TimeAllocationOccurrences;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.ShiftCalendarPatterns.ShiftOccurrence.ShiftBreaks.Features.ApplyFromTemplateForAll
{
    public class ApplyShiftBreaksFromBreakTemplateForAllFixture : ResponseCommandVerifiedByAnEntitiesStateFixture<ApplyShiftBreaksFromBreakTemplateRequest,
                                                                                                                ApplyShiftBreaksFromBreakTemplateResponse,
                                                                                                                IApplyShiftBreaksFromBreakTemplateForAllOccurrences,
                                                                                                                TimeAllocationOccurrence>
    {

        public override TimeAllocationOccurrence entity
        {
            get
            {
                Guard.IsNotNull(response, "response");

                var operational_calendar = operations_calendar_repository
                                                                    .Entities
                                                                    .Single(e => e.id == response.result
                                                                                                .operations_calendar_id)
                                                                    ;

                var shift_calendar = operational_calendar
                                                    .ShiftCalendars
                                                    .Single(e => e.id == response.result
                                                                                    .shift_calendar_id)
                                                    ;

                var shift_calendar_pattern = shift_calendar
                                                    .ShiftCalendarPatterns
                                                    .Single(e => e.id == response.result
                                                                                .shift_calendar_pattern_id)
                                                    ;

                return shift_calendar_pattern
                            .TimeAllocationOccurrences
                            .Single(e => e.id == response.result
                                                        .shift_occurrence_id);
            }
        }

        public void ensure_break_template_has_a_total_duration_longer_than_the_shift()
        {
            var shift_duration = get_shift_occurrenc.execute(request).time_allocation.duration_in_seconds;
            var break_template = break_template_repository.Entities.Single(bt => bt.id == request.break_template_id);

            break_template.all_breaks = new HashSet<Break>()
            {
                new Break()
                {
                     id = -999,
                     offset_from_start_time_in_seconds = 0,
                     duration_in_seconds = shift_duration + 60,//Adding a minute to make it longer than the shift.
                }
            };
        }

        public virtual void contaminate_internal_shift_details()
        {
            //Improve: These seed methods are essentially the same except for a few differences
            var time_allocation =
                operations_calendar_repository
                                        .Entities
                                        .Single(e => e.id == request.operations_calendar_id)
                                        .ShiftCalendars
                                        .SelectMany(sc => sc.ShiftCalendarPatterns
                                                            .SelectMany(scp => scp.TimeAllocationOccurrences))
                                        .Single(tao => tao.id == request.shift_occurrence_id)
                                        .time_allocation;

            time_allocation.title = "";

        }

        public ApplyShiftBreaksFromBreakTemplateForAllFixture(IApplyShiftBreaksFromBreakTemplateForAllOccurrences the_command
                                                            , IRequestHelper<ApplyShiftBreaksFromBreakTemplateRequest> the_request_helper
                                                            ,IEntityRepository<OperationalCalendar> the_operations_calendar_repository
                                                            , GetOccurrence the_get_shift_occurrence
                                                            , IEntityRepository<BreakTemplate> the_break_template_repository)

            : base(the_command, the_request_helper)
        {
            operations_calendar_repository = Guard.IsNotNull(the_operations_calendar_repository,"the_operations_calendar_repository");
            get_shift_occurrenc = Guard.IsNotNull(the_get_shift_occurrence, "the_get_shift_occurrence");
            break_template_repository = Guard.IsNotNull(the_break_template_repository, "the_break_template_repository");
        }

        private readonly IEntityRepository<OperationalCalendar> operations_calendar_repository;
        private readonly GetOccurrence get_shift_occurrenc;
        private readonly IEntityRepository<BreakTemplate> break_template_repository;
    }
}
