using System;
using Ninject;
using Ninject.Activation;
using WorkSuite.Configuration.Service.Configuration.Help.Edit;
using WTS.WorkSuite.Library.Ninject.Configuration;

namespace WorkSuite.Configuration.Domain.Configuration.Help.Edit
{
    public class DependencyConfiguration
                : ADependencyConfiguration
    {
        public override void configure
                             (IKernel kernel
                             , Func<IContext
                             , object> scope)
        {
            kernel.Bind<IUpdateHelp>()
                .To<UpdateHelp>();

            kernel.Bind<IGetUpdateHelpRequest>()
                .To<GetUpdateHelpRequest>();

        }
    }
}