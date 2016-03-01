using WorkSuite.Library.Service.Specification.Helpers.Persistence;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.Allocation.OperationCalendars;
using WTS.WorkSuite.Allocation.OperationCalendars.ShiftCalendars.Update;
using WTS.WorkSuite.Allocation.Services.Helpers.Domain.OperationCalendars;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.Events;

namespace WTS.WorkSuite.Allocation.Services.Domain.OperationCalendars.ShiftCalendars.Events.Updated {

    public class ShiftCalendarUpdatedFixture {
        
        public ShiftCalendarUpdatedEvent create_event () {

            return new ShiftCalendarUpdatedEvent {
                operations_calendar_id = operation_calendar.id,
                shift_calendar_id = shift_calendar.id,
                calendar_name = shift_calendar.calendar_name,
            };
        }

        public AllocatedShiftCalendar shift_calendar {
            get {
                if (shift_calendar_ == null) {
                    shift_calendar_ = new AllocatedShiftCalendar {
                        id = 1,
                        calendar_name = "A shift calendar",
                    };

                    operation_calendar.shift_calendars.Add( shift_calendar_ );
                }
                return shift_calendar_;
            }
        }

        public UpdateShiftCalendarOnShiftCalendarUpdatedEvent event_handler { get; private set; }

        public bool changes_were_commited () {
            return unit_of_work.commit_was_called;
        }


        public ShiftCalendarUpdatedFixture () {
            event_handler = DependencyResolver.resolve<UpdateShiftCalendarOnShiftCalendarUpdatedEvent>();
            operation_calendar_repository = DependencyResolver.resolve<FakeOperationCalendarRepository>();
            unit_of_work = DependencyResolver.resolve<FakeUnitOfWork>();
        }

        private AllocatedOperationCalendar operation_calendar {
            get {
                if (operation_calendar_ == null) {

                    operation_calendar_ = new AllocatedOperationCalendar {
                        id = 1,
                    };
                    operation_calendar_repository.add( operation_calendar_ );
                }
                return operation_calendar_;
            }
        }

        private readonly FakeOperationCalendarRepository operation_calendar_repository;
        private readonly FakeUnitOfWork unit_of_work;
        private AllocatedOperationCalendar operation_calendar_;
        private AllocatedShiftCalendar shift_calendar_;

    }
}