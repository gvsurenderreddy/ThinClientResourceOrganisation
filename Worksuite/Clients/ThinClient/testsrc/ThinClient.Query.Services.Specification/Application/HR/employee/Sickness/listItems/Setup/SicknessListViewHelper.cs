using WorkSuite.Library.Service.Specification.Helpers.Entity;
using WTS.WorkSuite.ThinClient.Query.HR.employee.Sickness;

namespace WTS.WorkSuite.ThinClient.Query.Services.Application.HR.employee.Sickness.listItems.Setup
{
    public class SicknessListViewHelper : EnityHelper
                                                <SicknessListView, 
                                                int, 
                                                SicknessListViewBuilder,
                                                FakeSicknessListViewRepository
                                                >{ }
}
