using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.UrlBuilder
{

    public class NamedRouteUrlBuilder : INamedRouteUrlBuilder
    {

        public string build
            (NamedRouteUrlObjectBuildDefinition build_definition)
        {

            Guard.IsNotNull(build_definition, "build_definition");

            var factory = build_definition.route_parameters_factory ?? null_object_factory;
            var url_builder = create_url_helper();


            var result = url_builder.RouteUrl(build_definition.route_name, factory());

            return Guard.IsNotNull(result, "result");
        }



        public string build
                    (NamedRouteUrlDictionaryBuildDefinition build_definition)
        {

            Guard.IsNotNull(build_definition, "build_definition");

            var factory = build_definition.route_parameters_factory ?? empty_dictionary_factory;
            var url_builder = create_url_helper();

            var par = factory();

            var result = url_builder.RouteUrl(build_definition.route_name, par);

            if (result == null)
            {
                result = url_builder.RouteUrl(build_definition.route_name);
            }
            
            return Guard.IsNotNull(result, "result");
        }


        // creates a url helper
        private UrlHelper create_url_helper()
        {
            var httpContextBase = new HttpContextWrapper(HttpContext.Current);
            var route_data = RouteTable.Routes.GetRouteData(httpContextBase) ?? new RouteData();
            var request_context = new RequestContext(httpContextBase, route_data);

            return new UrlHelper(request_context);
        }

        private readonly Func<object> null_object_factory = () => new { };

        private readonly Func<RouteValueDictionary> empty_dictionary_factory = () => new RouteValueDictionary();
    }

}