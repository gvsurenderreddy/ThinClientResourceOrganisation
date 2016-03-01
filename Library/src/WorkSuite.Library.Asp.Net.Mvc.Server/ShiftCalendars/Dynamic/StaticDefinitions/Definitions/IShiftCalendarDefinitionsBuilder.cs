using System.Web.Mvc;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.ShiftCalendars.Dynamic.StaticDefinitions.Definitions
{
    /// <summary>
    /// This is a marker interface that identifies Shift Calendar definitions builder. The definitions builders
    /// create a Shift Calendar's definitions and put it into its type’s definitions repository.  It is intended
    /// that when an application is bootstrapping all the classes in the application assembly that
    /// implement this interfaces will instantiated and their build method executed.
    /// </summary>
    public interface IShiftCalendarDefinitionsBuilder
    {
        /// <summary>
        ///     Creates the Shift Calendar's definitions and adds it to that Shift Calendar's definitions repository
        /// </summary>
        /// <param name="resolver">
        ///     The dependency resolver that the Shift Calendar's definitions repository should be resolved from.
        /// </param>
        void build(IDependencyResolver the_resolver);
    }
}