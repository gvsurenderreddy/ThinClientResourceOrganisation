using System;
using System.Collections.Generic;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.ContentHeaders.Dynamic.StaticDefinitions.Definitions {

    /// <summary>
    ///     Definition for a content header that will be built from a model
    /// </summary>
    /// <typeparam name="S">
    ///     The type of the model that the content headed definition is for
    /// </typeparam>
    public class DynamicContentHeaderStaticDefinition<S> {

        /// <summary>
        ///     Expression that will generate the Content header title
        /// </summary>
        public Func<S, string> title { get; set; } 

        /// <summary>
        ///     Expression that will generate the Content header title
        /// </summary>        
        public ICollection<Func<S, string>> classes { get; set; }
    }
}