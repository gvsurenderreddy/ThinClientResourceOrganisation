using System.Linq;
using WorkSuite.Library.Persistence;
using WorkSuite.Library.Service.Specification.Helpers.Entity;
using WorkSuite.Library.Service.Specification.Helpers.Request;
using WorkSuite.Library.Service.Specification.Helpers.Specifications.ForResponseCommands.VerifiedByAnEntitiesState;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.Edit;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.Edit.Update;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.Events;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.Features.Edit {

    using OperationalCalendar = PlannedSupply.OperationsCalendars.OperationalCalendar;
    using ShiftCalendar = PlannedSupply.ShiftCalendars.ShiftCalendar;

    public class UpdateShiftCalendarFixture
                        : ResponseCommandVerifiedByAnEntitiesStateFixture<UpdateShiftCalendarRequest,
                                                                           UpdateShiftCalendarResponse,
                                                                           IUpdateShiftCalendar,
                                                                           ShiftCalendar> {

        public Maybe<UpdateShiftCalendarResponse> update_response {
            get { return response.to_maybe(); }
        }

        public Maybe<ShiftCalendarUpdatedEvent> get_shift_calendar_update_event_for
                                                    ( UpdateShiftCalendarRequest update_shift_calendar_request ) {

            var update_event = events_publisher
                                .published_events
                                .Where(e => e.operations_calendar_id == update_shift_calendar_request.operations_calendar_id )
                                .FirstOrDefault(e => e.shift_calendar_id == update_shift_calendar_request.shift_calendar_id )
                                ;

            return update_event != null
                    ? new Just<ShiftCalendarUpdatedEvent>(update_event) as Maybe<ShiftCalendarUpdatedEvent>
                    : new Nothing<ShiftCalendarUpdatedEvent>()
                    ;
        }

        public override ShiftCalendar entity {

            get {
                var operational_calendar = operation_calendar_repository
                                            .Entities
                                            .Single(oc => oc.id == request.operations_calendar_id)
                                            ;

                return operational_calendar
                                .ShiftCalendars
                                .Single(sc => sc.id == request.shift_calendar_id && sc.calendar_name == request.calendar_name)
                                ;
            }
        }

        public UpdateShiftCalendarFixture
                       ( IUpdateShiftCalendar the_update_operations_calendar
                       , IRequestHelper<UpdateShiftCalendarRequest> the_update_operations_calendar_request_builder
                       , IEntityRepository<OperationalCalendar> the_operations_calendar_repository )
                : base ( the_update_operations_calendar
                       , the_update_operations_calendar_request_builder ) {

            operation_calendar_repository = Guard.IsNotNull(the_operations_calendar_repository, "the_operations_calendar_repository");
            events_publisher = DependencyResolver.resolve<FakeEventPublisher<ShiftCalendarUpdatedEvent>>();
        }

        private readonly IEntityRepository<OperationalCalendar> operation_calendar_repository;
        private readonly FakeEventPublisher<ShiftCalendarUpdatedEvent> events_publisher;
    }
}