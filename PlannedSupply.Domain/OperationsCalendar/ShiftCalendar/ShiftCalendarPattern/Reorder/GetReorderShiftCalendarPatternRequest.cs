using System.Linq;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.OperationsCalendars;

namespace WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.Reorder
{
    public class GetReorderShiftCalendarPatternRequest : IGetReorderShiftCalendarPatternRequest
    {

        public Response<ReorderShiftCalendarPatternDetails> execute(ReorderShiftCalendarPatternRequest request)
        {
            var operational_calendar = operational_calendar_repository
                                                                    .Entities
                                                                    .Single(oc => oc.id == request
                                                                                            .operations_calendar_id);

            var shift_calendar = operational_calendar
                                                .ShiftCalendars
                                                .Single(sc => sc.id == request.shift_calendar_id);

            var shift_calendar_pattern = shift_calendar
                                                    .ShiftCalendarPatterns
                                                    .Single(scp => scp.id == request.shift_calendar_pattern_id);


            return new Response<ReorderShiftCalendarPatternDetails>
            {
                result = new ReorderShiftCalendarPatternDetails
                {
                    operations_calendar_id = operational_calendar.id,
                    shift_calendar_id = shift_calendar.id,
                    shift_calendar_pattern_id = shift_calendar_pattern.id,
                    shift_calendar_pattern_name = shift_calendar_pattern.name,
                    number_of_resources = shift_calendar_pattern.number_of_resources,
                    current_priority = shift_calendar_pattern.priority,
                    priority = request.priority,
                    resource_allocation_summary = shift_calendar_pattern.ResourceAllocations.Count()
                }
            };
        }

        public GetReorderShiftCalendarPatternRequest(IEntityRepository<OperationalCalendar> the_operational_calendar_repository)
        {
            operational_calendar_repository = Guard.IsNotNull(the_operational_calendar_repository, "the_operational_calendar_repository");
        }

        private readonly IEntityRepository<OperationalCalendar> operational_calendar_repository;
    }
}