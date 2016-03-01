using System.Web.Mvc;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.ShiftCalendarsListers.Dynamic.StaticDefinitions.Definitions
{
    /// <summary>
    /// This is a marker interface that identifies Shift Calendars Lister definitions builder. The definitions builders
    /// create a Shift Calendars Lister's definitions and put it into its type’s definitions repository.  It is intended
    /// that when an application is bootstrapping all the classes in the application assembly that
    /// implement this interfaces will instantiated and their build method executed.
    /// </summary>
    public interface IShiftCalendarsListerDefinitionsBuilder
    {
        /// <summary>
        ///     Creates the Shift Calendars Lister's definitions and adds it to that Shift Calendars Lister's definitions repository
        /// </summary>
        /// <param name="resolver">
        ///     The dependency resolver that the Shift Calendars Lister's definitions repository should be resolved from.
        /// </param>
        void build(IDependencyResolver resolver);
    }
}