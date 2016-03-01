using System.Collections.Generic;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.TileGrids;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.SectionedTileGrid {

    public class SectionedTileGrid
                    : IsAViewElement {

        public IEnumerable<TileGrid> sections { get; set; }
        public IEnumerable<string> classes { get; set; }
    }
}