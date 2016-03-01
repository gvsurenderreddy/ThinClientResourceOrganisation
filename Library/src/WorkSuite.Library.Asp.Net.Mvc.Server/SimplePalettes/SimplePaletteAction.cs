using System.Collections.Generic;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.SimplePalettes {

    public class SimplePaletteAction {

        /// <summary>
        ///     Title that will be displayed for the action
        /// </summary>
        public string title { get; set; }

        /// <summary>
        ///     Name of the action, note this is important as 
        /// it is used by the javascript in the client to identify
        /// the event that it will trigger.
        /// </summary>
        public string name { get; set; }

        /// <summary>
        ///     Name of the component, to to use as the current context
        /// </summary>
        public string component_context { get; set; }

        /// <summary>
        ///     Url for the action.
        /// </summary>
        public string url { get; set; }

        /// <summary>
        ///     Classes that should be applied to this action
        /// </summary>
        public ICollection<string> classes { get; set; }

    }
}