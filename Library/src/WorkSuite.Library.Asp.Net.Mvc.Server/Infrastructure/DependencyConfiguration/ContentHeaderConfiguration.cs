using Ninject;
using Ninject.Activation;
using System;
using WorkSuite.Library.Asp.Net.Mvc.Server.ContentHeaders.Dynamic.StaticDefinitions.Definitions;
using WorkSuite.Library.Asp.Net.Mvc.Server.ContentHeaders.Dynamic.StaticDefinitions.Definitions.Actions;
using WTS.WorkSuite.Library.Ninject.Configuration;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.DependencyConfiguration
{
    public class ContentHeaderConfiguration
                        : ADependencyConfiguration
    {
        public override void configure(IKernel kernel,
                                        Func<IContext,
                                        object> scope
                                      )
        {
            kernel
                .Bind(typeof(DynamicContentHeaderStaticDefinitionRepository<>))
                .To(typeof(DynamicContentHeaderStaticDefinitionRepository<>))
                .InSingletonScope()
                ;

            kernel
                .Bind(typeof(DynamicContentHeaderActionStaticDefinitionBuilder<>))
                .To(typeof(DynamicContentHeaderActionStaticDefinitionBuilder<>))
                .InSingletonScope()
                ;
        }
    }
}