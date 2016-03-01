using System;
using Ninject;
using Ninject.Activation;
using WTS.WorkSuite.Library.Ninject.Configuration;
using WTS.WorkSuite.ThinClient.Query.Application.HR.employee.Holidays.listItems;

namespace WTS.WorkSuite.ThinClient.Query.Application.HR.employee.Holidays.listReport
{
    public class GetHolidayListReportDependencyConfiguration : ADependencyConfiguration
    {
        public override void configure( IKernel kernel,
                                        Func<IContext, object> scope )
        {
            kernel
                .Bind<IGetHolidayListItems>()
                .To<GetHolidayListItems>()
                ;
        }
    }
}
