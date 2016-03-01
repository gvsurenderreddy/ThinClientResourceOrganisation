using Ninject;
using Ninject.Activation;
using System;
using WorkSuite.Library.Persistence;
using WorkSuite.Library.Service.Specification.Helpers.Request;
using WTS.WorkSuite.Library.Ninject.Configuration;
using WTS.WorkSuite.PlannedSupply.Services.Domain.BreakTemplates.Features.Edit;
using WTS.WorkSuite.PlannedSupply.Services.Domain.BreakTemplates.Features.New;
using WTS.WorkSuite.PlannedSupply.BreakTemplates;
using WTS.WorkSuite.PlannedSupply.BreakTemplates.Edit;
using WTS.WorkSuite.PlannedSupply.BreakTemplates.New;

namespace WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.BreakTemplates
{
    public class DependencyConfiguration
                    : ADependencyConfiguration
    {
        public override void configure(IKernel kernel, Func<IContext, object> scope)
        {
            kernel
                .Rebind<IQueryRepository<BreakTemplate>,
                    IEntityRepository<BreakTemplate>,
                    FakeBreakTemplateRepository
                    >()
                .To<FakeBreakTemplateRepository>()
                .InScope(x => scope)
                ;

            kernel
                .Rebind<IRequestHelper<NewBreakTemplateRequest>,
                    NewBreakTemplateRequestHelper>()
                .To<NewBreakTemplateRequestHelper>()
                ;

            kernel
                .Rebind<IRequestHelper<UpdateBreakTemplateRequest>,
                    UpdateBreakTemplateRequestHelper>()
                .To<UpdateBreakTemplateRequestHelper>()
                ;
        }
    }
}