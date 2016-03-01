using System.Collections.Generic;

using WorkSuite.Library.Asp.Net.Mvc.Presentation.Components.ViewComponents._1;

namespace WorkSuite.Library.Asp.Net.Mvc.Presentation.Components.TileGrids._1 {

    /// <summary>
    /// View model for a tile grid section
    /// </summary>
    public class TileGridSectionViewModel {

        /// <summary>
        ///    The title that is displayed for the tile grid section
        /// </summary>
        public string title { get; set; }

        /// <summary>
        ///     The list of tiles that are to be displayed in this section.
        /// </summary>
        public IEnumerable<IComponentViewModel> tiles {  get; set; }
    }
}
