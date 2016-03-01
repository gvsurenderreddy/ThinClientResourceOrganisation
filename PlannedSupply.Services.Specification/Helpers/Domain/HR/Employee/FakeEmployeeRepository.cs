using WorkSuite.Library.Service.Specification.Helpers.IdentityProvider;
using WorkSuite.Library.Service.Specification.Helpers.Persistence;
using WTS.WorkSuite.PlannedSupply.HR.Employee;

namespace WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.HR.Employee
{
    public class FakeEmployeeRepository : FakeEntityRepository<EmployeePlannedSupply,int>
    {
        public FakeEmployeeRepository()
            : base(new IntIdentityProvider<EmployeePlannedSupply>()) { }
    }
}
