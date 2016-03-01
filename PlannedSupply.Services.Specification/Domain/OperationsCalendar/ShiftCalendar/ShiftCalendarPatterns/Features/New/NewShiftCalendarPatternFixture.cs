using System.Linq;
using WorkSuite.Library.Persistence;
using WorkSuite.Library.Service.Specification.Helpers.Entity;
using WorkSuite.Library.Service.Specification.Helpers.Request;
using WorkSuite.Library.Service.Specification.Helpers.Specifications.ForResponseCommands.VerifiedByAnEntitiesState;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.Events;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.New;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.New.Create;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.PlannedSupply.OperationsCalendars.ShiftCalendars.ShiftCalendarPatterns;
using WTS.WorkSuite.PlannedSupply.ShiftCalendarPatterns;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.ShiftCalendarPatterns.Features.New
{
    public class NewShiftCalendarPatternFixture
                        : ResponseCommandVerifiedByAnEntitiesStateFixture<NewShiftCalendarPatternRequest,
                                                                            NewShiftCalendarPatternResponse,
                                                                            INewShiftCalendarPattern,
                                                                            ShiftCalendarPattern
                                                                         >
    {
        public NewShiftCalendarPatternRequest create_new_request
        {
            get
            {
                return new NewShiftCalendarPatternRequest
                {
                    operations_calendar_id = _shift_calendar_identity.operations_calendar_id,
                    shift_calendar_id = _shift_calendar_identity.shift_calendar_id,
                    pattern_name = "SHIFT calendar pattern b",
                    number_of_resources = "2"
                };
            }
        }

        public Maybe<NewShiftCalendarPatternResponse> create_new_response
        {
            get;
            private set;
        }

        public virtual void execute_command(ShiftCalendarIdentity the_shift_calendar_identity)
        {
            _shift_calendar_identity = the_shift_calendar_identity;
            if (_shift_calendar_identity == null)
                _shift_calendar_identity = shift_calendar_pattern_identity_helper.get_identity();

            create_new_response = command.execute(create_new_request).to_maybe();
        }

        public Maybe<ShiftCalendarPatternCreatedEvent> get_shift_calendar_pattern_created_event_for
                                                    (NewShiftCalendarPatternRequest request)
        {
            var update_event = events_publisher
                                .published_events
                                .Where(e => e.operations_calendar_id == request.operations_calendar_id)
                                .LastOrDefault(e => e.shift_calendar_id == request.shift_calendar_id && e.name == request.pattern_name)
                                ;

            return update_event != null
                    ? new Just<ShiftCalendarPatternCreatedEvent>(update_event) as Maybe<ShiftCalendarPatternCreatedEvent>
                    : new Nothing<ShiftCalendarPatternCreatedEvent>()
                    ;
        }

        public Maybe<ShiftCalendarPatternAutoReorderedEvent> get_last_shift_calendar_pattern_auto_reordered_event_for(ShiftCalendarIdentity the_shift_calendar_identity)
        {
            var reordered_address_event = _event_publisher_auto_reordered_event
                                            .published_events
                                            .Where(e => e.operations_calendar_id == the_shift_calendar_identity.operations_calendar_id)
                                            .LastOrDefault(e => e.shift_calendar_id == the_shift_calendar_identity.shift_calendar_id)
                                            ;

            return reordered_address_event != null
                        ? new Just<ShiftCalendarPatternAutoReorderedEvent>(reordered_address_event) as Maybe<ShiftCalendarPatternAutoReorderedEvent>
                        : new Nothing<ShiftCalendarPatternAutoReorderedEvent>()
                        ;
        }

        public override ShiftCalendarPattern entity
        {
            get
            {
                Guard.IsNotNull(request, "request");

                OperationsCalendars.OperationalCalendar operational_calendar = _operations_calendar_repository
                                                                                    .Entities
                                                                                    .Single(oc => oc.id == request.operations_calendar_id)
                                                                                    ;

                ShiftCalendars.ShiftCalendar shift_calendar = operational_calendar
                                                                    .ShiftCalendars
                                                                    .Single(sc => sc.id == request.shift_calendar_id)
                                                                    ;

                ShiftCalendarPattern shift_calendar_pattern = shift_calendar
                                                                    .ShiftCalendarPatterns
                                                                    .Single(scp => scp.id == request.shift_calendar_pattern_id)
                                                                    ;

                return shift_calendar_pattern;
            }
        }

        public NewShiftCalendarPatternFixture(INewShiftCalendarPattern the_new_shift_calendar_pattern,
                                                IRequestHelper<NewShiftCalendarPatternRequest> the_new_shift_calendar_pattern_request,
                                                IEntityRepository<OperationsCalendars.OperationalCalendar> the_operations_calendar_repository
                                             )
            : base(the_new_shift_calendar_pattern,
                    the_new_shift_calendar_pattern_request
                  )
        {
            _operations_calendar_repository = Guard.IsNotNull(the_operations_calendar_repository,
                                                                "the_operations_calendar_repository"
                                                             );

            this.create_new_response = new Nothing<NewShiftCalendarPatternResponse>();
            shift_calendar_pattern_identity_helper = DependencyResolver.resolve<ShiftCalendarPatternIdentityHelper>();

            command = DependencyResolver.resolve<INewShiftCalendarPattern>();
            events_publisher = DependencyResolver.resolve<FakeEventPublisher<ShiftCalendarPatternCreatedEvent>>();
            _event_publisher_auto_reordered_event = DependencyResolver.resolve<FakeEventPublisher<ShiftCalendarPatternAutoReorderedEvent>>();
        }

        private readonly IEntityRepository<OperationsCalendars.OperationalCalendar> _operations_calendar_repository;

        private INewShiftCalendarPattern command;
        private ShiftCalendarPatternIdentityHelper shift_calendar_pattern_identity_helper;
        private FakeEventPublisher<ShiftCalendarPatternCreatedEvent> events_publisher;
        private FakeEventPublisher<ShiftCalendarPatternAutoReorderedEvent> _event_publisher_auto_reordered_event;
        private ShiftCalendarIdentity _shift_calendar_identity;
    }
}