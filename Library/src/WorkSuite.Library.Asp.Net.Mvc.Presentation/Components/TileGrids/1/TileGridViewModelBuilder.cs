using System.Collections.Generic;
using System.Linq;

using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WorkSuite.Library.Asp.Net.Mvc.Presentation.Components.TileGrids._1 {


    /// <summary>
    ///     Allows you to add sections to a tile grid.
    /// </summary>
    public class TileGridViewModelBuilder {

        /// <summary>
        /// Adds a section to a tile grid.
        /// </summary>
        public TileGridViewModelBuilder add_section
                                            ( TileGridSectionViewModel view_model ) {

            Guard.IsNotNull( view_model, "view_model" );

            sections.Add( view_model );
            return this;
        }

        /// <summary>
        /// Creates an instance of the ViewModel as it stands.
        /// </summary>
        public TileGridViewModel build () {

            return new TileGridViewModel {
                sections = sections.ToList(),
            };
        }

        // sections that will be included in the tile grid view model when it is built
        private List<TileGridSectionViewModel> sections = new List<TileGridSectionViewModel>();
    }
}
