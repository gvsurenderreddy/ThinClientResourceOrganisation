using System;
using Ninject;
using Ninject.Activation;
using WTS.WorkSuite.Library.Ninject.Configuration;

namespace WTS.WorkSuite.HR.HR.Employees.Addresses.Edit
{
    public class DependencyConfiguration : ADependencyConfiguration
    {
        public override void configure(IKernel kernel, Func<IContext, object> scope)
        {

            kernel
                .Bind<IGetUpdateRequest>()
                .To<GetUpdateAddressRequest>()
                ;

            kernel
                .Bind<IUpdateAddress>()
                .To<UpdateAddress>()
                ;

            kernel
                .Bind<ICanUpdateAddress>()
                .To<CanUpdateAddress>()
                ;
        }
    }
}