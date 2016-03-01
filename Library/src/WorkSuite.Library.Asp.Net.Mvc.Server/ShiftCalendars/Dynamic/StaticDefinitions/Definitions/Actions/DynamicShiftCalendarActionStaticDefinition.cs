using System;
using System.Collections.Generic;
using WorkSuite.Library.Asp.Net.Mvc.Server.Urls;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.ShiftCalendars.Dynamic.StaticDefinitions.Definitions.Actions
{
    /// <summary>
    ///     Action definition for a dynamic Shift Calendar.
    /// </summary>
    /// <typeparam name="S">
    ///     The type of the model that the Shift Calendar is for.
    /// </typeparam>
    public class DynamicShiftCalendarActionStaticDefinition<S>
    {
        /// <summary>
        ///     Expression that generates the title of the action.
        /// </summary>
        public Func<S, string> title { get; set; }

        /// <summary>
        ///     Expression that generates the name of the action
        ///     that is used by the javascript in the client to
        ///     identify the event that it will trigger.
        /// </summary>
        public Func<S, string> name { get; set; }

        /// <summary>
        ///     Definitions for the classes that should be applied to action
        ///     created from this definition.
        /// </summary>
        public ICollection<Func<S, string>> classes { get; set; }

        /// <summary>
        ///     Url for the action.
        /// </summary>
        public UrlDefinition url { get; set; }
    }
}