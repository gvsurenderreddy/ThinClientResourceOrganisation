using System.Linq;
using WorkSuite.Library.Persistence;
using WorkSuite.Library.Service.Specification.Helpers.Entity;
using WorkSuite.Library.Service.Specification.Helpers.Request;
using WorkSuite.Library.Service.Specification.Helpers.Specifications.ForResponseCommands.VerifiedByAnEntitiesState;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.Events;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.New;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.New.Create;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.Features.New {
    using OperationalCalendar = PlannedSupply.OperationsCalendars.OperationalCalendar;
    using ShiftCalendar = PlannedSupply.ShiftCalendars.ShiftCalendar;


    public class NewShiftCalendarFixture
                        : ResponseCommandVerifiedByAnEntitiesStateFixture< NewShiftCalendarRequest,
                                                                           NewShiftCalendarResponse,
                                                                           INewShiftCalendar,
                                                                           ShiftCalendar > {

        public override ShiftCalendar entity {
            get {
                Guard.IsNotNull( response, "response" );

                var operational_calendar = operations_calendar_repository
                                            .Entities
                                            .Single()
                                            ;

                var shift_calendar = operational_calendar
                                        .ShiftCalendars
                                        .Single()
                                        ;

                return shift_calendar;
            }
        }

        public Maybe<ShiftCalendarCreatedEvent> get_shift_calendar_created_event_for 
                                                    ( ShiftCalendar shift_calendar ) {

            var created_event = events_publisher
                                    .published_events
                                    .SingleOrDefault( e => e.shift_calendar_id == shift_calendar.id );

            return created_event != null 
                    ? new Just<ShiftCalendarCreatedEvent>( created_event ) as Maybe<ShiftCalendarCreatedEvent> 
                    : new Nothing<ShiftCalendarCreatedEvent>(); 
        }



        public NewShiftCalendarFixture
                       ( INewShiftCalendar the_new_shift_calendar
                       , IRequestHelper<NewShiftCalendarRequest> the_new_shift_calendar_request_builder
                       , IEntityRepository<OperationalCalendar> the_operations_calendar_repository 
                       , FakeEventPublisher<ShiftCalendarCreatedEvent> the_events_publisher )
                : base ( the_new_shift_calendar
                       , the_new_shift_calendar_request_builder ) {

            operations_calendar_repository = Guard.IsNotNull( the_operations_calendar_repository, "the_operations_calendar_repository" );
            events_publisher = Guard.IsNotNull( the_events_publisher, "the_events_publisher" );
        }

        private readonly IEntityRepository<OperationalCalendar> operations_calendar_repository;
        private readonly FakeEventPublisher<ShiftCalendarCreatedEvent> events_publisher;
    }
}