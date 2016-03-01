using System;
using System.Collections.Generic;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Tiles.StaticTiles.StaticallyDefined.Definitions {


    /// <summary>
    ///     Metadata needed when building a tile from static content
    /// </summary>
    public class StaticTileStaticDefinition {

        /// <summary>
        ///     Expression that returns the tile's id 
        /// </summary>
        public Func<string> id { get; set; }


        /// <summary>
        ///     Expression that returns the tile url
        /// </summary>
        public Func<string> url { get; set; }


        /// <summary>
        ///     Expression that returns the title of the model
        /// </summary>
        public Func<string> title { get; set; }


        /// <summary>
        ///     Classes that should be applied to this tile
        /// </summary>
        public IEnumerable<Func<string>> classes { get; set; }

    }
}