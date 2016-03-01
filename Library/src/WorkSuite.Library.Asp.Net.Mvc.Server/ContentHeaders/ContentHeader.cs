using System.Collections.Generic;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.ContentHeaders
{
    /// <summary>
    ///     View model for the content header component.
    /// </summary>
    public class ContentHeader
                    : IsAViewElement
    {
        /// <summary>
        ///     The content headers title
        /// </summary>
        public string title { get; set; }

        /// <summary>
        ///     Classes that should be applied to this header.
        /// </summary>
        public IEnumerable<string> classes { get; set; }

        /// <summary>
        ///     Actions that can be applied to the content header
        /// </summary>
        public IEnumerable<ContentHeaderAction> actions { get; set; }
    }
}