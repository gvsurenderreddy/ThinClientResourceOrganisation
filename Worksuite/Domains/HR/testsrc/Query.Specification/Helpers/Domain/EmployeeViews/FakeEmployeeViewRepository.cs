using WorkSuite.Library.Service.Specification.Helpers.IdentityProvider;
using WorkSuite.Library.Service.Specification.Helpers.Persistence;

namespace WTS.WorkSuite.HR.Query.Helpers.Domain.EmployeeViews {

    public class FakeEmployeeRepository 
                    : FakeEntityRepository<EmployeeView,int>  {

        public FakeEmployeeRepository ( ) 
                : base( new IntIdentityProvider<EmployeeView>() ) {}

    }
}