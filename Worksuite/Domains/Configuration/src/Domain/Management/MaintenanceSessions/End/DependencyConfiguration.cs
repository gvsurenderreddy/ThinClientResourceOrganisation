using System;
using Ninject;
using Ninject.Activation;
using WorkSuite.Configuration.Service.Management.MaintenanceSessions.End;
using WTS.WorkSuite.Library.Ninject.Configuration;

namespace WorkSuite.Configuration.Domain.Management.MaintenanceSessions.End {

    public class DependencyConfiguration 
                    : ADependencyConfiguration {

        public override void configure 
                                ( IKernel kernel
                                , Func<IContext, object> scope ) {

            kernel
                .Bind<IEndMaintenanceSession>()
                .To<EndMaintenanceSession>()
                ;
        }
    }
}