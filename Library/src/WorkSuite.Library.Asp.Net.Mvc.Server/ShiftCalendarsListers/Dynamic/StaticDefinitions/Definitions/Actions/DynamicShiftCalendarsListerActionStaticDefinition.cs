using System;
using System.Collections.Generic;
using WorkSuite.Library.Asp.Net.Mvc.Server.Urls;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.ShiftCalendarsListers.Dynamic.StaticDefinitions.Definitions.Actions
{
    /// <summary>
    ///     Action definition for a dynamic Shift Calendars Lister
    /// </summary>
    /// <typeparam name="S">
    ///     The type of the model that the Shift Calendars Lister is for
    /// </typeparam>
    public class DynamicShiftCalendarsListerActionStaticDefinition<S>
    {
        /// <summary>
        ///     Expression that the title for the action.
        /// </summary>
        public Func<S, string> title { get; set; }

        /// <summary>
        ///     Expression that generates the name that is used by the javascript
        ///     in the client to identify the event it will trigger.
        /// </summary>
        public Func<S, string> name { get; set; }

        /// <summary>
        ///     Definitions for the classes that should be applied to
        ///     actions created from this definition.
        /// </summary>
        public ICollection<Func<S, string>> classes { get; set; }

        /// <summary>
        ///     Expression that generates the url.
        /// </summary>
        public UrlDefinition url { get; set; }
    }
}