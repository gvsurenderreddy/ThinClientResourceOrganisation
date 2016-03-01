using System;
using Ninject;
using Ninject.Activation;
using WTS.WorkSuite.Library.Ninject.Configuration;
using WTS.WorkSuite.Web.ThinClient.Components.ShiftTimeAllocationPalettes.Dynamic.StaticDefinitions;

namespace WTS.WorkSuite.Web.ThinClient.Components.Infrastructure.DependencyConfiguration
{
    public class ShiftTimeAllocationPaletteConfiguration : ADependencyConfiguration
    {
        public override void configure(IKernel kernel,
                                        Func<IContext,
                                        object> scope
                                      )
        {
            kernel
                .Bind(typeof(DynamicShiftTimeAllocationPaletteStaticDefinitionRepository<>))
                .To(typeof(DynamicShiftTimeAllocationPaletteStaticDefinitionRepository<>))
                .InSingletonScope()
                ;
        }
    }
}