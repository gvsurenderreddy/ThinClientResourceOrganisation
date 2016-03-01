using Ninject;
using Ninject.Activation;
using System;
using WTS.WorkSuite.Library.Ninject.Configuration;
using WTS.WorkSuite.PlannedSupply.BreakTemplates.Break.Edit.GetUpdateRequest;
using WTS.WorkSuite.PlannedSupply.BreakTemplates.Break.Edit.Update;

namespace WTS.WorkSuite.PlannedSupply.BreakTemplates.Break.Edit
{
    public class DependencyConfiguration
                        : ADependencyConfiguration
    {
        public override void configure(IKernel kernel,
                                       Func<IContext, object> scope
                                      )
        {
            kernel
                .Bind<IGetUpdateBreakRequest>()
                .To<GetUpdateBreakRequest>()
                ;

            kernel
                .Bind<IUpdateBreak>()
                .To<UpdateBreak>()
                ;
        }
    }
}