using System;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.UrlBuilder;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Urls {

    public class BuildUrlFromDefinition<S> {
        
        public string build
                        ( UrlDefinition definition
                        , S model ) {


            return definition.Match<S,string>(

                DynamicRouteUrl:
                    d => route_builder.build( new NamedRouteUrlObjectBuildDefinition {
                        route_name = d.route_name_expression( model ),
                        route_parameters_factory = () => d.route_parameter_expression( model ),
                    }),

                 
                DynamicUrl:
                    d => d.url_expression( model ),


                StaticRouteUrl:
                    d => route_builder.build(new NamedRouteUrlObjectBuildDefinition {
                        route_name = d.route_name,
                        route_parameters_factory = () => d.route_parameter_expression(),
                    }),


                StaticUrl:
                    d => d.url_expression(),


                Undefined:
                    () => String.Empty

            );
        }

        public BuildUrlFromDefinition 
                ( INamedRouteUrlBuilder the_route_builder ) {

            route_builder = Guard.IsNotNull( the_route_builder, "the_route_builder");
        }

        // route builder used to get urls for named routes
        private readonly INamedRouteUrlBuilder route_builder;
    }
}