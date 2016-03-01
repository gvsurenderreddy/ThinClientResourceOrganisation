
using System.Collections.Generic;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.NamedRouteMetadataRepository
{
    public class NamedRouteMetadataRepository : INamedRouteMetadataRepository
    {
        private readonly Dictionary<string, string> repository = new Dictionary<string, string>();

        public NamedRouteMetadataRepository( IEnumerable<INamedRouteDefinition> routes )
        {
            foreach (var route in routes)
            {
                repository.Add(route.id, route.url);
            }
        }


        public Dictionary<string, string> entries
        {
            get { return repository; }
        }
    }

}
