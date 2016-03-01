using System.Linq;
using WorkSuite.Library.Persistence;
using WorkSuite.Library.Service.Specification.Helpers.Request;
using WorkSuite.Library.Service.Specification.Helpers.Specifications.ForResponseCommands.VerifiedByAnEntitiesState;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.AggregateRoot;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence.ShiftBreaks.New;
using WTS.WorkSuite.PlannedSupply.OperationsCalendars;
using WTS.WorkSuite.PlannedSupply.TimeAllocationBreaks;
using WTS.WorkSuite.PlannedSupply.TimeAllocationOccurrences;
using WTS.WorkSuite.PlannedSupply.TimeAllocations;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.ShiftCalendarPatterns.ShiftOccurrence.ShiftBreaks.Features.NewShiftBreakForAll
{
    public class NewShiftBreakForAllFixture : ResponseCommandVerifiedByAnEntitiesStateFixture<NewShiftBreakRequest,
                                                                                        NewShiftBreakResponse,
                                                                                        INewShiftBreakForAllOccurrences,
                                                                                        TimeAllocationOccurrence>
    {

        public override TimeAllocationOccurrence entity
        {
            get
            {
                Guard.IsNotNull(response, "response");

                var operational_calendar = operations_calendar_repository
                                                                    .Entities
                                                                    .Single(e => e.id == response.result
                                                                                                .operations_calendar_id)
                                                                    ;


                return
                    operational_calendar
                    .ShiftCalendars
                    .SelectMany(sc => sc.ShiftCalendarPatterns
                                        .SelectMany(p => p.TimeAllocationOccurrences)).Single(oc => oc.id == request.shift_occurrence_id);

            }
        }

        public void clear_any_existing_breaks_on(TimeAllocation time_allocation)
        {
            time_allocation.TimeAllocationBreaks.Clear();
        }

        public TimeAllocation get_backing_time_allocation_for_request()
        {
            return get_shift_occurrenc.execute(request).time_allocation;
        }

        public virtual void contaminate_internal_shift_details()
        {
            //Improve: These seed methods are essentially the same except for a few differences
            var time_allocation =
                operations_calendar_repository
                                        .Entities
                                        .Single(e => e.id == request.operations_calendar_id)
                                        .ShiftCalendars
                                        .SelectMany(sc => sc.ShiftCalendarPatterns
                                                            .SelectMany(scp => scp.TimeAllocationOccurrences))
                                        .Single(tao => tao.id == request.shift_occurrence_id)
                                        .time_allocation;

            time_allocation.title = "";

        }
        public NewShiftBreakForAllFixture(INewShiftBreakForAllOccurrences the_command, 
                                            IRequestHelper<NewShiftBreakRequest> the_request,
                                            IEntityRepository<OperationalCalendar> the_operations_calendar_repository,
                                            GetOccurrence the_get_shift_occurrence)

            : base(the_command, the_request)
        {
            operations_calendar_repository = Guard.IsNotNull(the_operations_calendar_repository,"the_operations_calendar_repository");
            get_shift_occurrenc = Guard.IsNotNull(the_get_shift_occurrence, "the_get_shift_occurrence");
        }

        private readonly IEntityRepository<OperationalCalendar> operations_calendar_repository;
        private readonly GetOccurrence get_shift_occurrenc;
    }
}
