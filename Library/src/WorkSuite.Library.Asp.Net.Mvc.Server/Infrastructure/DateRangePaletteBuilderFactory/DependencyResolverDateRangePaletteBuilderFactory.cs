using System.Web.Mvc;
using WorkSuite.Library.Asp.Net.Mvc.Server.DateRangePalettes.Dynamic;
using WorkSuite.Library.Asp.Net.Mvc.Server.DateRangePalettes.Dynamic.StaticDefinitions.Configuration;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.DateRangePaletteBuilderFactory
{
    public class DependencyResolverDateRangePaletteBuilderFactory : ADateRangePaletteBuilderFactory
    {
        public BuildDynamicDateRangePaletteFromStaticDefinition<S> create_builder<S>()
        {
            return DependencyResolver.Current.GetService<BuildDynamicDateRangePaletteFromStaticDefinition<S>>();
        }
    }
}