using System;
using System.Collections.ObjectModel;
using WorkSuite.Library.Asp.Net.Mvc.Server.Urls;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.ContentHeaders.Dynamic.StaticDefinitions.Definitions.Actions {


    /// <summary>
    ///     Allows you to add content action defintions to a content header defintion
    /// </summary>
    /// <typeparam name="S">
    ///     The type of the content header model 
    /// </typeparam>
    public class DynamicContentHeaderActionStaticDefinitionBuilder<S> {


        /// <summary>
        ///     Set the title of actions that are created from this defitintion to be the supplied value
        /// </summary>
        /// <param name="value">
        ///     The value that you want the title of the action to be.
        /// </param>
        /// <returns>
        ///     The builder so that this method can be used as part of a fluent interface.
        /// </returns>
        public DynamicContentHeaderActionStaticDefinitionBuilder<S> title
                                                                        ( string value ) {

            defintion.title = m => value;
            return this;
        }

        /// <summary>
        ///     Set the title of actions that are created from this defitintion to be the supplied value
        /// </summary>
        /// <param name="dynamic_title_expression">
        ///     expression used to 
        /// </param>
        /// <returns>
        ///     The builder so that this method can be used as part of a fluent interface.
        /// </returns>
        public DynamicContentHeaderActionStaticDefinitionBuilder<S> title
                                                                        ( Func<S,string> dynamic_title_expression ) {

            defintion.title = dynamic_title_expression;
            return this;
        }

        /// <summary>
        ///     Set the name of actions that are created from this defitintion to be the supplied value
        /// </summary>
        /// <remarks>
        ///     This is internal as we do not want the name to be overriden it should come from the Action definition because
        /// we hook onto this in javascript.
        /// </remarks>
        /// <param name="value">
        ///     The value that you want the name of the action to be.
        /// </param>
        /// <returns>
        ///     The builder so that this method can be used as part of a fluent interface.
        /// </returns>
        internal DynamicContentHeaderActionStaticDefinitionBuilder<S> name
                                                                        ( string value ) {

            defintion.name = m => value;
            return this;
        }


        /// <summary>
        ///     Add a class to the collection of classes that will be applied to actions created from this definition.
        /// </summary>
        /// <param name="value">
        ///     The name of the class to be added to the action.
        /// </param>
        /// <returns>
        ///     The builder so that this method can be used as part of a fluent interface.
        /// </returns>
        public DynamicContentHeaderActionStaticDefinitionBuilder<S> add_class
                                                                        ( string value ) {

            defintion.classes.Add( m => value );
            return this;
        }

        /// <summary>
        ///     Add a class to the collection of classes that will be applied to actions created from this definition.
        /// </summary>
        /// <param name="class_expression">
        ///     Expression that will generate the class name
        /// </param>
        /// <returns>
        ///     The builder so that this method can be used as part of a fluent interface.
        /// </returns>
        public DynamicContentHeaderActionStaticDefinitionBuilder<S> add_class
                                                                       ( Func<string> class_expression ) {

            defintion.classes.Add( m => class_expression());
            return this;
        }


        /// <summary>
        ///     Add a class to the collection of classes that will be applied to actions created from this definition.
        /// </summary>
        /// <param name="dynamic_class_expression">
        ///     Expression that will generate the class name from the models
        /// </param>
        /// <returns>
        ///     The builder so that this method can be used as part of a fluent interface.
        /// </returns>
        public DynamicContentHeaderActionStaticDefinitionBuilder<S> add_class
                                                                       ( Func<S,string> dynamic_class_expression ) {

            defintion.classes.Add( dynamic_class_expression );
            return this;
        }


        /// <summary>
        ///     Add the url that will be applied to actions created from this definition.
        /// </summary>
        /// <param name="value">
        ///     The url that you want to use.
        /// </param>
        /// <returns>
        ///     The builder so that this method can be used as part of a fluent interface.
        /// </returns>
        public DynamicContentHeaderActionStaticDefinitionBuilder<S> url
                                                                        ( string value ) {

            defintion.url = new UrlDefinition.StaticUrlDefinition {
                url_expression = () => value,
            };
            return this;
        }

        /// <summary>
        ///     Add the url that will be applied to actions created from this definition.
        /// </summary>
        /// <param name="dynamic_url_expression">
        ///     Expression that generates the url from the model
        /// </param>
        /// <returns>
        ///     The builder so that this method can be used as part of a fluent interface.
        /// </returns>
        public DynamicContentHeaderActionStaticDefinitionBuilder<S> url
                                                                        ( Func<S,string> dynamic_url_expression ) {

            defintion.url = new UrlDefinition.DynamicUrlDefinition<S> {
                url_expression = dynamic_url_expression,
            };
            return this;
        }

        /// <summary>
        ///     Add the name of the name of the route and the route parameter factory that will be used to generate the 
        /// url for actions created from this definition.
        /// </summary>
        /// <param name="route_name">
        ///     The name of the route that url is going to be built from.
        /// </param>
        /// <param name="route_parameters_factory">
        ///     factory that generates the route parameters.
        /// </param>        
        /// <returns>
        ///     The builder so that this method can be used as part of a fluent interface.
        /// </returns>
        public DynamicContentHeaderActionStaticDefinitionBuilder<S> url_from_route
                                                                        ( string route_name
                                                                        , Func<object> route_parameters_factory ) {
            
            defintion.url = new UrlDefinition.StaticRouteUrlDefinition {
                route_name = route_name,
                route_parameter_expression = route_parameters_factory,
            };
            return this;
        }

        /// <summary>
        ///     Add the name of the name of the route and the route parameter factory that will be used to generate the 
        /// url for actions created from this definition.
        /// </summary>
        /// <param name="route_name_expression">
        ///     Expression that generates the route name.
        /// </param>
        /// <param name="route_parameters_expression">
        ///     Expression that generates the route parameters.
        /// </param>        
        /// <returns>
        ///     The builder so that this method can be used as part of a fluent interface.
        /// </returns>
        public DynamicContentHeaderActionStaticDefinitionBuilder<S> url_from_route
                                                                        ( Func<S,string> route_name_expression
                                                                        , Func<S,object> route_parameters_expression ) {

            defintion.url = new UrlDefinition.DynamicRouteUrlDefinition<S> {
                route_name_expression = route_name_expression,
                route_parameter_expression = route_parameters_expression,
            };
            return this;
        }


        /// <summary>
        ///     Add the action defintion to content header definition
        /// </summary>
        public void add() {
            add_definition( defintion );
        }


        public DynamicContentHeaderActionStaticDefinitionBuilder 
                ( Action<DynamicContentHeaderActionStaticDefintion<S>> add_definition_delegate ) {

            add_definition = Guard.IsNotNull( add_definition_delegate, "add_definition_delegate" );
            
            defintion = new DynamicContentHeaderActionStaticDefintion<S> {
                title = m => string.Empty,
                name = m => string.Empty,
                classes = new Collection<Func<S, string>>(),                
            };
        }

        private readonly Action<DynamicContentHeaderActionStaticDefintion<S>> add_definition;
        private readonly DynamicContentHeaderActionStaticDefintion<S> defintion;
    }
}