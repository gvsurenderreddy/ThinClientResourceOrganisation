using System.Collections;
using System.Collections.Generic;
using WorkSuite.Library.Service.Specification.Helpers.Persistence;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.Allocation.OperationCalendars;
using WTS.WorkSuite.Allocation.OperationCalendars.New;
using WTS.WorkSuite.Allocation.Services.Helpers.Domain.OperationCalendars;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.Events;

namespace WTS.WorkSuite.Allocation.Services.Domain.OperationCalendars.Events.Created {

    
    public class OperationCalendarCreatedFixture {

        public CreateOperationCalendarOnOperationsCalendarCreatedEvent event_handler { get; private set; }

        public OperationCalendarCreatedEvent create_event () {

            return new OperationCalendarCreatedEvent {
                operations_calendar_id = next_id++,
            };
        }

        public bool changes_were_commited () {
            return unit_of_work.commit_was_called;
        }


        public IEnumerable<AllocatedOperationCalendar> all_operation_calendars {
            get { return operation_calendar_repository.Entities; }
        }



        public OperationCalendarCreatedFixture () {

            event_handler = DependencyResolver.resolve<CreateOperationCalendarOnOperationsCalendarCreatedEvent>();
            operation_calendar_repository = DependencyResolver.resolve<FakeOperationCalendarRepository>();
            unit_of_work = DependencyResolver.resolve<FakeUnitOfWork>();
        }

        private int next_id = 0;
        private readonly FakeOperationCalendarRepository operation_calendar_repository;
        private readonly FakeUnitOfWork unit_of_work;

    }
}