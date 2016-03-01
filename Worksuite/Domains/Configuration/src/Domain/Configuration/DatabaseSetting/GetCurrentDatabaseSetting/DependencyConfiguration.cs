using System;
using Ninject;
using Ninject.Activation;
using WorkSuite.Configuration.Service.Configuration.DatabaseSettings.GetCurrentDatabaseSetting;
using WTS.WorkSuite.Library.Ninject.Configuration;

namespace WorkSuite.Configuration.Domain.Configuration.DatabaseSetting.GetCurrentDatabaseSetting
{
    public class DependencyConfiguration
        : ADependencyConfiguration
    {
        public override void configure(IKernel kernel, Func<IContext, object> scope)
        {
            kernel.Bind<IGetCurrentDatabaseSetting>()
                .To<GetCurrentDatabaseSetting>();
            
        }
    }
}