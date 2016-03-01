using System;
using System.Collections.Generic;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.UserActions.Configuration.Static.CallToActionTypes;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.UserActions.Metadata
{
    public class RoutedActionMetadata<S>
    {
        public string id { get; set; }

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
        ///     These are the Classes of action, it is purely for styling purposes.
        /// </summary>
        /// <remarks>
        ///     The reason we have a broken the styling and a intercation identification is
        /// because we may want to style all save buttons the same way but we always want
        /// different behaviour between the save report edits  and save content header edits.
        /// </remarks>
        public ICollection<string> classes { get; set; }

        public Func<S, object> route_parameter_factory { get; set; }
        public Func<S, bool> decide_if_enabled { get; set; }
    }
}