using Content.Services.Common.Messages;
using System.Linq;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral.Events;
using WTS.WorkSuite.Library.DomainTypes.OrderList;
using WTS.WorkSuite.Library.DomainTypes.Primitives.Validation;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.Events;
using WTS.WorkSuite.PlannedSupply.OperationsCalendars;

namespace WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.Reorder
{
    public class ReorderShiftCalendarPattern : IReorderShiftCalendarPattern
    {
        public ReorderShiftCalendarPattern(IUnitOfWork the_unit_of_work,
                                            IEntityRepository<OperationalCalendar> the_repository,
                                            Validator the_validator,
                                            IEventPublisher<ShiftCalendarPatternManualReorderedEvent> the_event_publisher_manual_reordered,
                                            IEventPublisher<ShiftCalendarPatternAutoReorderedEvent> the_event_publisher_auto_reordered
                                          )
        {
            unit_of_work = Guard.IsNotNull(the_unit_of_work, "the_unit_of_work");
            repository = Guard.IsNotNull(the_repository, "the_repository");
            validator = Guard.IsNotNull(the_validator, "the_validator");
            event_publisher_manual_reordered = Guard.IsNotNull(the_event_publisher_manual_reordered,
                                                               "the_event_publisher_manual_reordered"
                                                              );
            event_publisher_auto_reordered = Guard.IsNotNull(the_event_publisher_auto_reordered,
                                                             "the_event_publisher_auto_reordered"
                                                            );
        }

        public ReorderShiftCalendarPatternResponse execute(ReorderShiftCalendarPatternRequest request)
        {
            return this
                .set_request(request)
                .find_operational_calendar()
                .find_shift_calendar()
                .find_shift_calendar_pattern()
                .get_a_copy_of_all_shift_calendar_patterns()
                .create_shift_calendar_pattern_move_request()
                .validate()
                .move_shift_calendar_pattern()
                .commit()
                .publish_shift_calendar_pattern_manual_reordered_event()
                .publish_shift_calendar_pattern_auto_reordered_events()
                .build_response()
                ;
        }

        private ReorderShiftCalendarPattern set_request(ReorderShiftCalendarPatternRequest request)
        {
            reorder_shift_calendar_pattern_request = Guard.IsNotNull(request, "reorder_emergency_contact_request");
            return this;
        }

        private ReorderShiftCalendarPattern find_operational_calendar()
        {
            if (response_builder.has_errors) return this;

            operational_calendar = repository
                                    .Entities
                                    .Single(e => e.id == reorder_shift_calendar_pattern_request
                                                                                            .operations_calendar_id);
            return this;
        }

        private ReorderShiftCalendarPattern find_shift_calendar()
        {
            if (response_builder.has_errors) return this;

            shift_calendar = operational_calendar
                                    .ShiftCalendars
                                    .Single(e => e.id == reorder_shift_calendar_pattern_request
                                                                                            .shift_calendar_id);
            return this;
        }

        private ReorderShiftCalendarPattern find_shift_calendar_pattern()
        {
            if (response_builder.has_errors) return this;

            Guard.IsNotNull(operational_calendar, "operational_calendar");

            shift_calendar_pattern = shift_calendar
                                    .ShiftCalendarPatterns
                                    .Single(ec => ec.id == reorder_shift_calendar_pattern_request
                                                                                                .shift_calendar_pattern_id);
            return this;
        }

        private ReorderShiftCalendarPattern get_a_copy_of_all_shift_calendar_patterns()
        {
            if (response_builder.has_errors) return this;

            Guard.IsNotNull(shift_calendar, "shift_calendar");
            Guard.IsNotNull(shift_calendar.ShiftCalendarPatterns, "shift_calendar.ShiftCalendarPatterns");

            cached_shift_calendar_patterns = new ShiftCalendarPatternPriority[shift_calendar.ShiftCalendarPatterns.Count];

            int count = 0;
            foreach (ShiftCalendarPatterns.ShiftCalendarPattern pattern in shift_calendar.ShiftCalendarPatterns)
            {
                cached_shift_calendar_patterns[count] = new ShiftCalendarPatternPriority { pattern_id = pattern.id, priority = pattern.priority };
                count++;
            }

            cached_shift_calendar_patterns.OrderBy(a => a.priority);

            return this;
        }

        private ReorderShiftCalendarPattern create_shift_calendar_pattern_move_request()
        {
            if (response_builder.has_errors) return this;

            Guard.IsNotNull(shift_calendar_pattern, "shift_calendar_pattern");

            move_request = new MoveIndexEntryRequest
            {
                @from = shift_calendar_pattern.priority,
                to = reorder_shift_calendar_pattern_request.priority
            };
            return this;
        }

        private ReorderShiftCalendarPattern validate()
        {
            if (response_builder.has_errors) return this;

            validator
                .field("priority")
                .premise_holds(move_request.to >= 1, ValidationMessages.error_03_0007)
                .premise_holds(move_request.to <= shift_calendar.ShiftCalendarPatterns.Count(), ValidationMessages.error_03_0008);

            response_builder.add_errors(validator.errors);
            return this;
        }

        private ReorderShiftCalendarPattern move_shift_calendar_pattern()
        {
            if (response_builder.has_errors) return this;

            Guard.IsNotNull(move_request, "_moveRequest");

            var to_index_mapper = new ListEntryIndexMapper<ShiftCalendarPatterns.ShiftCalendarPattern>
                                            (m => m.priority,
                                                (m, value) => m.priority = value
                                            );
            shift_calendar
                .ShiftCalendarPatterns
                .Select(to_index_mapper.map)
                .Move(move_request)
                ;
            return this;
        }

        private ReorderShiftCalendarPattern commit()
        {
            if (response_builder.has_errors) return this;

            unit_of_work.Commit();
            return this;
        }

        private ReorderShiftCalendarPattern publish_shift_calendar_pattern_manual_reordered_event()
        {
            if (response_builder.has_errors) return this;

            Guard.IsNotNull(operational_calendar, "operational_calendar");
            Guard.IsNotNull(shift_calendar, "shift_calendar");
            Guard.IsNotNull(shift_calendar_pattern, "shift_calendar_pattern");

            event_publisher_manual_reordered.publish(new ShiftCalendarPatternManualReorderedEvent
                                                            {
                                                                operations_calendar_id = operational_calendar.id,
                                                                shift_calendar_id = shift_calendar.id,
                                                                shift_calendar_pattern_id = shift_calendar_pattern.id,
                                                                name = shift_calendar_pattern.name,
                                                                number_of_resources = shift_calendar_pattern.number_of_resources,
                                                                priority = shift_calendar_pattern.priority
                                                            });

            return this;
        }

        private ReorderShiftCalendarPattern publish_shift_calendar_pattern_auto_reordered_events()
        {
            if (response_builder.has_errors) return this;

            Guard.IsNotNull(operational_calendar, "operational_calendar");
            Guard.IsNotNull(shift_calendar, "shift_calendar");
            Guard.IsNotNull(shift_calendar_pattern, "shift_calendar_pattern");
            Guard.IsNotNull(cached_shift_calendar_patterns, "cached_shift_calendar_patterns");

            foreach (ShiftCalendarPatternPriority pattern in cached_shift_calendar_patterns)
            {
                if (move_request.from == move_request.to) break; // re-ordered to the same position, therefore no need to raise any auto reordered events.

                if (pattern.pattern_id == shift_calendar_pattern.id) continue; // a manual reordered event has been raised already for the shift calendar pattern re-ordered.

                var the_othershift_calendar_pattern = shift_calendar.ShiftCalendarPatterns.Single(scp => scp.id == pattern.pattern_id); // Get the updated copy of the other shift calendar pattern.

                if (pattern.priority == the_othershift_calendar_pattern.priority) continue; // if there is no priority change made for the other shift calendar pattern, there is no need to trigger an auto reordered event.

                event_publisher_auto_reordered.publish(new ShiftCalendarPatternAutoReorderedEvent
                                                            {
                                                                operations_calendar_id = operational_calendar.id,
                                                                shift_calendar_id = shift_calendar.id,
                                                                shift_calendar_pattern_id = the_othershift_calendar_pattern.id,
                                                                name = the_othershift_calendar_pattern.name,
                                                                number_of_resources = the_othershift_calendar_pattern.number_of_resources,
                                                                priority = the_othershift_calendar_pattern.priority
                                                            });
            }

            return this;
        }

        private ReorderShiftCalendarPatternResponse build_response()
        {
            if (!response_builder.has_errors)
            {
                response_builder.add_message(
                            ValidationMessages.reorder_was_successfull(move_request.from,
                                                                        move_request.to
                                                                      )
                                            );
            }

            return response_builder.build();
        }

        private readonly IUnitOfWork unit_of_work;
        private readonly IEntityRepository<OperationalCalendar> repository;
        private readonly Validator validator;
        private readonly ResponseBuilder<ReorderShiftCalendarPatternResponse> response_builder = new ResponseBuilder<ReorderShiftCalendarPatternResponse>();
        private OperationalCalendar operational_calendar;
        private ShiftCalendars.ShiftCalendar shift_calendar;
        private ShiftCalendarPatterns.ShiftCalendarPattern shift_calendar_pattern;
        private ReorderShiftCalendarPatternRequest reorder_shift_calendar_pattern_request;
        private MoveIndexEntryRequest move_request;
        private ShiftCalendarPatternPriority[] cached_shift_calendar_patterns;
        private readonly IEventPublisher<ShiftCalendarPatternManualReorderedEvent> event_publisher_manual_reordered;
        private readonly IEventPublisher<ShiftCalendarPatternAutoReorderedEvent> event_publisher_auto_reordered;
    }

    public class ShiftCalendarPatternPriority
    {
        public int pattern_id { get; set; }

        public int priority { get; set; }
    }
}