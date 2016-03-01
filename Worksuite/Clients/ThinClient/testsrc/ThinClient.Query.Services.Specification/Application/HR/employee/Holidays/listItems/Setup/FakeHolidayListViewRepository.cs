using WorkSuite.Library.Service.Specification.Helpers.IdentityProvider;
using WorkSuite.Library.Service.Specification.Helpers.Persistence;
using WTS.WorkSuite.ThinClient.Query.HR.employee.Holidays;

namespace WTS.WorkSuite.ThinClient.Query.Services.Application.HR.employee.Holidays.listItems.Setup
{
    public class FakeHolidayListViewRepository
                        : FakeEntityRepository<HolidayListView, int>
    {
        public FakeHolidayListViewRepository( )
            : base( new IntIdentityProvider<HolidayListView>() ) { }
    }
}
