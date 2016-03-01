using WorkSuite.Library.Service.Specification.Helpers.Entity;

namespace WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.PlannedSupply.OperationsCalendars
{
    public class OperationsCalendarHelper
                        : EnityHelper<WorkSuite.PlannedSupply.OperationsCalendars.OperationalCalendar,
                                        int,
                                        OperationsCalendarBuilder,
                                        FakeOperationsCalendarRepository
                                     > { }
}