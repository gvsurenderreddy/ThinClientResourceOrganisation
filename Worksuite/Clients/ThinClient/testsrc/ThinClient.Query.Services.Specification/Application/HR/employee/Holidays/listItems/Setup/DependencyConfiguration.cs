using System;
using Ninject;
using Ninject.Activation;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Library.Ninject.Configuration;
using WTS.WorkSuite.ThinClient.Query.HR.employee.Holidays;

namespace WTS.WorkSuite.ThinClient.Query.Services.Application.HR.employee.Holidays.listItems.Setup
{
    public class DependencyConfiguration : ADependencyConfiguration
    {
        public override void configure( IKernel kernel, Func<IContext, object> scope )
        {
            kernel
                .Rebind<IQueryRepository<HolidayListView>,
                    IEntityRepository<HolidayListView>,
                    FakeHolidayListViewRepository
                    >()
                .To<FakeHolidayListViewRepository>()
                .InScope(x => scope)
                ;

        }
    }
}
