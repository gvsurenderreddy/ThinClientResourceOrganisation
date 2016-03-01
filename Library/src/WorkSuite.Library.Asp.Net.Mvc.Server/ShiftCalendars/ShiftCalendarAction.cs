using System.Collections.Generic;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.ShiftCalendars
{
    /// <summary>
    ///     View model for the Shift Calendar Action.
    /// </summary>
    public class ShiftCalendarAction
    {
        /// <summary>
        ///     Title of the shift calendar action.
        /// </summary>
        public string title { get; set; }

        /// <summary>
        ///     Name of the shift calendar action that is used by the javascript
        ///     in the client to identify the event that it will trigger.
        /// </summary>
        public string name { get; set; }

        /// <summary>
        ///     Url for the shift calendar action.
        /// </summary>
        public string url { get; set; }

        /// <summary>
        ///     Classes that should be applied to shift calendar action.
        /// </summary>
        public ICollection<string> classes { get; set; }
    }
}