using System.Collections.Generic;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.ShiftCalendarsListers
{
    public class ShiftCalendarsListerAction
    {
        /// <summary>
        ///     Title of the action.
        /// </summary>
        public string title { get; set; }

        /// <summary>
        ///     Name of the action that is used by the javascript
        /// in the client to identify the event that it will trigger..
        /// </summary>
        public string name { get; set; }

        /// <summary>
        ///     Url for the action
        /// </summary>
        public string url { get; set; }

        /// <summary>
        ///     Classes that should be applied to this action
        /// </summary>
        public ICollection<string> classes { get; set; }
    }
}