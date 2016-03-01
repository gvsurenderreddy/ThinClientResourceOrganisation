using System.Web.Mvc;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.SimplePalettes.Dynamic.StaticDefinitions.Definitions
{
    /// <summary>
    /// This is a marker interface that identifies simple palette definitions builder. The definitions builders
    /// create a simple palette's definitions and put it into its type’s definitions repository.  It is intended
    /// that when an application is bootstrapping all the classes in the application assembly that
    /// implement this interfaces will instantiated and their build method executed.
    /// </summary>
    public interface ISimplePaletteDefinitionsBuilder
    {
        /// <summary>
        ///     Create the simple palette's definitions and adds it to that simple palette's definitions repository
        /// </summary>
        /// <param name="resolver">
        ///     The dependency resolver that the simple palette's definitions repository should be resolved from.
        /// </param>
        void build
                (IDependencyResolver resolver);
    }
}