using System.Web.Mvc;
using System.Web.Routing;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ControllerFactory;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration {

    public interface ISimpleNamedRouteDefinition
                        : INamedRouteDefinition {
        
        /// <summary>
        /// The name of the controller that handles request for this 
        /// route
        /// </summary>
        string controller { get; }

        /// <summary>
        /// The name of the action on the controller the hanbles request
        /// for this route 
        /// </summary>
        string action { get; }
    }


    public static class ISimpleNamedRouteDefinitionExtension {

        public static NamedRoute build_mvc_named_route
                                    ( this ISimpleNamedRouteDefinition definition ) {

            Guard.IsNotNull( definition, "definition" );

            return new NamedRoute(
                name: definition.id,
                route: new Route(
                    url: definition.url,
                    routeHandler: new MvcRouteHandler() ) {                      
                    Defaults = new RouteValueDictionary ( new {
                        controller = definition.controller,
                        action = definition.action,
                    } ),
                    Constraints = new RouteValueDictionary(),
                    DataTokens = new RouteValueDictionary(),
           });
        }
    }


    // Improve: ARouteConfiguration should be renamed to SimpleNamedRouteDefinition
    public abstract class ARouteConfiguration<S> 
                            : ISimpleNamedRouteDefinition
                    where S : IController {

         
        /// <summary>
        ///     Unique id for this view, the route name will also be set to this
        /// </summary>
        public abstract string id { get; }
                
        /// <summary>
        ///     The url pattern for the route.
        /// </summary>
        public abstract string url { get; }   
        
        /// <summary>
        ///     Name of the controller action to send the request to
        /// </summary>
        public abstract string action { get; }


        // controller name that should be used when registering this route
        public string controller {

            get {
                return typeof (S).mvc_controller_name();
            }
        }



    }


    public abstract class APageRouteConfiguration<S>
                            : ARouteConfiguration<S>
                    where S : IController {

        public override string action {
            get { return "Page";  }
        }

    }
}