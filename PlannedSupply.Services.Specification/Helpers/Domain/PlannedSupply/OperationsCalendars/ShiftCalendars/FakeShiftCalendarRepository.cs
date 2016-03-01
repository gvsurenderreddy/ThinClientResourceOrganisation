using WorkSuite.Library.Service.Specification.Helpers.IdentityProvider;
using WorkSuite.Library.Service.Specification.Helpers.Persistence;
using WTS.WorkSuite.PlannedSupply.ShiftCalendars;

namespace WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.PlannedSupply.OperationsCalendars.ShiftCalendars
{
    public class FakeShiftCalendarRepository
                        : FakeEntityRepository<ShiftCalendar, int>
    {
        public FakeShiftCalendarRepository()
            : base(new IntIdentityProvider<ShiftCalendar>()) { }
    }
}