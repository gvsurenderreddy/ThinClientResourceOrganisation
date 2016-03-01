using System;
using Ninject;
using Ninject.Activation;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Library.Ninject.Configuration;
using WTS.WorkSuite.ThinClient.Query.HR.employee.ViewSchedules;

namespace WTS.WorkSuite.ThinClient.Query.Services.Application.HR.employee.ViewSchedules.tableItems.Setup
{
    public class DependencyConfiguration : ADependencyConfiguration
    {
        public override void configure(IKernel kernel, Func<IContext, object> scope)
        {
            kernel
               .Rebind<IQueryRepository<EmployeeViewScheduleTableView>,
                   IEntityRepository<EmployeeViewScheduleTableView>,
                   FakeEmployeeViewScheduleTableViewRepository
                   >()
               .To<FakeEmployeeViewScheduleTableViewRepository>()
               .InScope(x => scope)
               ;
        }
    }
}
