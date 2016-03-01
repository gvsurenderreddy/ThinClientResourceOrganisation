using Ninject;
using Ninject.Activation;
using System;
using WTS.WorkSuite.Library.Ninject.Configuration;

namespace WTS.WorkSuite.HR.HR.Employees.Addresses.Reorder
{
    public class DependencyConfiguration : ADependencyConfiguration
    {
        public override void configure(IKernel kernel, Func<IContext, object> scope)
        {

            kernel
                .Bind<IGetReorderAddressRequest>()
                .To<GetReorderAddressRequest>()
                ;

            kernel
                .Bind<IReorderAddress>()
                .To<ReorderAddress>()
                ;

            kernel
                .Bind<ICanReorderAddress>()
                .To<CanReorderAddress>()
                ;
        }
    }
}
