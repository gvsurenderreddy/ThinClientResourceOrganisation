using System.Linq;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral.Events;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.Events;

namespace WTS.WorkSuite.Allocation.OperationCalendars.ShiftCalendars.Update {


    /// <summary>
    ///  Updates the allocated shift calendar when it receives a
    /// shift calendar updated event.
    /// </summary>
    public class UpdateShiftCalendarOnShiftCalendarUpdatedEvent
                    : IEventSubscriber<ShiftCalendarUpdatedEvent> {

        public void handle 
                        ( ShiftCalendarUpdatedEvent update_event ) {

            Guard.IsNotNull( update_event, "update_event" );

            shift_calendar_for( update_event )
                .Match( 

                    has_value: shift_caledar => {
                        shift_caledar.calendar_name = update_event.calendar_name;

                        unit_of_work.Commit();
                    },
                                       
                    nothing: () => {
                        // Improve: will need to change once we have decided what to do if the resource does not exist.
                    }
                );     
        }

        private Maybe<AllocatedShiftCalendar> shift_calendar_for
                                                ( ShiftCalendarIdentity idenity ) {

            return operation_calendar_repository
                    .Entities
                    .Where(  oc => oc.id == idenity .operations_calendar_id )
                    .SelectMany( oc => oc.shift_calendars )
                    .SingleOrDefault( sc => sc.id == idenity .shift_calendar_id )
                    .to_maybe()
                    ;            
        }

        public UpdateShiftCalendarOnShiftCalendarUpdatedEvent 
                ( IEntityRepository<AllocatedOperationCalendar> the_operation_calendar_repository 
                , IUnitOfWork the_unit_of_work ) {

            operation_calendar_repository = Guard.IsNotNull( the_operation_calendar_repository , "the_operation_calendar_repository" );
            unit_of_work = Guard.IsNotNull( the_unit_of_work, "the_unit_of_work" );
        }

        private readonly IEntityRepository<AllocatedOperationCalendar> operation_calendar_repository;
        private readonly IUnitOfWork unit_of_work;
    }
}