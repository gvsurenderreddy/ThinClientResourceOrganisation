

using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral.Events;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.Events;

namespace WTS.WorkSuite.Allocation.OperationCalendars.New {

    public class CreateOperationCalendarOnOperationsCalendarCreatedEvent
                    : IEventSubscriber<OperationCalendarCreatedEvent> {

        public void handle 
                        ( OperationCalendarCreatedEvent the_event_to_handle ) {

            // create a new operation calendar
            var operation_calendar = new AllocatedOperationCalendar {
                id = the_event_to_handle.operations_calendar_id
            };

            // add it to the repository
            operation_calendar_repository.add( operation_calendar );

            unit_of_work.Commit();
        }

        public CreateOperationCalendarOnOperationsCalendarCreatedEvent 
                ( IEntityRepository<AllocatedOperationCalendar> the_operation_calendar_repository 
                , IUnitOfWork the_unit_of_work ) {

            operation_calendar_repository = Guard.IsNotNull( the_operation_calendar_repository, "the_operation_calendar_repository" );
            unit_of_work = Guard.IsNotNull( the_unit_of_work, "the_unit_of_work" );
        }

        private readonly IEntityRepository<AllocatedOperationCalendar> operation_calendar_repository;
        private readonly IUnitOfWork unit_of_work;
    }
}