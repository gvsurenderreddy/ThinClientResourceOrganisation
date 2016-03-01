using System.Linq;
using WorkSuite.Library.Persistence;
using WorkSuite.Library.Service.Specification.Helpers.Request;
using WorkSuite.Library.Service.Specification.Helpers.Specifications.ForResponseCommands;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence.ShiftBreaks.Remove;
using WTS.WorkSuite.PlannedSupply.OperationsCalendars;
using WTS.WorkSuite.PlannedSupply.TimeAllocationBreaks;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.ShiftCalendarPatterns.ShiftOccurrence.ShiftBreaks.Features.RemoveShiftBreakForAll
{
    public class RemoveShiftBreakForAllOccurrencesFixture : ResponseCommandFixture<RemoveShiftBreakRequest, RemoveShiftBreakResponse, IRemoveShiftBreakForAllOccurrences>
    {

        public TimeAllocationBreak entity
        {
            get
            {
                Guard.IsNotNull(request, "response");

                var operational_calendar = operations_calendar_repository
                                                                    .Entities
                                                                    .Single(e => e.id == request.operations_calendar_id)
                                                                    ;


                return operational_calendar.TimeAllocations
                                            .SelectMany(ta => ta.TimeAllocationBreaks)
                                            .SingleOrDefault(tb => tb.id == request.shift_break_id);
            }
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

        public RemoveShiftBreakForAllOccurrencesFixture(IRemoveShiftBreakForAllOccurrences the_command, 
                                                        IRequestHelper<RemoveShiftBreakRequest> the_request,
                                                        IEntityRepository<OperationalCalendar> the_operations_calendar_repository)

            : base(the_command, the_request)
        {
            operations_calendar_repository = Guard.IsNotNull(the_operations_calendar_repository,"the_operations_calendar_repository");
        }

        private readonly IEntityRepository<OperationalCalendar> operations_calendar_repository;
    }
}
