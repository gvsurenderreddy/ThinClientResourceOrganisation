using System.Collections;
using System.Collections.Generic;
using System.Linq;
using WorkSuite.Library.Service.Specification.Helpers.Persistence;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.Allocation.OperationCalendars;
using WTS.WorkSuite.Allocation.OperationCalendars.ShiftCalendars.New;
using WTS.WorkSuite.Allocation.Services.Helpers.Domain.OperationCalendars;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.Events;

namespace WTS.WorkSuite.Allocation.Services.Domain.OperationCalendars.ShiftCalendars.Events.Created {

    public class ShiftCalendarCreatedFixture {


        public AllocatedOperationCalendar operation_calendar {
            get {
                if ( operation_calendar_ == null ) {
                    operation_calendar_ = new AllocatedOperationCalendar {
                        id = 1
                    };
                    operation_calendar_repository.add( operation_calendar_ );
                }
                return operation_calendar_;
            }
        }

        public Maybe<AllocatedShiftCalendar> shift_caledar_for
                                                ( ShiftCalendarIdentity identity ) {
            
            var shift_calendar = operation_calendar_repository
                                    .Entities
                                    .Where( oc => oc.id == identity.operations_calendar_id   ) 
                                    .SelectMany( oc => oc.shift_calendars )
                                    .SingleOrDefault( sc => sc.id == identity.shift_calendar_id  )
                                    ;

            return shift_calendar != null
                    ? new Just<AllocatedShiftCalendar>( shift_calendar ) as Maybe<AllocatedShiftCalendar> 
                    : new Nothing<AllocatedShiftCalendar>()
                    ;

        }

        public CreateShiftCalendarOnShiftCalendarCreatedEvent event_handler { get; private set; }

        public ShiftCalendarCreatedEvent create_event () {

            return new ShiftCalendarCreatedEvent {
                operations_calendar_id = operation_calendar.id,
                shift_calendar_id = next_id++,
                calendar_name = "A calendar name",
            };
        }

        public IEnumerable<AllocatedShiftCalendar> all_shift_calendars {
            get { return operation_calendar.shift_calendars; }
        }

        public bool changes_were_commited () {
            return unit_of_work.commit_was_called;
        }


        public ShiftCalendarCreatedFixture () {
            event_handler = DependencyResolver.resolve<CreateShiftCalendarOnShiftCalendarCreatedEvent>();
            operation_calendar_repository = DependencyResolver.resolve<FakeOperationCalendarRepository>();
            unit_of_work = DependencyResolver.resolve<FakeUnitOfWork>();
        }

        private int next_id = 0;
        private readonly FakeOperationCalendarRepository operation_calendar_repository;
        private readonly FakeUnitOfWork unit_of_work;
        private AllocatedOperationCalendar operation_calendar_;

    }
}