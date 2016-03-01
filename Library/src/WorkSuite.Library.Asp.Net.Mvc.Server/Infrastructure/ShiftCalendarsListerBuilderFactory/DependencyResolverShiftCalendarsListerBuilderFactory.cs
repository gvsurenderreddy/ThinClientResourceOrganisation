using System.Web.Mvc;
using WorkSuite.Library.Asp.Net.Mvc.Server.ShiftCalendarsListers.Dynamic.StaticDefinitions;
using WorkSuite.Library.Asp.Net.Mvc.Server.ShiftCalendarsListers.Dynamic.StaticDefinitions.Definitions;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ShiftCalendarsListerBuilderFactory
{
    public class DependencyResolverShiftCalendarsListerBuilderFactory
                        : AShiftCalendarsListerBuilderFactory
    {
        public BuildDynamicShiftCalendarsListerFromStaticDefinition<S> create_builder<S>()
        {
            return DependencyResolver.Current.GetService<BuildDynamicShiftCalendarsListerFromStaticDefinition<S>>();
        }
    }
}