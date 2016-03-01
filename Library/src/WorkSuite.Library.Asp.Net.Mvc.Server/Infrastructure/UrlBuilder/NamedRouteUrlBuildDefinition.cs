
namespace WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.UrlBuilder
{
    public abstract class NamedRouteUrlBuildDefinition
    {
        /// <summary>
        ///     The name of the route that should be used
        /// by the Url builder
        /// </summary>
        public abstract string route_name { get; set; }
    }
}
