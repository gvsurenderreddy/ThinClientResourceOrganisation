using System;
using Ninject;
using Ninject.Activation;
using WTS.WorkSuite.Library.Ninject.Configuration;
using WTS.WorkSuite.ThinClient.Query.Application.HR.employee.ViewSchedules.tableItems;

namespace WTS.WorkSuite.ThinClient.Query.Application.HR.employee.ViewSchedules.tableReport
{
    public class GetEmployeeViewScheduleTableReportDependencyConfiguration : ADependencyConfiguration
    {
        public override void configure(IKernel kernel, Func<IContext, object> scope)
        {
            kernel
                .Bind<IGetEmployeeViewScheduleTableItems>()
                .To<GetEmployeeViewScheduleTableItems>()
                ;
        }
    }
}
