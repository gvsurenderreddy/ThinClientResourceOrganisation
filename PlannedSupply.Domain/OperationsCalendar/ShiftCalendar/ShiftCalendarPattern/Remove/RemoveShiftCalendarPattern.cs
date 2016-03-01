using Content.Services.PlannedSupply.Messages;
using System.Linq;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral.Events;
using WTS.WorkSuite.Library.DomainTypes.OrderList;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.Events;
using WTS.WorkSuite.PlannedSupply.OperationsCalendars;

namespace WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.Remove
{
    public class RemoveShiftCalendarPattern
                        : IRemoveShiftCalendarPattern
    {
        public RemoveShiftCalendarPatternResponse execute(ShiftCalendarPatternIdentity the_remove_shift_calendar_pattern_request)
        {
            return this
                .set_request(the_remove_shift_calendar_pattern_request)
                .find_operational_calendar()
                .find_shift_calendar()
                .find_shift_calendar_pattern()
                .create_shift_calendar_removed_event()
                .identify_the_priority_of_the_shift_calendar_pattern_to_be_removed()
                .remove_shift_calendar_pattern()
                .commit()
                .publish_shift_calendar_pattern_removed_event()
                .publish_shift_calendar_pattern_auto_reordered_events()
                .build_response()
                ;
        }

        private RemoveShiftCalendarPattern set_request(ShiftCalendarPatternIdentity the_remove_shift_calendar_pattern_request)
        {
            _remove_shift_calendar_pattern_request = Guard.IsNotNull(the_remove_shift_calendar_pattern_request,
                                                                    "the_remove_shift_calendar_pattern_request"
                                                                    );

            _remove_shift_calendar_pattern_response_builder = new ResponseBuilder<RemoveShiftCalendarPatternResponse>();

            return this;
        }

        private RemoveShiftCalendarPattern find_operational_calendar()
        {
            if (response_builder_has_errors()) return this;

            Guard.IsNotNull(_remove_shift_calendar_pattern_request, "_remove_shift_calendar_pattern_request");
            Guard.IsNotNull(_operational_calendar_repository, "_operational_calendar_repository");

            _operational_calendar = _operational_calendar_repository
                                            .Entities
                                            .Single(oc => oc.id == _remove_shift_calendar_pattern_request.operations_calendar_id)
                                            ;

            return this;
        }

        private RemoveShiftCalendarPattern find_shift_calendar()
        {
            if (response_builder_has_errors()) return this;

            Guard.IsNotNull(_remove_shift_calendar_pattern_request, "_remove_shift_calendar_pattern_request");
            Guard.IsNotNull(_operational_calendar, "_operational_calendar");
            Guard.IsNotNull(_operational_calendar.ShiftCalendars, "_operational_calendar.all_shift_calendars");

            _shift_calendar = _operational_calendar
                                    .ShiftCalendars
                                    .Single(sc => sc.id == _remove_shift_calendar_pattern_request.shift_calendar_id)
                                    ;

            return this;
        }

        private RemoveShiftCalendarPattern find_shift_calendar_pattern()
        {
            if (response_builder_has_errors()) return this;

            Guard.IsNotNull(_remove_shift_calendar_pattern_request, "_remove_shift_calendar_pattern_request");
            Guard.IsNotNull(_shift_calendar, "_shift_calendar");
            Guard.IsNotNull(_shift_calendar.ShiftCalendarPatterns, "_shift_calendar.all_shift_calendar_patterns");

            _shift_calendar_pattern_to_be_removed = _shift_calendar
                                                        .ShiftCalendarPatterns
                                                        .Single(scp => scp.id == _remove_shift_calendar_pattern_request.shift_calendar_pattern_id)
                                                        ;

            return this;
        }

        private RemoveShiftCalendarPattern create_shift_calendar_removed_event()
        {
            if (response_builder_has_errors()) return this;

            Guard.IsNotNull(_operational_calendar, "_operational_calendar");
            Guard.IsNotNull(_shift_calendar, "_shift_calendar");
            Guard.IsNotNull(_shift_calendar_pattern_to_be_removed, "_shift_calendar_pattern_to_be_removed");

            shift_calendar_pattern_removed_event = new ShiftCalendarPatternRemovedEvent
            {
                operations_calendar_id = _operational_calendar.id,
                shift_calendar_id = _shift_calendar.id,
                shift_calendar_pattern_id = _shift_calendar_pattern_to_be_removed.id,
                name = _shift_calendar_pattern_to_be_removed.name,
                number_of_resources = _shift_calendar_pattern_to_be_removed.number_of_resources,
                priority = _shift_calendar_pattern_to_be_removed.priority
            };

            return this;
        }

        private RemoveShiftCalendarPattern identify_the_priority_of_the_shift_calendar_pattern_to_be_removed()
        {
            if (response_builder_has_errors()) return this;

            Guard.IsNotNull(_shift_calendar_pattern_to_be_removed, "_shift_calendar_pattern_to_be_removed");

            priority_of_the_pattern_to_be_removed = _shift_calendar_pattern_to_be_removed.priority;

            return this;
        }

        private RemoveShiftCalendarPattern remove_shift_calendar_pattern()
        {
            if (response_builder_has_errors()) return this;

            if (_shift_calendar == null) return this;
            if (_shift_calendar_pattern_to_be_removed == null) return this;

            Guard.IsNotNull(_shift_calendar, "_shift_calendar");
            Guard.IsNotNull(_shift_calendar_pattern_to_be_removed, "_shift_calendar_pattern_to_be_removed");

            var index_entry_mapper = new ListEntryIndexMapper<ShiftCalendarPatterns.ShiftCalendarPattern>
                                            (a => a.priority
                                            , (a, value) => a.priority = value);

            _shift_calendar
                .ShiftCalendarPatterns
                .Select(index_entry_mapper.map)
                .Remove(index_entry_mapper.map(_shift_calendar_pattern_to_be_removed)
                       , () =>
                       {
                           _shift_calendar
                                    .ShiftCalendarPatterns
                                    .Remove(_shift_calendar_pattern_to_be_removed);

                           _operational_calendar_repository
                                                    .remove(_shift_calendar_pattern_to_be_removed);
                       });

            return this;
        }

        private RemoveShiftCalendarPattern commit()
        {
            if (response_builder_has_errors()) return this;

            _unit_of_work.Commit();

            return this;
        }

        private RemoveShiftCalendarPattern publish_shift_calendar_pattern_removed_event()
        {
            if (response_builder_has_errors()) return this;

            Guard.IsNotNull(_shift_calendar_pattern_removed_event_publisher,
                            "_shift_calendar_pattern_removed_event_publisher"
                           );
            Guard.IsNotNull(shift_calendar_pattern_removed_event, "shift_calendar_pattern_removed_event");

            _shift_calendar_pattern_removed_event_publisher.publish(shift_calendar_pattern_removed_event);

            return this;
        }

        private RemoveShiftCalendarPattern publish_shift_calendar_pattern_auto_reordered_events()
        {
            if (response_builder_has_errors()) return this;

            Guard.IsNotNull(_operational_calendar, "_operational_calendar");
            Guard.IsNotNull(_shift_calendar, "_shift_calendar");
            Guard.IsNotNull(shift_calendar_pattern_removed_event, "shift_calendar_pattern_removed_event");
            Guard.IsNotNull(_shift_calendar.ShiftCalendarPatterns, "_shift_calendar.ShiftCalendarPatterns");
            Guard.IsNotNull(priority_of_the_pattern_to_be_removed, "priority_of_the_pattern_to_be_removed");
            Guard.IsNotNull(event_publisher_auto_reordered, "event_publisher_auto_reordered");

            foreach (ShiftCalendarPatterns.ShiftCalendarPattern pattern in _shift_calendar.ShiftCalendarPatterns)
            {
                if (pattern.priority < priority_of_the_pattern_to_be_removed) continue; // there is no need to trigger an auto reorder event for the for shift calendar pattern that are not affected.

                event_publisher_auto_reordered.publish(new ShiftCalendarPatternAutoReorderedEvent
                {
                    operations_calendar_id = _operational_calendar.id,
                    shift_calendar_id = _shift_calendar.id,
                    shift_calendar_pattern_id = pattern.id,
                    name = pattern.name,
                    number_of_resources = pattern.number_of_resources,
                    priority = pattern.priority
                });
            }

            return this;
        }

        private RemoveShiftCalendarPatternResponse build_response()
        {
            if (response_builder_has_errors() == false)
            {
                _remove_shift_calendar_pattern_response_builder.add_message(ConfirmationMessages.confirmation_04_0028);
            }

            return _remove_shift_calendar_pattern_response_builder.build();
        }

        private bool response_builder_has_errors()
        {
            return _remove_shift_calendar_pattern_response_builder.has_errors;
        }

        public RemoveShiftCalendarPattern(IEntityRepository<OperationalCalendar> the_operational_calendar_repository,
                                            IUnitOfWork the_unit_of_work,
                                            IEventPublisher<ShiftCalendarPatternRemovedEvent> the_shift_calendar_pattern_removed_event_publisher,
                                            IEventPublisher<ShiftCalendarPatternAutoReorderedEvent> the_event_publisher_auto_reordered
                                         )
        {
            _operational_calendar_repository = Guard.IsNotNull(the_operational_calendar_repository,
                                                                "the_operational_calendar_repository"
                                                              );
            _unit_of_work = Guard.IsNotNull(the_unit_of_work,
                                            "the_unit_of_work"
                                           );
            _shift_calendar_pattern_removed_event_publisher = Guard.IsNotNull(the_shift_calendar_pattern_removed_event_publisher,
                                                                              "the_shift_calendar_pattern_removed_event_publisher"
                                                                             );
            event_publisher_auto_reordered = Guard.IsNotNull(the_event_publisher_auto_reordered,
                                                             "the_event_publisher_auto_reordered"
                                                            );
        }

        private OperationalCalendar _operational_calendar;
        private ShiftCalendars.ShiftCalendar _shift_calendar;
        private ShiftCalendarPatterns.ShiftCalendarPattern _shift_calendar_pattern_to_be_removed;
        private ShiftCalendarPatternIdentity _remove_shift_calendar_pattern_request;
        private ResponseBuilder<RemoveShiftCalendarPatternResponse> _remove_shift_calendar_pattern_response_builder;
        private ShiftCalendarPatternRemovedEvent shift_calendar_pattern_removed_event;
        private int priority_of_the_pattern_to_be_removed;

        private readonly IEntityRepository<OperationalCalendar> _operational_calendar_repository;
        private readonly IUnitOfWork _unit_of_work;
        private readonly IEventPublisher<ShiftCalendarPatternRemovedEvent> _shift_calendar_pattern_removed_event_publisher;
        private readonly IEventPublisher<ShiftCalendarPatternAutoReorderedEvent> event_publisher_auto_reordered;
    }
}