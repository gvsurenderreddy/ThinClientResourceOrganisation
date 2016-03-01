

using System.Collections.Generic;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.NamedRouteMetadataRepository
{
    public interface INamedRouteMetadataRepository
    {

        Dictionary<string, string> entries { get; }
    }
}
