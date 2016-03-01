using System.Collections.Generic;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Tiles;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.TileGrids {

    /// <summary>
    ///     Tile grid
    /// </summary>
    /// <remarks>
    ///     The 'Anatomy of a Page' document is the souce for all our view models
    /// definitions.
    /// </remarks>
    public class TileGrid 
                    : IsAViewElement {

        /// <summary>
        ///     Title that is displayed for the grid.
        /// </summary>
        public string title { get; set; }

        /// <summary>
        ///     Classes that are associated with a tile grid
        /// </summary>
        public IEnumerable<string> classes { get; set; }

        /// <summary>
        ///     Tile that should appear on the grid.
        /// </summary>
        public IEnumerable<Tile> tiles { get; set; }

    }
}