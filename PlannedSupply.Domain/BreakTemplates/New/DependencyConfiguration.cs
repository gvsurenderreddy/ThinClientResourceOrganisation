using Ninject;
using Ninject.Activation;
using System;
using WTS.WorkSuite.Library.Ninject.Configuration;
using WTS.WorkSuite.PlannedSupply.BreakTemplates.New.Create;
using WTS.WorkSuite.PlannedSupply.BreakTemplates.New.GetCreateRequest;

namespace WTS.WorkSuite.PlannedSupply.BreakTemplates.New
{
    public class DependencyConfiguration
                    : ADependencyConfiguration
    {
        public override void configure(IKernel kernel, Func<IContext, object> scope)
        {
            kernel
                .Bind<IGetNewBreakTemplateRequest>()
                .To<GetNewBreakTemplateRequest>()
                ;

            kernel
                .Bind<INewBreakTemplate>()
                .To<NewBreakTemplate>()
                ;
        }
    }
}