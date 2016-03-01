using WorkSuite.Library.Service.Specification.Helpers.Entity;
using WTS.WorkSuite.SupplyShortage.Employees;

namespace WTS.WorkSuite.SupplyShortage.Services.Helpers.Domain.Employee
{
    public class EmployeeSupplyShortageHelper : EnityHelper< EmployeeSupplyShortage,
                                                             int,
                                                             EmployeeSupplyShortageBuilder,
                                                             FakeEmployeeSupplyShortageRepository
                                                           > { }
}
