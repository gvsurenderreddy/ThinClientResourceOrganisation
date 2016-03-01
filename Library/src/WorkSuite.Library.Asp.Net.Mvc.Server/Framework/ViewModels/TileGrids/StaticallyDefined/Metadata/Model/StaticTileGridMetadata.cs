using System;
using System.Collections.Generic;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Tiles.StaticTiles.StaticallyDefined.Definitions;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.TileGrids.StaticallyDefined.Metadata.Model {

    /// <summary>
    ///     Metadata for a statically defined tile grid
    /// </summary>
    public class StaticTileGridMetadata {

        /// <summary>
        ///     title of the grid
        /// </summary>
        public Func<string> title { get; set; }

        /// <summary>
        ///     class that are associated with this grid
        /// </summary>
        public IEnumerable<Func<string>> classes { get; set; }

        /// <summary>
        ///     Tiles that are included in the gird
        /// </summary>
        public IEnumerable<StaticTileStaticDefinition> tiles { get; set; }
    }
}