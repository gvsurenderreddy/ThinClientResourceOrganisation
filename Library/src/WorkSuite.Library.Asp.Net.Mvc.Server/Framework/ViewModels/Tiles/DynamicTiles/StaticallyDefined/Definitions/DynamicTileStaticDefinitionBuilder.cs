using System;
using WorkSuite.Library.Asp.Net.Mvc.Server.Urls;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Tiles.DynamicTiles.StaticallyDefined.Definitions {

    /// <summary>
    ///     Build a dynamic tile defintion for a specific model
    /// </summary>
    /// <typeparam name="S"></typeparam>
    public class DynamicTileStaticDefinitionBuilder<S> {

        /// <summary>
        ///     Allows the id to be defined from the model
        /// </summary>
        /// <param name="dynamic_id_expression">
        ///     Expression that generates the id
        /// </param>
        /// <returns>
        ///     The builder so that this method can be used 
        /// as part of a fluent interface.
        /// </returns>
        public DynamicTileStaticDefinitionBuilder<S> id
                                                        ( Func<S, string> dynamic_id_expression ) {

            definition.id = dynamic_id_expression;
            return this;
        }


        /// <summary>
        ///     Allows the id to be defined via an expression
        /// </summary>
        /// <param name="id_expression">
        ///     Expression that generates the id
        /// </param>
        /// <returns>
        ///     The builder so that this method can be used 
        /// as part of a fluent interface.
        /// </returns>
        public DynamicTileStaticDefinitionBuilder<S> id
                                                        ( Func<string> id_expression ) {

            definition.id = m => id_expression();
            return this;
        }


        /// <summary>
        ///     Allows the id to be defined via a string
        /// </summary>
        /// <param name="the_id">
        ///     The id that should be given to tiles of this type
        /// </param>
        /// <returns>
        ///     The builder so that this method can be used 
        /// as part of a fluent interface.
        /// </returns>
        public DynamicTileStaticDefinitionBuilder<S> id
                                                        ( string the_id ) {

            definition.id = m => the_id;
            return this;
        }


        /// <summary>
        ///     Allows the title to be defined from the model
        /// </summary>
        /// <param name="dynamic_title_expression">
        ///     Expression that generates the title
        /// </param>
        /// <returns>
        ///     The builder so that this method can be used 
        /// as part of a fluent interface.
        /// </returns>
        public DynamicTileStaticDefinitionBuilder<S> title
                                                        ( Func<S, string> dynamic_title_expression ) {

            definition.title = dynamic_title_expression;
            return this;
        }

        /// <summary>
        ///     Allows the title to be defined via an expression
        /// </summary>
        /// <param name="title_expression">
        ///     Expression that generates the title
        /// </param>
        /// <returns>
        ///     The builder so that this method can be used 
        /// as part of a fluent interface.
        /// </returns>
        public DynamicTileStaticDefinitionBuilder<S> title
                                                        ( Func<string> title_expression ) {

            definition.title = m => title_expression();
            return this;
        }


        /// <summary>
        ///     Allows the title to be defined via a string
        /// </summary>
        /// <param name="the_title">
        ///     The title that should be given to tiles of this type
        /// </param>
        /// <returns>
        ///     The builder so that this method can be used 
        /// as part of a fluent interface.
        /// </returns>
        public DynamicTileStaticDefinitionBuilder<S> title
                                                        ( string the_title ) {

            definition.title = m => the_title;
            return this;
        }


        /// <summary>
        ///     Allows a class to be added to the the model
        /// </summary>
        /// <param name="dynamic_class_expression">
        ///     Expression that generates the class
        /// </param>
        /// <returns>
        ///     The builder so that this method can be used 
        /// as part of a fluent interface.
        /// </returns>
        public DynamicTileStaticDefinitionBuilder<S> add_class
                                                        ( Func<S, string> dynamic_class_expression ) {

            definition.classes.Add( dynamic_class_expression );
            return this;
        }


        /// <summary>
        ///     Allows a class to be added to the the model
        /// </summary>
        /// <param name="the_class">
        ///     The class that should be added.
        /// </param>
        /// <returns>
        ///     The builder so that this method can be used 
        /// as part of a fluent interface.
        /// </returns>
        public DynamicTileStaticDefinitionBuilder<S> add_class
                                                        ( string the_class ) {

            definition.classes.Add( m => the_class );
            return this;
        }

        /// <summary>
        ///     Allows a class to be added to the the model
        /// </summary>
        /// <param name="class_expression">
        ///     Expression that generates the class
        /// </param>
        /// <returns>
        ///     The builder so that this method can be used 
        /// as part of a fluent interface.
        /// </returns>
        public DynamicTileStaticDefinitionBuilder<S> add_class
                                                        ( Func<string> class_expression ) {

            definition.classes.Add( m => class_expression() );
            return this;
        }


        /// <summary>
        ///     Allows the url to be defined from the model
        /// </summary>
        /// <param name="dynamic_url_expression">
        ///     Expression that generates the url
        /// </param>
        /// <returns>
        ///     The builder so that this method can be used 
        /// as part of a fluent interface.
        /// </returns>
        public DynamicTileStaticDefinitionBuilder<S> url
                                                        ( Func<S, string> dynamic_url_expression ) {

            definition.url = new UrlDefinition.DynamicUrlDefinition<S> {
                url_expression = dynamic_url_expression,
            };
            return this;
        }

        /// <summary>
        ///     Allows the url to be defined as a route id which is taken from 
        /// a property of the model.
        /// </summary>
        /// <param name="dynamic_route_id_expression">
        ///     Expression that generates the route id from the model
        /// </param>
        /// <param name="dynamic_route_parameters_expression">
        ///     Expression that generates the route parameters from the model
        /// </param>        
        /// <returns>
        ///     The builder so that this method can be used 
        /// as part of a fluent interface.
        /// </returns>
        public DynamicTileStaticDefinitionBuilder<S> url_from_route
                                                        ( Func<S, string> dynamic_route_id_expression
                                                        , Func<S, object> dynamic_route_parameters_expression ) {

            definition.url = new UrlDefinition.DynamicRouteUrlDefinition<S> {
                route_name_expression = dynamic_route_id_expression,
                route_parameter_expression = dynamic_route_parameters_expression,
            };
            return this;
        }

        /// <summary>
        ///     Allows the url to be defined as a static text
        /// </summary>
        /// <param name="the_url">
        ///     The url that you want for the tile
        /// </param>
        /// <returns>
        ///     The builder so that this method can be used 
        /// as part of a fluent interface.
        /// </returns>
        public DynamicTileStaticDefinitionBuilder<S> url
                                                        ( string the_url ) {

            definition.url = new UrlDefinition.StaticUrlDefinition {
                url_expression = () => the_url,
            };
            return this;
        }


        /// <summary>
        ///     Allows the url to be defined as a route id which is taken from 
        /// a property of the model.
        /// </summary>
        /// <param name="route_id">
        ///     Id of the named route
        /// </param>
        /// <param name="route_parameters_expression">
        ///     Expression that generates the route parameters
        /// </param>        
        /// <returns>
        ///     The builder so that this method can be used 
        /// as part of a fluent interface.
        /// </returns>
        public DynamicTileStaticDefinitionBuilder<S> url_from_route
                                                        ( string route_id
                                                        , Func<object> route_parameters_expression ) {
            
            definition.url = new UrlDefinition.StaticRouteUrlDefinition {
                route_name = route_id,
                route_parameter_expression = route_parameters_expression,
            };
            return this;
        }

        public DynamicTileStaticDefinitionBuilder 
                ( DynamicTileStaticDefinitionRepository<S> the_repository ) {
            
            repository = Guard.IsNotNull(the_repository, "the_repository");
        }

        private DynamicTileStaticDefinition<S> definition {
            get { return repository.definition; }
        }

        private readonly DynamicTileStaticDefinitionRepository<S> repository;
    }
}