using WTS.WorkSuite.Core.DomainIdentity;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.HR.Employees.EmployeeQualifications.GetAll
{
    public interface IGetAllEmployeeQualifications
                            : IQuery<   EmployeeIdentity,
                                        GetAllEmployeeQualificationsResponse
                                    > {}
}