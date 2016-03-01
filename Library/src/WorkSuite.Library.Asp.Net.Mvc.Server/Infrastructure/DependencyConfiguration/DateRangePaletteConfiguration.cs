using Ninject;
using Ninject.Activation;
using System;
using WorkSuite.Library.Asp.Net.Mvc.Server.DateRangePalettes.Dynamic.StaticDefinitions;
using WTS.WorkSuite.Library.Ninject.Configuration;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.DependencyConfiguration
{
    public class DateRangePaletteConfiguration
                        : ADependencyConfiguration
    {
        public override void configure(IKernel kernel,
                                        Func<IContext,
                                        object> scope
                                      )
        {
            kernel
                .Bind(typeof(DynamicDateRangePaletteStaticDefinitionRepository<>))
                .To(typeof(DynamicDateRangePaletteStaticDefinitionRepository<>))
                .InSingletonScope()
                ;
        }
    }
}