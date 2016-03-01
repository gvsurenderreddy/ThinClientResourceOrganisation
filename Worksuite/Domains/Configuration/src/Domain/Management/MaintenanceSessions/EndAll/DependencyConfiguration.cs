using System;
using Ninject;
using Ninject.Activation;
using WorkSuite.Configuration.Service.Management.MaintenanceSessions.EndAll;
using WTS.WorkSuite.Library.Ninject.Configuration;

namespace WorkSuite.Configuration.Domain.Management.MaintenanceSessions.EndAll {

    public class DependencyConfiguration 
                    : ADependencyConfiguration {


        public override void configure 
                                ( IKernel kernel
                                , Func<IContext, object> scope ) {

            kernel
                .Bind<IGetEndAllMaintenanceSessionsRequest>()
                .To<GetEndAllMaintenanceSessionsRequest>()
                ;

            kernel
                .Bind<IEndAllMaintenanceSessions>()
                .To<EndAllMaintenanceSessions>()
                ;
        }
    }
}