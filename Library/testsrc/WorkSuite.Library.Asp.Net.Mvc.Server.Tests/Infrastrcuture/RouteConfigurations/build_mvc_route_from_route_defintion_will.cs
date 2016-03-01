using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ControllerFactory;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Tests.Infrastrcuture.RouteConfigurations {

    [TestClass]
    public class build_mvc_route_from_route_defintion_will {

        // done: returns an empty list if the defintions are empty
        // done: create a route for each route definition        
        // done: set the route handler to be an MvcRoteHandler
        // done: set the defaults to be an empty collection 
        // done: set the constraints to be empty collection
        // done: set the data tokens to be an empty collection 
        // done: set the route name from the definition
        // done: set the route url from the defintion
        // done: set the controler paramter correctly for a controller
        // done: set the controller parameter correctly for a presenter
        // To do: set the action parameter from the definition


        [TestMethod]
        public void returns_an_empty_list_if_the_defintions_are_empty () {
            var defintions = new List<INamedRouteDefinition> {                
            };

            defintions
                .build_mvc_route(  )
                .Should(  ).BeEmpty(  )
                ;
        }

        [TestMethod]
        public void create_a_route_for_each_route_definition () {
            
            var defintions = new List<INamedRouteDefinition> { 
                new RouteConfigurationControllerDefinition(),
                new RouteConfigurationControllerDefinition()                
            };

            defintions
                .build_mvc_route(  )
                .Count().Should().Be( defintions.Count )
                ;

        }

        [TestMethod]
        public void set_the_route_handler_to_be_an_MvcRoteHandler () {
            
            var defintion = new List<INamedRouteDefinition> {
                new RouteConfigurationControllerDefinition()
            };

            defintion
                .build_mvc_route(  )
                .Single( )
                .route
                .RouteHandler
                .Should(  ).BeOfType<MvcRouteHandler>(  );

        }

        [TestMethod]
        public void the_defaults_collection_is_not_null () {
            var definitions = new List<INamedRouteDefinition> {
                new RouteConfigurationControllerDefinition()
            };

            definitions
                .build_mvc_route()
                .Single()
                .route
                .Defaults
                .Should().NotBeNull(  )
                ;
        }

        [TestMethod]
        public void set_the_constraints_to_be_empty_collection () {
            
            var definitions = new List<INamedRouteDefinition> {
                new RouteConfigurationControllerDefinition()
            };

            definitions
                .build_mvc_route()
                .Single()
                .route
                .Constraints
                .Should(  ).BeEmpty(  )
                ;
        }

        [TestMethod]
        public void set_the_data_tokens_to_be_an_empty_collection () {
            var definitions = new List<INamedRouteDefinition> {
                new RouteConfigurationControllerDefinition()
            };

            definitions
                .build_mvc_route(  )
                .Single()
                .route
                .DataTokens
                .Should(  ).BeEmpty()
                ;
        }

        [TestMethod]
        public void set_the_route_name_from_the_definition () {
            var definition = new RouteConfigurationControllerDefinition();

            var definitions = new List<INamedRouteDefinition> {
                definition
            };

            definitions
                .build_mvc_route(  )
                .Single()
                .name
                .Should(  ).Be( definition.id )
                ;
        }

        [TestMethod]
        public void set_the_route_url_from_the_defintion () {            
            var definition = new RouteConfigurationControllerDefinition();

            var definitions = new List<INamedRouteDefinition> {
                definition
            };

            definitions
                .build_mvc_route(  )
                .Single()
                .route
                .Url
                .Should(  ).Be( definition.url )
                ;
        }

        [TestMethod]
        public void set_the_controler_paramter_correctly_for_a_controller () {
            var definition = new RouteConfigurationControllerDefinition();
            
            var definitions = new List<INamedRouteDefinition> {
                definition
            };

            definitions
                .build_mvc_route(  )
                .Single()
                .route
                .Defaults[ "controller" ]
                .Should(  ).Be( "RouteConfiguartion" )
                ;
        }

        [TestMethod]
        public void set_the_controller_parameter_correctly_for_a_presenter () {
            var definition = new RouteConfigurationPresenterDefinition();

            var definitions = new List<INamedRouteDefinition> {
                definition
            };

            definitions
                .build_mvc_route(  )
                .Single()
                .route
                .Defaults["controller"]
                .Should(  ).Be( "RouteConfigurationPresenter" )
                ;
        }

        [TestMethod]
        public void set_the_action_parameter_from_the_definition () {
            var definition = new RouteConfigurationControllerDefinition();

            var definitions = new List<INamedRouteDefinition> {
                definition
            };

            definitions
                .build_mvc_route(  )
                .Single()
                .route
                .Defaults["action"]
                .Should().Be( definition.action )
                ;
        }
    }

    internal class RouteConfiguartionController : Controller { }

    internal class RouteConfigurationControllerDefinition 
                        : ARouteConfiguration<RouteConfiguartionController> {

        public override string id {
            get { return "An id"; }
        }

        public override string url {
            get { return "A url"; }
        }

        public override string action {
            get { return "an action"; }
        }
    }



    internal class RouteConfigurationPresenter : Presenter {  }

    internal class RouteConfigurationPresenterDefinition
                        : ARouteConfiguration<RouteConfigurationPresenter> {

        public override string id {
            get { return "Presneter id"; }
        }

        public override string url {
            get { return "presenter url"; }
        }

        public override string action {
            get { return "presenter action"; }
        }
    }
}