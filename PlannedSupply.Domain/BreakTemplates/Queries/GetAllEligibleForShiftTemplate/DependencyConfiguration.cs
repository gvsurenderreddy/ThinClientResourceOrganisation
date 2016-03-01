using System;
using Ninject;
using Ninject.Activation;
using WTS.WorkSuite.Library.Ninject.Configuration;

namespace WTS.WorkSuite.PlannedSupply.BreakTemplates.Queries.GetAllEligibleForShiftTemplate
{
    public class DependencyConfiguration
                    : ADependencyConfiguration
    {
        public override void configure(IKernel kernel,
                                       Func<IContext, object> scope
                                      )
        {
            kernel
                .Bind<IGetDetailsOfBreakTemplatesEligibleForShiftTemplate>()
                .To<GetDetailsOfBreakTemplatesEligibleForShiftTemplate>()
                ;
        }
    }
}