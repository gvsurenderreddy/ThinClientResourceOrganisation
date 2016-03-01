using WorkSuite.Library.Service.Specification.Helpers.IdentityProvider;
using WorkSuite.Library.Service.Specification.Helpers.Persistence;
using WTS.WorkSuite.PlannedSupply.ShiftCalendarPatterns;

namespace WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.PlannedSupply.OperationsCalendars.ShiftCalendars.ShiftCalendarPatterns
{
    public class FakeShiftCalendarPatternRepository
                        : FakeEntityRepository<ShiftCalendarPattern, int>
    {
        public FakeShiftCalendarPatternRepository()
            : base(new IntIdentityProvider<ShiftCalendarPattern>()) { }
    }
}