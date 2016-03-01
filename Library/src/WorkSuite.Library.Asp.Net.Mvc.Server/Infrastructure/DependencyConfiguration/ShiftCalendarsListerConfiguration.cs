using Ninject;
using Ninject.Activation;
using System;
using WorkSuite.Library.Asp.Net.Mvc.Server.ShiftCalendarsListers.Dynamic.StaticDefinitions.Definitions;
using WorkSuite.Library.Asp.Net.Mvc.Server.ShiftCalendarsListers.Dynamic.StaticDefinitions.Definitions.Actions;
using WTS.WorkSuite.Library.Ninject.Configuration;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.DependencyConfiguration
{
    public class ShiftCalendarsListerConfiguration
                        : ADependencyConfiguration
    {
        public override void configure(IKernel kernel,
                                        Func<IContext, object> scope
                                      )
        {
            kernel
                .Bind(typeof(DynamicShiftCalendarsListerStaticDefinitionRepository<>))
                .To(typeof(DynamicShiftCalendarsListerStaticDefinitionRepository<>))
                .InSingletonScope()
                ;

            kernel
                .Bind(typeof(DynamicShiftCalendarsListerActionStaticDefinition<>))
                .To(typeof(DynamicShiftCalendarsListerActionStaticDefinitionBuilder<>))
                .InSingletonScope()
                ;
        }
    }
}