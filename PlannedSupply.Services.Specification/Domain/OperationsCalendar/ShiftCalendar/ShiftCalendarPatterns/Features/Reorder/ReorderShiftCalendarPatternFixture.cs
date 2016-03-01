using System.Linq;
using WorkSuite.Library.Service.Specification.Helpers.Entity;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.Events;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.Reorder;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.ShiftCalendarPatterns.Features.Reorder
{
    public class ReorderShiftCalendarPatternFixture
    {
        public ReorderShiftCalendarPatternRequest request
        {
            get
            {
                Guard.IsNotNull(shift_calendar_pattern_to_be_reordered, "shift_calendar_pattern_to_be_reordered");

                return new ReorderShiftCalendarPatternRequest
                            {
                                operations_calendar_id = shift_calendar_pattern_to_be_reordered.operations_calendar_id,
                                shift_calendar_id = shift_calendar_pattern_to_be_reordered.shift_calendar_id,
                                shift_calendar_pattern_id = shift_calendar_pattern_to_be_reordered.shift_calendar_pattern_id,
                                priority = reordered_to_position
                            };
            }
        }

        public Maybe<ReorderShiftCalendarPatternResponse> response
        {
            get;
            private set;
        }

        public void execute_command(ShiftCalendarPatternIdentity the_shift_calendar_pattern_to_be_reordered,
                                    int the_reorder_to_position
                                   )
        {
            shift_calendar_pattern_to_be_reordered = Guard.IsNotNull(the_shift_calendar_pattern_to_be_reordered, "the_shift_calendar_pattern_to_be_reordered");
            reordered_to_position = the_reorder_to_position;

            response = command.execute(request).to_maybe();
        }

        public Maybe<ShiftCalendarPatternManualReorderedEvent> get_last_shift_calendar_pattern_manual_reordered_event_for(ShiftCalendarPatternIdentity the_shift_calendar_pattern_identity)
        {
            var reordered_address_event = _event_publisher_manual_reordered_event
                                            .published_events
                                            .Where(e => e.operations_calendar_id == the_shift_calendar_pattern_identity.operations_calendar_id)
                                            .LastOrDefault(e => e.shift_calendar_id == the_shift_calendar_pattern_identity.shift_calendar_id &&
                                                            e.shift_calendar_pattern_id == the_shift_calendar_pattern_identity.shift_calendar_pattern_id
                                                          )
                                            ;

            return reordered_address_event != null
                        ? new Just<ShiftCalendarPatternManualReorderedEvent>(reordered_address_event) as Maybe<ShiftCalendarPatternManualReorderedEvent>
                        : new Nothing<ShiftCalendarPatternManualReorderedEvent>()
                        ;
        }

        public Maybe<ShiftCalendarPatternAutoReorderedEvent> get_last_shift_calendar_pattern_auto_reordered_event_for(ShiftCalendarPatternIdentity the_shift_calendar_pattern_identity)
        {
            var reordered_address_event = _event_publisher_auto_reordered_event
                                            .published_events
                                            .Where(e => e.operations_calendar_id == the_shift_calendar_pattern_identity.operations_calendar_id)
                                            .LastOrDefault(e => e.shift_calendar_id == the_shift_calendar_pattern_identity.shift_calendar_id)
                                            ;

            return reordered_address_event != null
                        ? new Just<ShiftCalendarPatternAutoReorderedEvent>(reordered_address_event) as Maybe<ShiftCalendarPatternAutoReorderedEvent>
                        : new Nothing<ShiftCalendarPatternAutoReorderedEvent>()
                        ;
        }

        public ReorderShiftCalendarPatternFixture()
        {
            this.response = new Nothing<ReorderShiftCalendarPatternResponse>();
            _event_publisher_manual_reordered_event = DependencyResolver.resolve<FakeEventPublisher<ShiftCalendarPatternManualReorderedEvent>>();
            _event_publisher_auto_reordered_event = DependencyResolver.resolve<FakeEventPublisher<ShiftCalendarPatternAutoReorderedEvent>>();

            command = DependencyResolver.resolve<IReorderShiftCalendarPattern>();
        }

        private IReorderShiftCalendarPattern command;
        private FakeEventPublisher<ShiftCalendarPatternManualReorderedEvent> _event_publisher_manual_reordered_event;
        private FakeEventPublisher<ShiftCalendarPatternAutoReorderedEvent> _event_publisher_auto_reordered_event;

        private ShiftCalendarPatternIdentity shift_calendar_pattern_to_be_reordered;
        private int reordered_to_position;
    }
}