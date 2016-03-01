using WTS.WorkSuite.Core.DomainIdentity;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.ThinClient.Query.Application.HR.employee.Holidays.listItems
{
    public interface IGetHolidayListItems
                                : IQuery<EmployeeIdentity, GetHolidayListItemsResponse> { }
}
