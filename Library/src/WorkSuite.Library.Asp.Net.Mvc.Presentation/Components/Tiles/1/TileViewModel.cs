using WorkSuite.Library.Asp.Net.Mvc.Presentation.Components.Subsystems.Routing._1;
using WorkSuite.Library.Asp.Net.Mvc.Presentation.Components.ViewComponents._1;

namespace WorkSuite.Library.Asp.Net.Mvc.Presentation.Components.Tiles._1 {          

    /// <summary>
    ///     Version one of the Tile component view model
    /// </summary>
    public class TileViewModel 
                    : IComponentViewModel{

        /// <summary>
        /// Text that is displayed to inform the user what the purpose of clicking on
        /// the tile is.
        /// </summary>
        public string title { get; set; }

        /// <summary>
        /// The route request used for the model
        /// </summary>
        public CreateRouteUrlRequest route_request { get; set;  }

        /// <summary>
        /// The call to action for the tile.
        /// </summary>
        public TileCallToActionModifier call_to_action { get; set; }
    }
}