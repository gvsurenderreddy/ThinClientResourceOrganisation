using System.Collections.Generic;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Tiles {

    /// <summary>
    ///     Represents fields for a tile
    /// </summary>
    public class TileField {


        /// <summary>
        ///     The name of the field
        /// </summary>
        public string name { get; set; }

        /// <summary>
        ///     Collection of classes that should be applied to the field
        /// </summary>
        public IEnumerable<string> classes { get; set; }

        /// <summary>
        ///     The fields title
        /// </summary>
        public string title { get; set; }
    }

}