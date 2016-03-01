using System.Linq;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.Remove
{
    public class GetRemoveShiftCalendarPatternRequest
                        : IGetRemoveShiftCalendarPatternRequest
    {
        public Response<RemoveShiftCalendarPatternRequest> execute(ShiftCalendarPatternIdentity request)
        {
            OperationsCalendars.OperationalCalendar operational_calendar = _operational_calendar_repository
                                                                                                .Entities
                                                                                                .Single(oc => oc.id == request.operations_calendar_id)
                                                                                                ;

            ShiftCalendars.ShiftCalendar shift_calendar = operational_calendar
                                                                            .ShiftCalendars
                                                                            .Single(sc => sc.id == request.shift_calendar_id)
                                                                            ;

            ShiftCalendarPatterns.ShiftCalendarPattern shift_calendar_pattern = shift_calendar
                                                                                    .ShiftCalendarPatterns
                                                                                    .Single(scp => scp.id == request.shift_calendar_pattern_id)
                                                                                    ;

            var remove_request_response = new Response<RemoveShiftCalendarPatternRequest>
                                                    {
                                                        result = new RemoveShiftCalendarPatternRequest
                                                                        {
                                                                            operations_calendar_id = operational_calendar.id,
                                                                            shift_calendar_id = shift_calendar.id,
                                                                            shift_calendar_pattern_id = shift_calendar_pattern.id,
                                                                            pattern_name = shift_calendar_pattern.name,
                                                                            number_of_resources = shift_calendar_pattern.number_of_resources
                                                                        }
                                                    };

            return remove_request_response;
        }

        public GetRemoveShiftCalendarPatternRequest(IEntityRepository<OperationsCalendars.OperationalCalendar> the_operational_calendar_repository)
        {
            _operational_calendar_repository = Guard.IsNotNull(the_operational_calendar_repository, "the_operational_calendar_repository");
        }

        private readonly IEntityRepository<OperationsCalendars.OperationalCalendar> _operational_calendar_repository;
    }
}