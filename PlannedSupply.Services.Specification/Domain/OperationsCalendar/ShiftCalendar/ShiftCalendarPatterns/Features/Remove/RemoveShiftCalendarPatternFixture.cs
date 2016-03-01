using System.Linq;
using WorkSuite.Library.Service.Specification.Helpers.Entity;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.Events;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.Remove;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.PlannedSupply.OperationsCalendars.ShiftCalendars.ShiftCalendarPatterns;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.ShiftCalendarPatterns.Features.Remove
{
    public class RemoveShiftCalendarPatternFixture
    {
        public ShiftCalendarPatternIdentity request
        {
            get
            {
                return _shift_calendar_pattern_identity;
            }
        }

        public Maybe<RemoveShiftCalendarPatternResponse> response
        {
            get;
            private set;
        }

        public void execute_command(ShiftCalendarPatternIdentity the_shift_calendar_pattern_identity)
        {
            _shift_calendar_pattern_identity = the_shift_calendar_pattern_identity;
            if (_shift_calendar_pattern_identity == null)
                _shift_calendar_pattern_identity = shift_calendar_pattern_identity_helper.get_identity();

            response = command.execute(request).to_maybe();
        }

        public Maybe<ShiftCalendarPatternRemovedEvent> get_shift_calendar_pattern_removed_event_for
                                                    (ShiftCalendarPatternIdentity request)
        {
            var update_event = events_publisher
                                .published_events
                                .Where(e => e.operations_calendar_id == request.operations_calendar_id)
                                .FirstOrDefault(e => e.shift_calendar_id == request.shift_calendar_id && e.shift_calendar_pattern_id == request.shift_calendar_pattern_id)
                                ;

            return update_event != null
                    ? new Just<ShiftCalendarPatternRemovedEvent>(update_event) as Maybe<ShiftCalendarPatternRemovedEvent>
                    : new Nothing<ShiftCalendarPatternRemovedEvent>()
                    ;
        }

        public Maybe<ShiftCalendarPatternAutoReorderedEvent> get_last_shift_calendar_pattern_auto_reordered_event_for(ShiftCalendarIdentity the_shift_calendar_identity)
        {
            var reordered_address_event = _event_publisher_auto_reordered_event
                                            .published_events
                                            .Where(e => e.operations_calendar_id == the_shift_calendar_identity.operations_calendar_id)
                                            .LastOrDefault(e => e.shift_calendar_id == the_shift_calendar_identity.shift_calendar_id)
                                            ;

            return reordered_address_event != null
                        ? new Just<ShiftCalendarPatternAutoReorderedEvent>(reordered_address_event) as Maybe<ShiftCalendarPatternAutoReorderedEvent>
                        : new Nothing<ShiftCalendarPatternAutoReorderedEvent>()
                        ;
        }

        public RemoveShiftCalendarPatternFixture()
        {
            this.response = new Nothing<RemoveShiftCalendarPatternResponse>();
            shift_calendar_pattern_identity_helper = DependencyResolver.resolve<ShiftCalendarPatternIdentityHelper>();

            command = DependencyResolver.resolve<IRemoveShiftCalendarPattern>();
            events_publisher = DependencyResolver.resolve<FakeEventPublisher<ShiftCalendarPatternRemovedEvent>>();
            _event_publisher_auto_reordered_event = DependencyResolver.resolve<FakeEventPublisher<ShiftCalendarPatternAutoReorderedEvent>>();
        }

        private ShiftCalendarPatternIdentityHelper shift_calendar_pattern_identity_helper;
        private IRemoveShiftCalendarPattern command;
        private FakeEventPublisher<ShiftCalendarPatternRemovedEvent> events_publisher;
        private FakeEventPublisher<ShiftCalendarPatternAutoReorderedEvent> _event_publisher_auto_reordered_event;
        private ShiftCalendarPatternIdentity _shift_calendar_pattern_identity;
    }
}