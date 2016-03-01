using System;
using Ninject;
using Ninject.Activation;
using WTS.WorkSuite.Library.Ninject.Configuration;

namespace WTS.WorkSuite.HR.HR.Employees.Addresses.New {

    public class DependencyConfiguration
                    : ADependencyConfiguration {

        public override void configure
                                ( IKernel kernel
                                , Func<IContext, object> scope ) {

            kernel
               .Bind<IGetNewAddressRequest>()
               .To<GetNewAddressRequest>()
               ;

            kernel
                .Bind<INewAddress>()
                .To<NewAddress>()
                ;
            
            kernel
               .Bind<ICanAddNewAddress>()
               .To<CanAddNewAddress>()
               ;
        }
    }
}