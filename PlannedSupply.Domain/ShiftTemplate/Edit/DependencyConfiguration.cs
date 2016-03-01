using System;
using Ninject;
using Ninject.Activation;
using WTS.WorkSuite.Library.Ninject.Configuration;
using WTS.WorkSuite.PlannedSupply.ShiftTemplates.Edit.Update;
using WTS.WorkSuite.PlannedSupply.ShiftTemplates.ShiftDetails.ShiftTemplateSummary;

namespace WTS.WorkSuite.PlannedSupply.ShiftTemplate.Edit
{
    public class DependencyConfiguration
                      : ADependencyConfiguration
    {
        public override void configure
                            ( IKernel kernel
                            , Func<IContext, object> scope)
        {

            kernel.Bind<IGetShiftTemplateUpdateRequest>()
               .To<GetShiftTemplateUpdateRequest>();

            kernel.Bind<IUpdateShiftTemplate>()
                .To<UpdateShiftTemplate>();
        }
    }
}