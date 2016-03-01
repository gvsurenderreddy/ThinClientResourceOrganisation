using System.Linq;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.Remove
{
    public class GetRemoveShiftCalendarRequest
                        : IGetRemoveShiftCalendarRequest
    {
        public Response<RemoveShiftCalendarRequest> execute(ShiftCalendarIdentity request)
        {
            PlannedSupply.OperationsCalendars.OperationalCalendar operational_calendar = _operational_calendar_repository
                                                                                                .Entities
                                                                                                .Single(oc => oc.id == request.operations_calendar_id)
                                                                                                ;

            PlannedSupply.ShiftCalendars.ShiftCalendar shift_calendar = operational_calendar
                                                                            .ShiftCalendars
                                                                            .Single(sc => sc.id == request.shift_calendar_id)
                                                                            ;

            var remove_request_response = new Response<RemoveShiftCalendarRequest>
            {
                result = new RemoveShiftCalendarRequest
                {
                    shift_calendar_id = shift_calendar.id,
                    calendar_name = shift_calendar.calendar_name,
                    operations_calendar_id = request.operations_calendar_id
                }
            };
            return remove_request_response;
        }

        public GetRemoveShiftCalendarRequest(IEntityRepository<PlannedSupply.OperationsCalendars.OperationalCalendar> the_operational_calendar_repository)
        {
            _operational_calendar_repository = Guard.IsNotNull(the_operational_calendar_repository, "the_operational_calendar_repository");
        }

        private readonly IEntityRepository<PlannedSupply.OperationsCalendars.OperationalCalendar> _operational_calendar_repository;
    }
}