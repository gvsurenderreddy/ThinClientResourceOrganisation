using System;
using Ninject;
using Ninject.Activation;
using WorkSuite.Configuration.Persistence.Domain.Configuration;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Library.EntityFramework.Contexts.TestConnections;
using WTS.WorkSuite.Library.Ninject.Configuration;

namespace WorkSuite.Configuration.Service.Helpers.Domain.Configuration.DatabaseSetting
{

    public class DependencyConfiguration
        : ADependencyConfiguration
    {

        public override void configure
            (IKernel kernel
                , Func<IContext, object> scope)
        {

            kernel
                .Rebind<IQueryRepository<DatabaseSettings>
                    , IEntityRepository<DatabaseSettings>
                    , FakeDatabaseSettingRepository>()
                .To<FakeDatabaseSettingRepository>()
                .InScope(x => scope)
                ;


            kernel
                .Rebind<ICanConnectToDatabase
                    , FakeDatabaseConnectionTest>()
                .To<FakeDatabaseConnectionTest>()
                .InScope(x => scope)
                ;

        }
    }
}

