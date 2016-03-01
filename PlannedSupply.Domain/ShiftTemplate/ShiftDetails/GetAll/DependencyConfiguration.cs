using Ninject;
using Ninject.Activation;
using System;
using WTS.WorkSuite.Library.Ninject.Configuration;
using WTS.WorkSuite.PlannedSupply.BreakTemplates.Break.Queries.GetAll;

namespace WTS.WorkSuite.PlannedSupply.ShiftTemplate.ShiftDetails.GetAll
{
    public class DependencyConfiguration
                    : ADependencyConfiguration
    {
        public override void configure(IKernel kernel,
                                       Func<IContext, object> scope
                                      )
        {
            kernel
                .Bind<IGetDetailsOfAllBreaks>()
                .To<GetDetailsOfAllBreaks>()
                ;
        }
    }
}