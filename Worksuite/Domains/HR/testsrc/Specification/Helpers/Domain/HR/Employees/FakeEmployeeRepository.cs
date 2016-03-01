using WorkSuite.Library.Service.Specification.Helpers.IdentityProvider;
using WorkSuite.Library.Service.Specification.Helpers.Persistence;
using WTS.WorkSuite.HR.HR;

namespace WTS.WorkSuite.HR.Services.Helpers.Domain.HR.Employees {

    public class FakeEmployeeRepository : FakeEntityRepository<Employee,int>  {

        public FakeEmployeeRepository ( ) : base( new IntIdentityProvider<Employee>() ) {}

    }

}