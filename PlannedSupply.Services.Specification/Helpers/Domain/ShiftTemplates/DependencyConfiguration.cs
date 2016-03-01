using System;
using Ninject;
using Ninject.Activation;
using WorkSuite.Library.Persistence;
using WorkSuite.Library.Service.Specification.Helpers.Request;
using WTS.WorkSuite.Library.Ninject.Configuration;
using WTS.WorkSuite.PlannedSupply.Services.Domain.ShiftTemplates.Features.Edit;
using WTS.WorkSuite.PlannedSupply.Services.Domain.ShiftTemplates.Features.New;
using WTS.WorkSuite.PlannedSupply.Services.Domain.ShiftTemplates.Features.Remove;
using WTS.WorkSuite.PlannedSupply.ShiftTemplates;
using WTS.WorkSuite.PlannedSupply.ShiftTemplates.Edit;
using WTS.WorkSuite.PlannedSupply.ShiftTemplates.New;

namespace WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.ShiftTemplates
{
    public class DependencyConfiguration
                        : ADependencyConfiguration
    {
        public override void configure
                  ( IKernel kernel
                   , Func<IContext , object> scope)
        {
            kernel
                .Rebind<IQueryRepository<WorkSuite.PlannedSupply.ShiftTemplates.ShiftTemplate>
                          ,IEntityRepository<WorkSuite.PlannedSupply.ShiftTemplates.ShiftTemplate>
                          , FakeShiftTemplateRepository>()
                          .To<FakeShiftTemplateRepository>()
                          .InScope( x=> scope);

            kernel.
                Rebind<IRequestHelper<NewShiftTemplatesRequest>
                                 , ShiftTemplatesRequestHelper
                                 >()
                               .To<ShiftTemplatesRequestHelper>();
            kernel.
                   Rebind<IRequestHelper<UpdateShiftTemplateRequest>
                                    ,UpdateShiftTemplateRequestHelper 
                                    >()
                                    .To<UpdateShiftTemplateRequestHelper>();

            kernel.
                Rebind<IRequestHelper<ShiftTemplateIdentity>
                    , RemoveRequestHelper>()
                .To<RemoveRequestHelper>();

        }
    }
}