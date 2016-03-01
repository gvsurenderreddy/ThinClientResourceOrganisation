using Ninject;
using Ninject.Activation;
using System;
using WorkSuite.Library.Service.Specification.Helpers.Request;
using WTS.WorkSuite.Library.Ninject.Configuration;
using WTS.WorkSuite.PlannedSupply.Services.Domain.BreakTemplates.Break.Features.Edit;
using WTS.WorkSuite.PlannedSupply.Services.Domain.BreakTemplates.Break.Features.New;
using WTS.WorkSuite.PlannedSupply.Services.Domain.BreakTemplates.Break.Features.Remove;
using WTS.WorkSuite.PlannedSupply.BreakTemplates.Break;
using WTS.WorkSuite.PlannedSupply.BreakTemplates.Break.Edit;
using WTS.WorkSuite.PlannedSupply.BreakTemplates.Break.New;

namespace WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.BreakTemplates.Breaks
{
    public class DependencyConfiguration
                    : ADependencyConfiguration
    {
        public override void configure(IKernel kernel,
                                       Func<IContext, object> scope
                                      )
        {
            kernel
                .Rebind<IRequestHelper<NewBreakRequest>,
                    NewBreakRequestHelper>()
                .To<NewBreakRequestHelper>()
                ;

            kernel
                .Rebind<IRequestHelper<UpdateBreakRequest>,
                    UpdateBreakRequestHelper>()
                .To<UpdateBreakRequestHelper>()
                ;

            kernel.
                Rebind<IRequestHelper<BreakIdentity>,
                    RemoveBreakRequestHelper>()
                .To<RemoveBreakRequestHelper>();
        }
    }
}