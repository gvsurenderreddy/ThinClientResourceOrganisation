using System.Web.Mvc;
using WorkSuite.Library.Asp.Net.Mvc.Server.ContentHeaders.Dynamic.StaticDefinitions;
using WorkSuite.Library.Asp.Net.Mvc.Server.ContentHeaders.Dynamic.StaticDefinitions.Definitions;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ContentHeaderBuilderFactory
{
    public class DependencyResolverContentHeaderBuilderFactory
                            : AContentHeaderBuilderFactory
    {
        public BuildDynamicContentHeaderFromStaticDefinition<S> create_builder<S>()
        {
            return DependencyResolver.Current.GetService<BuildDynamicContentHeaderFromStaticDefinition<S>>();
        }
    }
}