using System;
using System.Collections.Generic;
using WorkSuite.Library.Asp.Net.Mvc.Server.Urls;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.ContentHeaders.Dynamic.StaticDefinitions.Definitions.Actions {


    /// <summary>
    ///     Action definition for a dynamic content header
    /// </summary>
    /// <typeparam name="S">
    ///     The type of the model that the content header is for
    /// </typeparam>
    public class DynamicContentHeaderActionStaticDefintion<S> {

        /// <summary>
        ///     Expression that generated the title for the action
        /// </summary>
        public Func<S, string> title { get; set; }

        /// <summary>
        ///     Expression that generate the type 
        /// </summary>
        public Func<S, string> name { get; set; }

        /// <summary>
        ///     defintions for the classes that should be added to actions created 
        /// from this definition
        /// </summary>
        public ICollection<Func<S, string>> classes { get; set; }

        /// <summary>
        ///     Expression that generates the url.
        /// </summary>
        public UrlDefinition url { get; set; } 
    }
}