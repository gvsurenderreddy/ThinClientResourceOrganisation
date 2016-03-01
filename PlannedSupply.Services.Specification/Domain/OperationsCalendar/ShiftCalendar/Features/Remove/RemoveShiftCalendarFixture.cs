using System.Linq;
using WorkSuite.Library.Service.Specification.Helpers.Entity;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.Events;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.Remove;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.PlannedSupply.OperationsCalendars.ShiftCalendars;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.Features.Remove
{
    public class RemoveShiftCalendarFixture
    {
        public ShiftCalendarIdentity request
        {
            get
            {
                return shift_calendar_identity_helper.get_identity();
            }
        }

        public Maybe<RemoveShiftCalendarResponse> response
        {
            get;
            private set;
        }

        public void execute_command()
        {
            response = command.execute(request).to_maybe();
        }

        public Maybe<ShiftCalendarRemovedEvent> get_shift_calendar_removed_event_for
                                                    (ShiftCalendarIdentity request)
        {
            var update_event = events_publisher
                                .published_events
                                .Where(e => e.operations_calendar_id == request.operations_calendar_id)
                                .FirstOrDefault(e => e.shift_calendar_id == request.shift_calendar_id)
                                ;

            return update_event != null
                    ? new Just<ShiftCalendarRemovedEvent>(update_event) as Maybe<ShiftCalendarRemovedEvent>
                    : new Nothing<ShiftCalendarRemovedEvent>()
                    ;
        }

        public RemoveShiftCalendarFixture()
        {
            this.response = new Nothing<RemoveShiftCalendarResponse>();
            shift_calendar_identity_helper = DependencyResolver.resolve<ShiftCalendarIdentityHelper>();

            command = DependencyResolver.resolve<IRemoveShiftCalendar>();
            events_publisher = DependencyResolver.resolve<FakeEventPublisher<ShiftCalendarRemovedEvent>>();
        }

        private IRemoveShiftCalendar command;
        private ShiftCalendarIdentityHelper shift_calendar_identity_helper;
        private FakeEventPublisher<ShiftCalendarRemovedEvent> events_publisher;
    }
}