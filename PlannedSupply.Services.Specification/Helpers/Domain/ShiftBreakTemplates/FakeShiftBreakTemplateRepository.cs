using WorkSuite.Library.Service.Specification.Helpers.IdentityProvider;
using WorkSuite.Library.Service.Specification.Helpers.Persistence;
using WTS.WorkSuite.PlannedSupply.BreakTemplates;

namespace WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.BreakTemplates
{
    public class FakeBreakTemplateRepository
                        : FakeEntityRepository<BreakTemplate, int>
    {
        public FakeBreakTemplateRepository()
            : base(new IntIdentityProvider<BreakTemplate>())
        {
        }
    }
}