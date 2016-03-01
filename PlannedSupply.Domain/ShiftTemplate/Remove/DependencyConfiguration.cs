using System;
using Ninject;
using Ninject.Activation;
using WTS.WorkSuite.Library.Ninject.Configuration;
using WTS.WorkSuite.PlannedSupply.ShiftTemplates.Remove;

namespace WTS.WorkSuite.PlannedSupply.ShiftTemplate.Remove
{
    public class DependencyConfiguration
                     : ADependencyConfiguration
    {
        public override void configure
                             (IKernel kernel
                            , Func<IContext, object> scope)
        {
            kernel
                 .Bind<IGetRemoveShiftTemplateRequest>()
                 .To<GetRemoveShiftTemplateRequest>();

            kernel
                .Bind<IRemoveShiftTemplate>()
                .To<RemoveShiftTemplate>();

            
        }
    }
}