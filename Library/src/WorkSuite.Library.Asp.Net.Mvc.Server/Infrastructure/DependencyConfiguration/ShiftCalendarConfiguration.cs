using Ninject;
using Ninject.Activation;
using System;
using WorkSuite.Library.Asp.Net.Mvc.Server.ShiftCalendars.Dynamic.StaticDefinitions.Definitions;
using WorkSuite.Library.Asp.Net.Mvc.Server.ShiftCalendars.Dynamic.StaticDefinitions.Definitions.Actions;
using WTS.WorkSuite.Library.Ninject.Configuration;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.DependencyConfiguration
{
    public class ShiftCalendarConfiguration
                        : ADependencyConfiguration
    {
        public override void configure(IKernel kernel, Func<IContext, object> scope)
        {
            kernel
                .Bind(typeof(DynamicShiftCalendarStaticDefinitionRepository<>))
                .To(typeof(DynamicShiftCalendarStaticDefinitionRepository<>))
                .InSingletonScope()
                ;

            kernel
                .Bind(typeof(DynamicShiftCalendarActionStaticDefinition<>))
                .To(typeof(DynamicShiftCalendarActionStaticDefinitionBuilder<>))
                .InSingletonScope()
                ;
        }
    }
}