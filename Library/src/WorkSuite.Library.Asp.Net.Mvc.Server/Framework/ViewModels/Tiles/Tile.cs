using System.Collections.Generic;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Tiles {

    /// <summary>
    ///     Tile view model, should contrian all details needed to 
    /// write the html for a tile
    /// </summary>
    public class Tile 
                    : IsAViewElement {


        /// <summary>
        ///     Tile identity, should be unique
        /// </summary>
        public string id { get; set; }

        /// <summary>
        ///     Url of the page that you expect the tile to take you to.
        /// </summary>
        public string url { get; set; }

        /// <summary>
        ///     Title that will be displayed for the tile.
        /// </summary>
        public string title { get; set; }

        /// <summary>
        ///     List of classes that are associated with the tile.
        /// </summary>
        public IEnumerable<string> classes { get; set; }

        /// <summary>
        ///     Field that should displayed in the tile
        /// </summary>
        public IEnumerable<TileField> fields { get; set; }

    }
}