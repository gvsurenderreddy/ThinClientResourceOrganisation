using System.Linq;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral.Events;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.Events;

namespace WTS.WorkSuite.Allocation.OperationCalendars.ShiftCalendars.New {

    /// <summary>
    ///     When a new shift calendar is created we need to create a copy of
    /// it in the allocation bounded context.  All updates to shift calendars
    /// are performed in PlannedSupply but allocation needs to know certain 
    /// information so that it can allocate to a plan.
    /// </summary>
    public class CreateShiftCalendarOnShiftCalendarCreatedEvent
                    : IEventSubscriber<ShiftCalendarCreatedEvent>{

        public void handle 
                        ( ShiftCalendarCreatedEvent create_event ) {

            Guard.IsNotNull( create_event, "create_event" );

            operation_calendar_repository
                .GetSingle( oc => oc.id == create_event.operations_calendar_id )
                .Match(

                    has_value: operation_calendar => { 

                        operation_calendar
                            .shift_calendars
                            .Add( new AllocatedShiftCalendar {
                                id = create_event.shift_calendar_id,
                                calendar_name = create_event.calendar_name,
                            });

                        unit_of_work.Commit();                        
                    },

                    nothing: () => {
                        
                        // Improve: Needs to be changed once we have worked out what to do if the operation calendar does not exist
                    }
                );            
        }

        public CreateShiftCalendarOnShiftCalendarCreatedEvent 
                ( IEntityRepository<AllocatedOperationCalendar> the_operation_calendar_repository 
                , IUnitOfWork the_unit_of_work ) {

            operation_calendar_repository = Guard.IsNotNull( the_operation_calendar_repository, "the_operation_calendar_repository" );
            unit_of_work = Guard.IsNotNull( the_unit_of_work, "the_unit_of_work" );
        }

        private readonly IEntityRepository<AllocatedOperationCalendar> operation_calendar_repository;
        private readonly IUnitOfWork unit_of_work;
    }
}