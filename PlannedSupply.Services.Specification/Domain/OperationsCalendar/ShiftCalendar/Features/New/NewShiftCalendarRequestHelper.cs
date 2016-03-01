using WorkSuite.Library.Service.Specification.Helpers.Request;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.New;
using WTS.WorkSuite.PlannedSupply.OperationsCalendars;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.PlannedSupply.OperationsCalendars;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.Features.New
{
    public class NewShiftCalendarRequestHelper
                        : IRequestHelper<NewShiftCalendarRequest>
    {
        public NewShiftCalendarRequest given_a_valid_request()
        {
            string an_operational_calendar_name = "High seasons demand";
            OperationalCalendar an_operational_calendar = _operational_calendar_helper
                                                                .add()
                                                                .calendar_name(an_operational_calendar_name)
                                                                .entity
                                                                ;

            return new NewShiftCalendarRequest
                            {
                                operations_calendar_id = an_operational_calendar.id,
                                calendar_name = "Shift calendar A"
                            };
        }

        public NewShiftCalendarRequestHelper(OperationsCalendarHelper the_operational_calendar_helper)
        {
            _operational_calendar_helper = Guard.IsNotNull(the_operational_calendar_helper,
                "the_operational_calendar_helper");
        }

        private readonly OperationsCalendarHelper _operational_calendar_helper;
    }
}