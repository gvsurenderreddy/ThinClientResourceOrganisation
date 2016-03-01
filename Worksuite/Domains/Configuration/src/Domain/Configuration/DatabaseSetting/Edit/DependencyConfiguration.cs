using System;
using Ninject;
using Ninject.Activation;
using WorkSuite.Configuration.Service.Configuration.DatabaseSettings.Edit;
using WTS.WorkSuite.Library.EntityFramework.Contexts.TestConnections;
using WTS.WorkSuite.Library.Ninject.Configuration;

namespace WorkSuite.Configuration.Domain.Configuration.DatabaseSetting.Edit
{
    public class DependencyConfiguration
                    : ADependencyConfiguration {

        public override void configure
                                ( IKernel kernel
                                , Func<IContext, object> scope )
        {


            kernel.Bind<IUpdateDatabaseSettings>().
                To<UpdateDatabaseSettings>();

            kernel.Bind<IGetUpdateRequest>()
                .To<GetUpdateDatabaseSettingRequest>();

            kernel.Bind<ICanConnectToDatabase>()
                .To<CanConnectToDatabaseResponse>();
        }
    }
}