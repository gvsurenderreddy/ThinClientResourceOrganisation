using WorkSuite.Library.Service.Specification.Helpers.Entity;
using WTS.WorkSuite.PlannedSupply.ShiftCalendars;

namespace WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.PlannedSupply.OperationsCalendars.ShiftCalendars
{
    public class ShiftCalendarHelper
                        : EnityHelper<ShiftCalendar,
                                        int,
                                        ShiftCalendarBuilder,
                                        FakeShiftCalendarRepository
                                     > { }
}