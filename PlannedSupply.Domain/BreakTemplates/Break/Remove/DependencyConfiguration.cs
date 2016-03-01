using Ninject;
using Ninject.Activation;
using System;
using WTS.WorkSuite.Library.Ninject.Configuration;

namespace WTS.WorkSuite.PlannedSupply.BreakTemplates.Break.Remove
{
    public class DependencyConfiguration
                    : ADependencyConfiguration
    {
        public override void configure(IKernel kernel,
                                       Func<IContext, object> scope
                                      )
        {
            kernel
                .Bind<IGetRemoveBreakRequest>()
                .To<GetRemoveBreakRequest>()
                ;

            kernel
                .Bind<IRemoveBreak>()
                .To<RemoveBreak>()
                ;
        }
    }
}