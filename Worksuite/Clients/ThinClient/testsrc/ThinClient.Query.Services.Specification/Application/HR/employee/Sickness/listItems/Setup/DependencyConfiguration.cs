using System;
using Ninject;
using Ninject.Activation;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Library.Ninject.Configuration;
using WTS.WorkSuite.ThinClient.Query.HR.employee.Sickness;

namespace WTS.WorkSuite.ThinClient.Query.Services.Application.HR.employee.Sickness.listItems.Setup
{
    public class DependencyConfiguration : ADependencyConfiguration
    {
        public override void configure(IKernel kernel, Func<IContext, object> scope)
        {
            kernel
               .Rebind<IQueryRepository<SicknessListView>,
                   IEntityRepository<SicknessListView>,
                   FakeSicknessListViewRepository
                   >()
               .To<FakeSicknessListViewRepository>()
               .InScope(x => scope)
               ;
        }
    }
}
