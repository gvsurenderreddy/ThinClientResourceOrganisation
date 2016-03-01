using System;
using Ninject;
using Ninject.Activation;
using WorkSuite.Configuration.Persistence.Domain.Configuration;
using WTS.WorkSuite.Library.Ninject.Configuration;

namespace WorkSuite.Configuration.Service.Helpers.Domain.Management.ServiceStatus {

    public class DependencyConfiguration
                    : ADependencyConfiguration {

        public override void configure
                                ( IKernel kernel
                                , Func<IContext, object> scope ) {

            kernel
                .Rebind< IServiceStatusRepository
                       , FakeServiceStatusRepository>()
                .To<FakeServiceStatusRepository>()
                .InScope( scope )
                ;

            kernel
                .Rebind<ServiceStatusHelper>()
                .To<ServiceStatusHelper>()
                .InScope( scope );
        }

    }

}