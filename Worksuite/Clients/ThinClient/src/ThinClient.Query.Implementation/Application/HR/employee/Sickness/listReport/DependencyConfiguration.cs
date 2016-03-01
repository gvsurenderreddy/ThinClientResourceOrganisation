using System;
using Ninject;
using Ninject.Activation;
using WTS.WorkSuite.Library.Ninject.Configuration;
using WTS.WorkSuite.ThinClient.Query.Application.HR.employee.Sickness.listItems;

namespace WTS.WorkSuite.ThinClient.Query.Application.HR.employee.Sickness.listReport
{
    public class DependencyConfiguration : ADependencyConfiguration
    {
        public override void configure(IKernel kernel, Func<IContext, object> scope)
        {
            kernel
                .Bind<IGetSicknessListItems>()
                .To<GetSicknessListItems>()
                ;
        }
    }
}
