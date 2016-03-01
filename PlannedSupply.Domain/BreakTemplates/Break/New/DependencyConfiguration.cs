using Ninject;
using Ninject.Activation;
using System;
using WTS.WorkSuite.Library.Ninject.Configuration;
using WTS.WorkSuite.PlannedSupply.BreakTemplates.Break.New.Create;
using WTS.WorkSuite.PlannedSupply.BreakTemplates.Break.New.GetCreateRequest;

namespace WTS.WorkSuite.PlannedSupply.BreakTemplates.Break.New
{
    public class DependencyConfiguration
                    : ADependencyConfiguration
    {
        public override void configure(IKernel kernel,
                                       Func<IContext, object> scope
                                      )
        {
            kernel
                .Bind<IGetNewBreakRequest>()
                .To<GetNewBreakRequest>()
                ;

            kernel
                .Bind<INewBreak>()
                .To<NewBreak>()
                ;
        }
    }
}