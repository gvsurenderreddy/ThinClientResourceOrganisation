using System.Web.Mvc;
using WorkSuite.Library.Asp.Net.Mvc.Server.SimplePalettes.Dynamic.StaticDefinitions;
using WorkSuite.Library.Asp.Net.Mvc.Server.SimplePalettes.Dynamic.StaticDefinitions.Definitions;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.SimplePaletteBuilderFactory
{
    public class DependencyResolverSimplePaletteBuilderFactory : ASimplePaletteBuilderFactory
    {
        public BuildDynamicSimplePaletteFromStaticDefinition<S> create_builder<S>()
        {
            return DependencyResolver.Current.GetService<BuildDynamicSimplePaletteFromStaticDefinition<S>>();
        }
    }
}