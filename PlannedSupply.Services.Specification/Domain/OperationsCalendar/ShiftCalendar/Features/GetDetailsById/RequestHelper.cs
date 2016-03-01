using System;
using WorkSuite.Library.Service.Specification.Helpers.Request;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.PlannedSupply.OperationsCalendars;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.PlannedSupply.OperationsCalendars.ShiftCalendars;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.Features.GetDetailsById
{
    public class ShiftCalendarIdentityRequestHelper : IRequestHelper<ShiftCalendarIdentity>
    {
        public ShiftCalendarIdentity given_a_valid_request()
        {
            var shift_calendar = shift_calendar_helper
                                                .add()
                                                .calendar_name("Shift calendar A")
                                                .entity
                                                ;




            var operational_calendar = operational_calendar_helper
                                                        .add()
                                                        .calendar_name("An operations calendar")
                                                        .add_shift_calendar(shift_calendar)
                                                        .entity
                                                        ;


            return new ShiftCalendarIdentity()
            {
                operations_calendar_id = operational_calendar.id,
                shift_calendar_id = shift_calendar.id
            };

        }



        public ShiftCalendarIdentityRequestHelper(OperationsCalendarHelper the_operational_calendar_helper
                                                ,ShiftCalendarHelper the_shift_calendar_helper)
        {
            operational_calendar_helper = Guard.IsNotNull(the_operational_calendar_helper, "the_operational_calendar_helper");
            shift_calendar_helper = Guard.IsNotNull(the_shift_calendar_helper, "the_shift_calendar_helper");
            
        }

        private readonly OperationsCalendarHelper operational_calendar_helper;
        private readonly ShiftCalendarHelper shift_calendar_helper;
    }
}
