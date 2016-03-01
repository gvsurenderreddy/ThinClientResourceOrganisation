using System;
using System.Collections.Generic;
using WorkSuite.Library.Asp.Net.Mvc.Server.Urls;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.SimplePalettes.Dynamic.StaticDefinitions.Definitions.Actions
{
    /// <summary>
    ///     Action definition for a dynamic simple palette
    /// </summary>
    /// <typeparam name="S">
    ///     The type of the model that the simple palette is for
    /// </typeparam>
    public class DynamicSimplePaletteActionStaticDefintion<T>
    {
        /// <summary>
        ///     Expression that generated the title for the action
        /// </summary>
        public Func<T, string> title { get; set; }

        /// <summary>
        ///     Expression that generate the type 
        /// </summary>
        public Func<T, string> name { get; set; }

        /// <summary>
        ///     Expression that generate the component context
        /// </summary>
        public Func<T, string> component_context { get; set; }

        /// <summary>
        ///     defintions for the classes that should be added to actions created 
        /// from this definition
        /// </summary>
        public ICollection<Func<T, string>> classes { get; set; }

        /// <summary>
        ///     Expression that generates the url.
        /// </summary>
        public UrlDefinition url { get; set; }
    }
}
