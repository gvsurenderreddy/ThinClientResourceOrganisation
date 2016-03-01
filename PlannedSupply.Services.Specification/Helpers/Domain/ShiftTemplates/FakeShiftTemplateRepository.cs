using WorkSuite.Library.Service.Specification.Helpers.IdentityProvider;
using WorkSuite.Library.Service.Specification.Helpers.Persistence;

namespace WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.ShiftTemplates
{
    public class FakeShiftTemplateRepository
                     :FakeEntityRepository<WorkSuite.PlannedSupply.ShiftTemplates.ShiftTemplate,int> {
        public FakeShiftTemplateRepository
                       (  ) : base(  new IntIdentityProvider<WorkSuite.PlannedSupply.ShiftTemplates.ShiftTemplate>() )
        {
        }
    }
}