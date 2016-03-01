namespace WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.UrlBuilder {

    /// <summary>
    ///     Create a url for a named route
    /// </summary>
    public interface INamedRouteUrlBuilder {

        /// <summary>
        ///     Generates a url for a named route supplied as the
        /// argument for the route name definition parameter.
        /// </summary>
        /// <param name="defintion">
        ///     Contains all the arguments needed  to build a route.
        /// </param>
        /// <returns>
        ///     the url for the named route.     
        /// </returns>
        string build ( NamedRouteUrlObjectBuildDefinition defintion );

        /// <summary>
        ///     Generates a url for a named route supplied as the
        /// argument for the route name definition parameter.
        /// </summary>
        /// <param name="defintion">
        ///     A dictionary containing all the arguments needed  to build a route.
        /// </param>
        /// <returns>
        ///     the url for the named route.     
        /// </returns>
        string build(NamedRouteUrlDictionaryBuildDefinition defintion);

    }

}