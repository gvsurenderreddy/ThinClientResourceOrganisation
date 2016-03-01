using WTS.WorkSuite.Core.DomainIdentity;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.ThinClient.Query.Application.HR.employee.Sickness.listItems
{
    public interface IGetSicknessListItems : IQuery<EmployeeIdentity, GetSicknessListItemsResponse> { }
}
