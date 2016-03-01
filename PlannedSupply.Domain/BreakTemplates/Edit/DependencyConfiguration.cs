using Ninject;
using Ninject.Activation;
using System;
using WTS.WorkSuite.Library.Ninject.Configuration;
using WTS.WorkSuite.PlannedSupply.BreakTemplates.Edit.GetUpdateRequest;
using WTS.WorkSuite.PlannedSupply.BreakTemplates.Edit.Update;

namespace WTS.WorkSuite.PlannedSupply.BreakTemplates.Edit
{
    public class DependencyConfiguration
                    : ADependencyConfiguration
    {
        public override void configure(IKernel kernel,
                                       Func<IContext, object> scope
                                      )
        {
            kernel
                .Bind<IGetUpdateBreakTemplateRequest>()
                .To<GetUpdateBreakTemplateRequest>()
                ;

            kernel
                .Bind<IUpdateBreakTemplate>()
                .To<UpdateBreakTemplate>()
                ;
        }
    }
}