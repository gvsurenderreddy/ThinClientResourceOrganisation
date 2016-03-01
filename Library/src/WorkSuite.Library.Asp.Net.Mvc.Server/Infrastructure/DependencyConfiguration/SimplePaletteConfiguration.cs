using Ninject;
using Ninject.Activation;
using System;
using WorkSuite.Library.Asp.Net.Mvc.Server.SimplePalettes.Dynamic.StaticDefinitions.Definitions;
using WorkSuite.Library.Asp.Net.Mvc.Server.SimplePalettes.Dynamic.StaticDefinitions.Definitions.Actions;
using WTS.WorkSuite.Library.Ninject.Configuration;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.DependencyConfiguration
{
    public class SimplePaletteConfiguration
                        : ADependencyConfiguration
    {
        public override void configure(IKernel kernel,
                                        Func<IContext,
                                        object> scope
                                      )
        {
            kernel
                .Bind(typeof(DynamicSimplePaletteStaticDefinitionRepository<>))
                .To(typeof(DynamicSimplePaletteStaticDefinitionRepository<>))
                .InSingletonScope()
                ;

            kernel
                .Bind(typeof(DynamicSimplePaletteActionStaticDefinitionBuilder<>))
                .To(typeof(DynamicSimplePaletteActionStaticDefinitionBuilder<>))
                .InSingletonScope()
                ;
        }
    }
}