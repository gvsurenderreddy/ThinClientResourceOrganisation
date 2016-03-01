using System.Web.Routing;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration {

    /// <summary>
    ///     Asp.Net route and name
    /// </summary>
    public class NamedRoute {

        public string name { get; private set;}
        public Route route {  get; private set;}

        public NamedRoute ( string name, Route route ) {
            this.name = name;
            this.route = route;
        }

    }
}