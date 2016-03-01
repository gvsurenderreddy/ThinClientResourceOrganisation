using System.Collections.Generic;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.SimplePalettes
{
    /// <summary>
    ///     View model for the simple palette component.
    /// </summary>
    public class SimplePalette : IsAViewElement
    {
        /// <summary>
        ///     The simple palette's title
        /// </summary>
        public string title { get; set; }


        /// <summary>
        ///     Classes that should be applied to the simple palette
        /// </summary>
        public IEnumerable<string> classes { get; set; }


        /// <summary>
        /// Simple palette description 
        /// </summary>
        public string description { get; set; }


        /// <summary>
        ///     Actions that can be applied to the simple palette
        /// </summary>
        public IEnumerable<SimplePaletteAction> actions { get; set; }

    }
}