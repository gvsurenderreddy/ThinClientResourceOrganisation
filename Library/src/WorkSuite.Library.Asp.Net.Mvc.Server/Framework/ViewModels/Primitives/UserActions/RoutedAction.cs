using System.Collections.Generic;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.UserActions
{
    /// <summary>
    ///     Application layers representation of an action that has a route.
    /// </summary>
    public class RoutedAction : IUserAction
    {
        /// <summary>
        ///     A unique id of the action.
        /// </summary>
        public string id { get; set; }

        /// <summary>
        ///     Description of the action that should be displayed to a
        /// user.
        /// </summary>
        public string title { get; set; }

        /// <summary>
        ///     route to the action
        /// </summary>
        public string url { get; set; }

        /// <summary>
        ///     All actions in the system are of a predefined type.
        /// </summary>
        /// <remarks>
        ///     The difficulty that I am having with this is that
        /// I think the type is domain specific where as this class
        /// is a framework class.  I may need to change this to a
        /// sub class.
        /// </remarks>
        /// 
        
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

        /// <summary>
        /// Identifies if the action should be enabled when first
        /// displayed
        /// </summary>
        public bool is_enabled { get; set; }
    }
}