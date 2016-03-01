using Ninject;
using Ninject.Activation;
using System;
using WTS.WorkSuite.Library.Ninject.Configuration;

namespace WTS.WorkSuite.PlannedSupply.BreakTemplates.Mapper
{
    public class DependencyConfiguration
                    : ADependencyConfiguration
    {
        public override void configure(IKernel kernel,
                                        Func<IContext, object> scope
                                      )
        {
            kernel
                .Bind<IBreakTemplateDetailsMapper>()
                .To<BreakTemplateDetailsMapper>()
                ;
        }
    }
}