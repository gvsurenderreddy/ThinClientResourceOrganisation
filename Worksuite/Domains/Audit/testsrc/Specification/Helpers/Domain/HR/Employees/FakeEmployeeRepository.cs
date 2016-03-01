using WorkSuite.Library.Service.Specification.Helpers.IdentityProvider;
using WorkSuite.Library.Service.Specification.Helpers.Persistence;
using WTS.WorkSuite.Audit.HR.Employees;

namespace WTS.WorkSuite.Audit.Helpers.Domain.HR.Employees {

    public class FakeEmployeeRepository 
                    : FakeEntityRepository<EmployeeAuditTrail,int>  {

        public FakeEmployeeRepository ( ) 
                : base( new IntIdentityProvider<EmployeeAuditTrail>() ) {}

    }
}