using System;
using Ninject;
using Ninject.Activation;
using WorkSuite.Configuration.Persistence.Domain.Management;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Library.Ninject.Configuration;

namespace WorkSuite.Configuration.Service.Helpers.Domain.Management.MaintenanceSessions {

    public class DependencyConfiguration 
                    : ADependencyConfiguration {

        public override void configure
                                ( IKernel kernel
                                , Func<IContext, object> scope ) {

            kernel
                .Rebind< IQueryRepository<MaintenanceSession>
                       , IEntityRepository<MaintenanceSession>
                       , FakeMaintenanceSessionRepository>()
                .To<FakeMaintenanceSessionRepository>()
                .InScope(x => scope)
                ;           
        }

    }

}