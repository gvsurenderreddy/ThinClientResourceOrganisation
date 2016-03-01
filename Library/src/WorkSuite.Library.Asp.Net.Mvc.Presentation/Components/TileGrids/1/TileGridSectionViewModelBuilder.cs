using System.Collections.Generic;
using System.Linq;

using WorkSuite.Library.Asp.Net.Mvc.Presentation.Components.ViewComponents._1;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WorkSuite.Library.Asp.Net.Mvc.Presentation.Components.TileGrids._1 {


    /// <summary>
    ///     Allows you to define the title and tiles that will be in a section on a tile grid.
    /// </summary>
    public class TileGridSectionViewModelBuilder {

        /// <summary>
        /// Set the title of the tile grid section
        /// </summary>
        public TileGridSectionViewModelBuilder title
                                                ( string value ) {
            _title = value;
            return this;
        }

        /// <summary>
        /// Adds a title to tile grid section.
        /// </summary>
        public TileGridSectionViewModelBuilder add_tile
                                                ( IComponentViewModel view_model ) {

            Guard.IsNotNull( view_model, "view_model" );

            view_models.Add( view_model ); 
            return this;
        }

        /// <summary>
        /// Creates an instance of the ViewModel as it stands.
        /// </summary>
        public TileGridSectionViewModel build () {

            return new TileGridSectionViewModel {
                title = _title,
                tiles = view_models.ToList(), // make sure we create a new list with just the tile that have been added up to this point.
            };
        }


        // section title used when building the view model
        private string _title = string.Empty;

        // list of tiles that will be included in the view model when building.
        private List<IComponentViewModel> view_models = new List<IComponentViewModel>();
    }
}
