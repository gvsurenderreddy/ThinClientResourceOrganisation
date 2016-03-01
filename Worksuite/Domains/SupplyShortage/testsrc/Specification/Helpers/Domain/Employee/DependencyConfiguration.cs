using System;
using Ninject;
using Ninject.Activation;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Library.Ninject.Configuration;
using WTS.WorkSuite.SupplyShortage.Employees;

namespace WTS.WorkSuite.SupplyShortage.Services.Helpers.Domain.Employee
{
    public class DependencyConfiguration : ADependencyConfiguration
    {
        public override void configure(IKernel kernel, Func<IContext, object> scope)
        {

            kernel
                .Rebind<IQueryRepository<EmployeeSupplyShortage>
                         , IEntityRepository<EmployeeSupplyShortage>
                         , FakeEmployeeSupplyShortageRepository>()
                .To<FakeEmployeeSupplyShortageRepository>()
                .InScope(x => scope)
                ;

        }

    }
}
