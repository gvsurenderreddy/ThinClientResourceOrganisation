using System;
using System.Collections.Generic;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.UrlBuilder;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Tests.Framework.ViewModels.Helpers {

    public class FakeRouteBuilder
                    : INamedRouteUrlBuilder
    {

        public string build(NamedRouteUrlObjectBuildDefinition defintion)
        {

            if (routes.ContainsKey(defintion.route_name)) {
                return routes[defintion.route_name];
            }
            return string.Empty;            
        }

        public string build(NamedRouteUrlDictionaryBuildDefinition defintion)
        {
            if (routes.ContainsKey(defintion.route_name)) {
                return routes[defintion.route_name];
            }
            return string.Empty;
        }

        public readonly IDictionary<string, string> routes = new Dictionary<string, string>();
    }
}