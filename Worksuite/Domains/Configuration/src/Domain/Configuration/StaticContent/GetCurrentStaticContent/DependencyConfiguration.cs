using System;
using Ninject;
using Ninject.Activation;
using WorkSuite.Configuration.Service.Configuration.StaticContent.GetCurrentStaticContent;
using WTS.WorkSuite.Library.Ninject.Configuration;

namespace WorkSuite.Configuration.Domain.Configuration.StaticContent.GetCurrentStaticContent
{
    public class DependencyConfiguration
        : ADependencyConfiguration
    {
        public override void configure(IKernel kernel, Func<IContext, object> scope)
        {
            kernel.Bind<IGetCurrentStaticContent>()
                .To<GetCurrentStaticContent>();
            
        }
    }
}