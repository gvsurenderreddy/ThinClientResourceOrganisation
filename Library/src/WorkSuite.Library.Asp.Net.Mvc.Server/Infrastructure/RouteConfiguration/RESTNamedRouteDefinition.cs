using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Web.Mvc;
using System.Web.Routing;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ControllerFactory;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration {

    public interface IRESTNameRouteDefinition
                        : INamedRouteDefinition {
        
        Type GET { get; }

        Type PUT { get; }
        
        Type POST { get; }

        Type DELETE { get; }
    }

    public abstract class RESTNameRouteDefinition
                            < GET_via 
                            , PUT_via
                            , POST_via
                            , DELETE_via > 
                            : INamedRouteDefinition 
                            where GET_via : Controller
                            where PUT_via : Controller
                            where POST_via : Controller
                            where DELETE_via : Controller {
      

        public abstract string url { get; }
        public abstract string id { get;  }
        
        public Type GET {
            get {  return typeof( GET_via ); }
        }

        public Type PUT {
            get {  return typeof( PUT_via ); }
        }

        public Type POST {
            get { return typeof( POST_via); }
        }

        public Type DELETE {
            get { return typeof( DELETE_via ); }
        }
    }

    public class VerbNotSupported
                    : Controller { }

    public static class IRESTNameRouteDefinitionExtension {

        public static IEnumerable<NamedRoute> build_mvc_named_routes
                                                ( this IRESTNameRouteDefinition definition ) {

            if (definition.GET != typeof (VerbNotSupported)) {

                yield return create_named_route( 
                    "GET",
                    definition.id,
                    definition.url,
                    definition.GET 
                );
            }


            if (definition.PUT != typeof (VerbNotSupported)) {

                yield return create_named_route( 
                    "PUT",
                    definition.id,
                    definition.url,
                    definition.PUT 
                );
            }


            if (definition.POST != typeof (VerbNotSupported)) {

                yield return create_named_route( 
                    "POST",
                    definition.id,
                    definition.url,
                    definition.POST
                );                
            }

            if ( definition.DELETE != typeof( VerbNotSupported ) ) { 

                yield return create_named_route( 
                    "DELETE",
                    definition.id,
                    definition.url,
                    definition.DELETE
                );            
            }
        }

        private static NamedRoute create_named_route
                                    ( string verb
                                    , string name
                                    , string url
                                    , Type controller ) {
            
            return new NamedRoute(
                name:  verb + "_" + name,
                route: new Route(
                    url: url,
                    routeHandler: new MvcRouteHandler() ) {                      
                    Defaults = new RouteValueDictionary ( new {
                        controller = controller.mvc_controller_name(),
                        action = verb,
                    } ),
                    Constraints = new RouteValueDictionary {
                        { "httpMethod", new HttpMethodConstraint( new [] { verb }) } 
                    },
                    DataTokens = new RouteValueDictionary(),
           });
        }
    }
}