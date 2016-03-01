using WorkSuite.Library.Service.Specification.Helpers.IdentityProvider;
using WorkSuite.Library.Service.Specification.Helpers.Persistence;
using WTS.WorkSuite.PlannedSupply.Breaks;

namespace WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.BreakTemplates.Breaks
{
    public class FakeBreakRepository
                    : FakeEntityRepository<Break, int>
    {
        public FakeBreakRepository()
            : base(new IntIdentityProvider<Break>())
        {
        }
    }
}