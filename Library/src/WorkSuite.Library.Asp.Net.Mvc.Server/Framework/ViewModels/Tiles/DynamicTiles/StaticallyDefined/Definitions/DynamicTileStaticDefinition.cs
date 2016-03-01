using System;
using System.Collections.Generic;
using WorkSuite.Library.Asp.Net.Mvc.Server.Urls;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Tiles.DynamicTiles.StaticallyDefined.Definitions {

    /// <summary>
    ///     Definition for a dynamic tile. This definition is built statically.
    /// </summary>
    /// <typeparam name="S">
    ///     The model that the definition is for.
    /// </typeparam>
    public class DynamicTileStaticDefinition<S> {

        public Func<S, string> id { get; set; }
        public Func<S, string> title { get; set; }
        public ICollection<Func<S, string>> classes { get; set; }
        public UrlDefinition url { get; set; }

    }

}