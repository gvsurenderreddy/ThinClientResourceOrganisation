using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ControllerFactory;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration {

    /// <summary>
    ///     Applies a route configuration to the route collection
    /// </summary>
    public interface INamedRouteDefinition {

        /// <summary>
        ///     The url is needed to ensure that the urls are registered in
        /// the route collection in the correct area.
        /// </summary>
        string url { get; }

        /// <summary>
        /// The route name/id for this named route instance
        /// </summary>
        string id { get; }

    }


    public static class INamedRouteDefinitionExtensions {

        public static Q Match<Q>
                        ( this INamedRouteDefinition named_route_definition 
                        , Func<ISimpleNamedRouteDefinition,Q> is_simple_route_definition 
                        , Func<IRESTNameRouteDefinition,Q> is_REST_route_definition ) {

            Guard.IsNotNull( is_simple_route_definition, "is_simple_route_definition" );
            Guard.IsNotNull( is_REST_route_definition , "is_REST_route_definition" );


            if ( named_route_definition is ISimpleNamedRouteDefinition ) {
                return is_simple_route_definition( named_route_definition as ISimpleNamedRouteDefinition );
            }

            if ( named_route_definition is IRESTNameRouteDefinition ) {
                return is_REST_route_definition( named_route_definition as IRESTNameRouteDefinition );
            }
            throw new Exception( "Unmatched case" );
        }

        /// <summary>
        /// Orders the route configurations by the url property.  It will ensure that deeper nodes are always 
        /// returned before nodes that are closer to the root of the tree. 
        /// </summary>
        /// <param name="configurations">
        /// The Collection of <see cref="INamedRouteDefinition"/> that are to be ordered
        /// </param>
        /// <returns>
        /// The <see cref="INamedRouteDefinition"/> ordered deepest node first (Post order traversal)
        /// </returns>
        public static IEnumerable<INamedRouteDefinition> deepest_nodes_first 
                                                        ( this IEnumerable<INamedRouteDefinition> configurations ) {
            // build the tree from the route
            var  tree = new NameRouteDefinitionTreeNode();

            configurations.Do( c =>  tree.add( c.url.Split( '/' ), c ));

            return tree.configurations;
        }


        /// <summary>
        ///     Create a route or routes for each of the route defintions.  Resouce defintion may define multiple
        /// routes.
        /// </summary>
        /// <param name="defintions">
        ///     The collection of route defintions that are to be turned into routes.
        /// </param>
        /// <returns>
        ///     The routes for each route definition.
        /// </returns>
        public static IEnumerable<NamedRoute> build_mvc_route
                                                ( this IEnumerable<INamedRouteDefinition> defintions ) {

            return defintions.SelectMany( definition => definition.Match(

                is_simple_route_definition:
                    simple_route_definition => simple_route_definition.build_mvc_named_route().ToEnumerable(),

                is_REST_route_definition:
                    REST_route_definition => REST_route_definition.build_mvc_named_routes()

            ));
        }
    }


    internal class NameRouteDefinitionTreeNode {

        public void add ( IEnumerable<string> path, INamedRouteDefinition node ) {

            // if is a route node add it to the nodes at this level, there should only 
            if ( path.Count() == 0 ) {
                Guard.IsNull( configuration, "configuration" );

                configuration = node;                
            } else {
                
                // get the child node for the path and pass the node to it to be handled by it.
                next_path_node( path.First() ).add( path.Skip( 1 ),  node );
            }
        }

        public IEnumerable<INamedRouteDefinition> configurations {

            get {                

                // register lower configurations first then return this paths configuration.
                return child_nodes
                    .Values
                    .SelectMany( c => c.configurations )
                    .Union( configuration != null ? new List<INamedRouteDefinition> { configuration } : new List<INamedRouteDefinition> ())
                    ;
            }
        }


        // get the child node for the specified path, if a node does not exits a node is
        // created and that is returned
        private NameRouteDefinitionTreeNode next_path_node( string path ) {
            
            if ( !child_nodes.ContainsKey( path ) ){
                child_nodes.Add( path, new NameRouteDefinitionTreeNode() );
            }
            return child_nodes[ path ];
        }

        private INamedRouteDefinition configuration;
        private readonly IDictionary<string,NameRouteDefinitionTreeNode> child_nodes = new Dictionary<string,NameRouteDefinitionTreeNode>();
    }

}