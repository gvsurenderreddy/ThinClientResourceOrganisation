using WorkSuite.Library.Service.Specification.Helpers.Entity;
using WTS.WorkSuite.ThinClient.Query.HR.employee.Holidays;

namespace WTS.WorkSuite.ThinClient.Query.Services.Application.HR.employee.Holidays.listItems.Setup
{
    public class HolidayListViewHelper :
                    EnityHelper < HolidayListView,
                                  int,
                                  HolidayListViewBuilder,
                                  FakeHolidayListViewRepository
                                > { }
}
