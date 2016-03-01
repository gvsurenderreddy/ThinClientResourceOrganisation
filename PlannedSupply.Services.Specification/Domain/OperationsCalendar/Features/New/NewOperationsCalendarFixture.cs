using System.Linq;
using WorkSuite.Library.Persistence;
using WorkSuite.Library.Service.Specification.Helpers.Entity;
using WorkSuite.Library.Service.Specification.Helpers.Request;
using WorkSuite.Library.Service.Specification.Helpers.Specifications.ForResponseCommands.VerifiedByAnEntitiesState;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.Events;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.New;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.New.Create;
using WTS.WorkSuite.PlannedSupply.OperationsCalendars;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.Features.New
{
    public class NewOperationsCalendarFixture
                        : ResponseCommandVerifiedByAnEntitiesStateFixture< NewOperationsCalendarRequest,
                                                                           NewOperationsCalendarResponse,
                                                                           INewOperationsCalendar,
                                                                           OperationalCalendar > {

        public override OperationalCalendar entity {

            get {
                Guard.IsNotNull(response, "response");

                return _operations_calendar_repository
                                .Entities
                                .Single()
                                ;
            }
        }

        public Maybe<OperationCalendarCreatedEvent> get_operation_calendar_created_event_for 
                        ( OperationalCalendar operationalCalendar ) {

            var created_event = events_publisher
                                    .published_events
                                    .SingleOrDefault( e => e.operations_calendar_id == operationalCalendar.id )
                                    ;

            return created_event != null 
                    ? new Just<OperationCalendarCreatedEvent>( created_event ) as Maybe<OperationCalendarCreatedEvent>
                    : new Nothing<OperationCalendarCreatedEvent>()
                    ;
        }


        public NewOperationsCalendarFixture
                       ( INewOperationsCalendar the_new_operations_calendar
                       , IRequestHelper<NewOperationsCalendarRequest> the_new_operations_calendar_request_builder
                       , IEntityRepository<OperationalCalendar> the_operations_calendar_repository 
                       , FakeEventPublisher<OperationCalendarCreatedEvent> the_events_publisher )
                : base ( the_new_operations_calendar
                       , the_new_operations_calendar_request_builder ) {

            _operations_calendar_repository = Guard.IsNotNull( the_operations_calendar_repository, "the_operations_calendar_repository" );
            events_publisher = Guard.IsNotNull( the_events_publisher, "the_events_publisher" );
        }

        private readonly IEntityRepository<OperationalCalendar> _operations_calendar_repository;
        private readonly FakeEventPublisher<OperationCalendarCreatedEvent> events_publisher;
    }
}