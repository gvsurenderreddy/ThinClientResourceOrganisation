using System;
using System.Collections.Generic;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.SimplePalettes.Dynamic.StaticDefinitions.Definitions {

    /// <summary>
    ///     Definition for a simple palette that will be built from a model
    /// </summary>
    /// <typeparam name="S">
    ///     The type of the model that the content headed definition is for
    /// </typeparam>
    public class DynamicSimplePaletteStaticDefinition<S> {

        /// <summary>
        ///     Expression that will generate the Simple Palette title
        /// </summary>
        public Func<S, string> title { get; set; }

        /// <summary>
        ///     Expression that will generate the Simple Palette description
        /// </summary>
        public Func<S, string> description { get; set; }

        /// <summary>
        ///     Expression that will generate the Simple Palette title
        /// </summary>        
        public ICollection<Func<S, string>> classes { get; set; }
    }
}