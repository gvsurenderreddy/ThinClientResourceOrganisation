using System;
using Ninject;
using Ninject.Activation;
using WTS.WorkSuite.Library.Ninject.Configuration;
using WTS.WorkSuite.PlannedSupply.ShiftTemplates.New.Create;
using WTS.WorkSuite.PlannedSupply.ShiftTemplates.New.GetCreateRequest;

namespace WTS.WorkSuite.PlannedSupply.ShiftTemplate.New
{
    public class DependencyConfiguration
                         : ADependencyConfiguration
    {
        public override void configure(IKernel kernel
                                     , Func<IContext, object> scope)
        {
            kernel.Bind<IGetNewShiftTemplatesRequest>()
                .To<GetNewShiftTemplatesRequest>();

            kernel.Bind<INewShiftTemplates>()
                .To<NewShiftTemplates>();
        }
    }
}