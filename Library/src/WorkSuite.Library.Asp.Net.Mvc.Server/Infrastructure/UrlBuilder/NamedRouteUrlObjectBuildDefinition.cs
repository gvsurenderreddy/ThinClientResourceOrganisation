using System;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.UrlBuilder {

    /// <summary>
    ///     Provides the route factory with all the details it 
    /// needs to construct a url for the named route.
    ///  </summary>
    public class NamedRouteUrlObjectBuildDefinition : NamedRouteUrlBuildDefinition
    {
        
        /// <summary>
        ///     The name of the route that should be used
        /// by the route builder
        /// </summary>
        public override string route_name { get; set; }

        /// <summary>
        ///     A factory that will supply the parameters for
        /// the named route.
        /// </summary>
        public Func<object> route_parameters_factory { get; set; }

    }
}