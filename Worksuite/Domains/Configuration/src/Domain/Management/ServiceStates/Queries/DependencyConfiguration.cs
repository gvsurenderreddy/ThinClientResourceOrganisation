using System;
using Ninject;
using Ninject.Activation;
using WorkSuite.Configuration.Service.Management.ServiceStates.Queries;
using WTS.WorkSuite.Library.Ninject.Configuration;

namespace WorkSuite.Configuration.Domain.Management.ServiceStates.Queries {

    public class DependencyConfiguration 
                    : ADependencyConfiguration {

        public override void configure
                                ( IKernel kernel
                                , Func<IContext, object> scope ) {

            kernel
                .Bind<IGetServiceStatus>()
                .To<GetServiceStatus>()
                ;
        }
    }
}