using System;
using Ninject;
using Ninject.Activation;
using WTS.WorkSuite.Library.Ninject.Configuration;
using WTS.WorkSuite.Web.ThinClient.Components.WhiteSpaceTimeAllocationPalettes.Dynamic.StaticDefinitions;

namespace WTS.WorkSuite.Web.ThinClient.Components.Infrastructure.DependencyConfiguration
{
    public class WhiteSpaceTimeAllocationPaletteConfiguration : ADependencyConfiguration
    {
        public override void configure(IKernel kernel,
                                        Func<IContext,
                                        object> scope
                                      )
        {
            kernel
                .Bind(typeof(DynamicWhiteSpaceTimeAllocationPaletteStaticDefinitionRepository<>))
                .To(typeof(DynamicWhiteSpaceTimeAllocationPaletteStaticDefinitionRepository<>))
                .InSingletonScope()
                ;
        }
    }
}