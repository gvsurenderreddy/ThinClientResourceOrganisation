using System.Linq;
using WorkSuite.Library.Persistence;
using WorkSuite.Library.Service.Specification.Helpers.Entity;
using WorkSuite.Library.Service.Specification.Helpers.Request;
using WorkSuite.Library.Service.Specification.Helpers.Specifications.ForResponseCommands.VerifiedByAnEntitiesState;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.Edit;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.Edit.Update;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.Events;
using WTS.WorkSuite.PlannedSupply.ShiftCalendarPatterns;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.ShiftCalendarPatterns.Features.Edit {

    public class UpdateShiftCalendarPatternFixture
                        : ResponseCommandVerifiedByAnEntitiesStateFixture
                            < UpdateShiftCalendarPatternRequest
                            , UpdateShiftCalendarPatternResponse
                            , IUpdateShiftCalendarPattern
                            , ShiftCalendarPattern > {


        public Maybe<UpdateShiftCalendarPatternResponse> update_response {
            get { return response.to_maybe(); }
        }

        public Maybe<ShiftCalendarPatternUpdatedEvent> get_shift_calendar_pattern_update_event_for
                                                        ( UpdateShiftCalendarPatternRequest update_shift_calendar_pattern_request ) {
            var update_event = events_publisher
                                .published_events
                                .Where(e => e.operations_calendar_id == update_shift_calendar_pattern_request.operations_calendar_id)
                                .FirstOrDefault(e => e.shift_calendar_id == update_shift_calendar_pattern_request.shift_calendar_id && e.shift_calendar_pattern_id == update_shift_calendar_pattern_request.shift_calendar_pattern_id)
                                ;

            return update_event != null
                    ? new Just<ShiftCalendarPatternUpdatedEvent>(update_event) as Maybe<ShiftCalendarPatternUpdatedEvent>
                    : new Nothing<ShiftCalendarPatternUpdatedEvent>()
                    ;
        }

        public override ShiftCalendarPattern entity {

            get {
                var operational_calendar = _operations_calendar_repository
                                            .Entities
                                            .Single(oc => oc.id == request.operations_calendar_id)
                                            ;

                var shift_calendar = operational_calendar
                                        .ShiftCalendars
                                        .Single(sc => sc.id == request.shift_calendar_id)
                                        ;

                return shift_calendar
                            .ShiftCalendarPatterns
                            .Single(scp => scp.id == request.shift_calendar_pattern_id && scp.name == request.pattern_name)
                            ;
            }
        }

        public UpdateShiftCalendarPatternFixture
                       ( IUpdateShiftCalendarPattern the_update_shift_calendar_pattern 
                       , IRequestHelper<UpdateShiftCalendarPatternRequest> the_update_shift_calendar_pattern_request_builder
                       , IEntityRepository<PlannedSupply.OperationsCalendars.OperationalCalendar> the_operations_calendar_repository )
                : base ( the_update_shift_calendar_pattern
                       , the_update_shift_calendar_pattern_request_builder ) {

            _operations_calendar_repository = Guard.IsNotNull( the_operations_calendar_repository, "the_operations_calendar_repository" );
            events_publisher = DependencyResolver.resolve<FakeEventPublisher<ShiftCalendarPatternUpdatedEvent>>();
        }

        private readonly IEntityRepository<PlannedSupply.OperationsCalendars.OperationalCalendar> _operations_calendar_repository;
        private readonly FakeEventPublisher<ShiftCalendarPatternUpdatedEvent> events_publisher;
    }
}