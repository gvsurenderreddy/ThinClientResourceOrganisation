using System.Web.Mvc;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.ContentHeaders.Dynamic.StaticDefinitions.Definitions
{
    /// <summary>
    /// This is a marker interface that identifies content header definitions builder. The definitions builders
    /// create a content header's definitions and put it into its type’s definitions repository.  It is intended
    /// that when an application is bootstrapping all the classes in the application assembly that
    /// implement this interfaces will instantiated and their build method executed.
    /// </summary>
    public interface IContentHeaderDefinitionsBuilder
    {
        /// <summary>
        ///     Create the content header's definitions and adds it to that content header's definitions repository
        /// </summary>
        /// <param name="resolver">
        ///     The dependency resolver that the content header's definitions repository should be resolved from.
        /// </param>
        void build
                (IDependencyResolver resolver);
    }
}