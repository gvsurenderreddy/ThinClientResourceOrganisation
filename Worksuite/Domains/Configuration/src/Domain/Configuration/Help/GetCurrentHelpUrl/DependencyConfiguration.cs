using System;
using Ninject;
using Ninject.Activation;
using WorkSuite.Configuration.Service.Configuration.Help.GetCurrentHelpUrl;
using WTS.WorkSuite.Library.Ninject.Configuration;

namespace WorkSuite.Configuration.Domain.Configuration.Help.GetCurrentHelpUrl
{
    public class DependencyConfiguration
                 : ADependencyConfiguration
    {
        public override void configure
                             (IKernel kernel
                             ,Func<IContext, object> scope)
        {
            kernel.Bind<IGetCurrentHelpUrl>()
                .To<GetCurrentHelpUrl>();
        }
    }
}