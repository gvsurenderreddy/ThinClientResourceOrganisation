using System;
using Ninject;
using Ninject.Activation;
using WTS.WorkSuite.Library.Ninject.Configuration;

namespace WTS.WorkSuite.SupplyShortage.Employee.Sickness.removeSickness
{
    public class DependencyConfiguration : ADependencyConfiguration
    {
        public override void configure(IKernel kernel, Func<IContext, object> scope)
        {
            kernel
               .Bind<IRemoveSicknessRequestHandler>()
               .To<RemoveSicknessRequestHandler>()
               ;
        }
    }
}
