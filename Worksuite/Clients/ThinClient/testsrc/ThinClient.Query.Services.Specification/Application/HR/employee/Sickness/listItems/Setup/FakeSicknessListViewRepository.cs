using WorkSuite.Library.Service.Specification.Helpers.IdentityProvider;
using WorkSuite.Library.Service.Specification.Helpers.Persistence;
using WTS.WorkSuite.ThinClient.Query.HR.employee.Sickness;

namespace WTS.WorkSuite.ThinClient.Query.Services.Application.HR.employee.Sickness.listItems.Setup
{
    public class FakeSicknessListViewRepository 
        : FakeEntityRepository<SicknessListView, int>
    {
        public FakeSicknessListViewRepository
            () 
            : base(new IntIdentityProvider<SicknessListView>())
        {
        }
    }
}
