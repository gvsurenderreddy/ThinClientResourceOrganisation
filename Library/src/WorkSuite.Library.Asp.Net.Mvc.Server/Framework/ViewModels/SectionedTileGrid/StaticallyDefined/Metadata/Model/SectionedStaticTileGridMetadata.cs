using System;
using System.Collections.Generic;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.TileGrids.StaticallyDefined.Metadata.Model;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.SectionedTileGrid.StaticallyDefined.Metadata.Model {
    public class SectionedStaticTileGridMetadata {

        public IEnumerable<StaticTileGridMetadata> sections { get; set; }
        public IEnumerable<Func<string>> classes { get; set; } 
    }
}