using System;
using Ninject;
using Ninject.Activation;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Library.Ninject.Configuration;
using WTS.WorkSuite.PlannedSupply.HR.Employee;

namespace WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.HR.Employee
{
    public class DependencyConfiguration : ADependencyConfiguration
    {
        public override void configure(IKernel kernel, Func<IContext, object> scope)
        {
            kernel
               .Rebind<IEntityRepository<EmployeePlannedSupply>
                    , FakeEmployeeRepository>()
               .To<FakeEmployeeRepository>()
               .InScope(scope)
               ;
        }
    }
}
