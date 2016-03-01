using System.Linq;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.Edit.GetUpdateRequest;

namespace WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.Edit
{
    public class GetUpdateShiftCalendarRequest
                    : IGetUpdateShiftCalendarRequest
    {
        public Response<UpdateShiftCalendarRequest> execute(ShiftCalendarIdentity request)
        {
            PlannedSupply.OperationsCalendars.OperationalCalendar operational_calendar = _operational_calendar_repository
                                                                                                .Entities
                                                                                                .Single(oc => oc.id == request.operations_calendar_id)
                                                                                                ;

            PlannedSupply.ShiftCalendars.ShiftCalendar shift_calendar = operational_calendar
                                                                            .ShiftCalendars
                                                                            .Single(sc => sc.id == request.shift_calendar_id)
                                                                            ;

            return new Response<UpdateShiftCalendarRequest>
                            {
                                result = new UpdateShiftCalendarRequest
                                                    {
                                                        operations_calendar_id = operational_calendar.id,
                                                        shift_calendar_id = shift_calendar.id,
                                                        calendar_name = shift_calendar.calendar_name
                                                    }
                            };
        }

        public GetUpdateShiftCalendarRequest(IEntityRepository<PlannedSupply.OperationsCalendars.OperationalCalendar>
            the_operational_calendar_repository)
        {
            _operational_calendar_repository = Guard.IsNotNull(the_operational_calendar_repository,
                "the_operational_calendar_repository");
        }

        private IEntityRepository<PlannedSupply.OperationsCalendars.OperationalCalendar>
            _operational_calendar_repository;
    }
}