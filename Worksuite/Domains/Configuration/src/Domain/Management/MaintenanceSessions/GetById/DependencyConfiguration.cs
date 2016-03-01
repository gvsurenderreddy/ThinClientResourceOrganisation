using System;
using Ninject;
using Ninject.Activation;
using WorkSuite.Configuration.Service.Management.MaintenanceSessions.GetById;
using WTS.WorkSuite.Library.Ninject.Configuration;

namespace WorkSuite.Configuration.Domain.Management.MaintenanceSessions.GetById {

    public class DependencyConfiguration 
                    : ADependencyConfiguration {

        public override void configure 
                                ( IKernel kernel
                                , Func<IContext, object> scope  ) {

            kernel
                .Bind<IGetMaintenanceSessionById>(  )
                .To<GetMaintenanceSessionById>()
                ;
        }
    }

}