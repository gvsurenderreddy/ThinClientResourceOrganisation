using System;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Urls {

    public abstract class UrlDefinition {

        /// <summary>
        ///     Definition for a url that is generated from a route where
        /// the route id and route parameters are generated from a model.
        /// </summary>
        public sealed class DynamicRouteUrlDefinition<S>
                                : UrlDefinition {

            /// <summary>
            ///     expression that generates the route name.
            /// </summary>
            public Func<S, string> route_name_expression { get; set; }

            /// <summary>
            ///     expression that generated the route parameters
            /// </summary>
            public Func<S, object> route_parameter_expression { get; set; }
        }

        /// <summary>
        ///     Definition for a url that is generated from a expression 
        /// the accepts a model as a parameter.
        /// </summary>
        public sealed class DynamicUrlDefinition<S>
                                : UrlDefinition {

            /// <summary>
            ///     Expression that generates the url.
            /// </summary>
            public Func<S, string> url_expression { get; set; }
        }

        /// <summary>
        ///     Definition for a url that is generated from a route where
        /// the route parameters are generated from an expression.
        /// </summary>
        public sealed class StaticRouteUrlDefinition
                                : UrlDefinition {

            /// <summary>
            ///     Name of the route that the url will be generated from
            /// </summary>
            public string route_name { get; set; }

            /// <summary>
            ///     Expression that generates the object that contains the
            /// route parameters
            /// </summary>
            public Func<object> route_parameter_expression { get; set; }

        }

        /// <summary>
        ///     Definition for a url that is generated from a an expression.
        /// </summary>
        public sealed class StaticUrlDefinition 
                                : UrlDefinition {

            /// <summary>
            ///     Expression that generates the url.
            /// </summary>
            public Func<string> url_expression { get; set; }
        }
    }

    /// <summary>
    ///     Holds extension methods for <see cref="UrlDefinition"/>
    /// </summary>
    public static class UrlDefinitionExtensions {

        // Improve : make the return type monadic

        /// <summary>
        ///     Executes the appropriate delegate based on the runtime type of
        /// the instance.  If the instance is null it will execute the undefined
        /// delegate.
        /// </summary>
        /// <typeparam name="S">
        ///     Model type of the dynamic url defintions.
        /// </typeparam>
        /// <typeparam name="T">
        ///     The return type.  
        /// </typeparam>
        /// <param name="instance">
        ///     The instance of an UrlDefintion that needs to be matched.
        /// </param>
        /// <param name="DynamicRouteUrl">
        ///     Delegate that is executed if the definition is a DynamicRouteUrlDefinition
        /// </param>
        /// <param name="DynamicUrl">
        ///     Delegate that is executed if the definition is a DynamicUrlDefinition
        /// </param>
        /// <param name="StaticRouteUrl">
        ///     Delegate that is executed if the definition is a StaticRouteUrlDefinition
        /// </param>
        /// <param name="StaticUrl">
        ///     Delegate that is executed if the definition is a StaticUrlDefinition
        /// </param>
        /// <param name="Undefined">
        ///     Delegate that is executed if Match is applied to a null definition
        /// </param>
        /// <returns>
        ///     The value of the matched delegagte or throw a <see cref="Exception"/> 
        /// if the instance is defined (not null) but can not be matched.
        /// </returns>
        public static T Match<S, T>
                            ( this UrlDefinition instance
                            , Func<UrlDefinition.DynamicRouteUrlDefinition<S>, T> DynamicRouteUrl
                            , Func<UrlDefinition.DynamicUrlDefinition<S>, T> DynamicUrl
                            , Func<UrlDefinition.StaticRouteUrlDefinition, T> StaticRouteUrl
                            , Func<UrlDefinition.StaticUrlDefinition, T> StaticUrl
                            , Func<T> Undefined ) {

            if ( instance is UrlDefinition.DynamicRouteUrlDefinition<S> ) {
                var definition = (UrlDefinition.DynamicRouteUrlDefinition<S>)instance;
                return DynamicRouteUrl(definition);
            }

            if ( instance is UrlDefinition.DynamicUrlDefinition<S> ) {
                var definition = (UrlDefinition.DynamicUrlDefinition<S>)instance;
                return DynamicUrl(definition);
            }

            if ( instance is UrlDefinition.StaticRouteUrlDefinition ) {
                var definition = (UrlDefinition.StaticRouteUrlDefinition)instance;
                return StaticRouteUrl(definition);
            }

            if ( instance is UrlDefinition.StaticUrlDefinition ) {
                var definition = (UrlDefinition.StaticUrlDefinition)instance;
                return StaticUrl(definition);
            }

            if ( instance == null ) {
                return Undefined();
            }
            // Improve: when making this function monadic allows us to get rid of the exception 
            //          and return nothing.  
            throw new Exception("Unhandled type");
        }
    }

}