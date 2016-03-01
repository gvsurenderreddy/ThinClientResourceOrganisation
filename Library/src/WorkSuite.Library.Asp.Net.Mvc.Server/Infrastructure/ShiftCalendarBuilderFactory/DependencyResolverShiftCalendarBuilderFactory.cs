using System.Web.Mvc;
using WorkSuite.Library.Asp.Net.Mvc.Server.ShiftCalendars.Dynamic.StaticDefinitions;
using WorkSuite.Library.Asp.Net.Mvc.Server.ShiftCalendars.Dynamic.StaticDefinitions.Definitions;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ShiftCalendarBuilderFactory
{
    public class DependencyResolverShiftCalendarBuilderFactory
                        : AShiftCalendarBuilderFactory
    {
        public BuildDynamicShiftCalendarFromStaticDefinition<S> create_builder<S>()
        {
            return DependencyResolver.Current.GetService<BuildDynamicShiftCalendarFromStaticDefinition<S>>();
        }
    }
}