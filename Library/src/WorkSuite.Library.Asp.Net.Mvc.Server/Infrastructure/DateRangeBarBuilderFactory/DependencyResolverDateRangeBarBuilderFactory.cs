using System.Web.Mvc;
using WorkSuite.Library.Asp.Net.Mvc.Server.DateRangeBars.Dynamic;
using WorkSuite.Library.Asp.Net.Mvc.Server.DateRangeBars.Dynamic.StaticDefinitions.Configuration;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.DateRangeBarBuilderFactory
{
    public class DependencyResolverDateRangeBarBuilderFactory : ADateRangeBarBuilderFactory
    {
        public BuildDynamicDateRangeBarFromStaticDefinition<S> create_builder<S>()
        {
            return DependencyResolver.Current.GetService<BuildDynamicDateRangeBarFromStaticDefinition<S>>();
        }
    }
}