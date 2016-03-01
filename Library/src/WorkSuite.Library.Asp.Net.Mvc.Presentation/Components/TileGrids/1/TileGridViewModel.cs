using System.Collections.Generic;
using WorkSuite.Library.Asp.Net.Mvc.Presentation.Components.ViewComponents._1;

namespace WorkSuite.Library.Asp.Net.Mvc.Presentation.Components.TileGrids._1 {

    /// <summary>
    /// View model for the tile grid component.
    /// </summary>
    public class TileGridViewModel
                    : IComponentViewModel {
        
        /// <summary>
        /// List of sections defined for the grid.
        /// </summary>
        public IEnumerable<TileGridSectionViewModel> sections { get; set;}

    }
}
