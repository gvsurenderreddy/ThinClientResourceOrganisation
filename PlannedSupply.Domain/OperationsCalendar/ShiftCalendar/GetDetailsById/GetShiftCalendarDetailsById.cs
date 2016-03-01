using System;
using System.Linq;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.GetDetailsById
{
    public class GetShiftCalendarDetailsById : IGetShiftCalendarDetailsById
    {
        public GetShiftCalendarDetailsByIdResponse execute(ShiftCalendarIdentity request)
        {

            var operations_calendar =
                operations_calendar_repository.Entities.Single(oc => oc.id == request.operations_calendar_id);

            var shift_calendar = operations_calendar.ShiftCalendars.Single(sc => sc.id == request.shift_calendar_id);

            return new GetShiftCalendarDetailsByIdResponse()
            {
                has_errors = false,
                messages = null,
                result = new ShiftCalendarDetails()
                {
                    operations_calendar_id = operations_calendar.id,
                    shift_calendar_id = shift_calendar.id,
                    calendar_name = shift_calendar.calendar_name
                }
            };
        }



        public GetShiftCalendarDetailsById(IQueryRepository<OperationsCalendars.OperationalCalendar> the_operations_calendar_repository)
        {
            operations_calendar_repository = Guard.IsNotNull(the_operations_calendar_repository, "the_operations_calendar_repository");
        }

        private IQueryRepository<OperationsCalendars.OperationalCalendar> operations_calendar_repository;
    }
}
