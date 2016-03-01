using WorkSuite.Library.Asp.Net.Mvc.Presentation.Components.Subsystems.Routing._1;

namespace WorkSuite.Library.Asp.Net.Mvc.Presentation.Components.Tiles._1 {

    /// <summary>
    ///     Allows you to define the values that you want for a tile and then build the view model for it.
    /// </summary>
    public class TileViewModelBuilder {

        /// <summary>
        ///  Allows the title of the tile to be set
        /// </summary>
        public TileViewModelBuilder title
                                    ( string value ) {

            _title = value;
            return this;
        }

        /// <summary>
        /// Allows the route name for the tile to be set
        /// </summary>
        public TileViewModelBuilder route_name
                                     ( string value ) {

            _route_name = value;
            return this;
        }

        /// <summary>
        /// Allows the route parameters for the tile to be set
        /// </summary>
        public TileViewModelBuilder route_parameters
                                        ( object value ) {

            // Improve: This should really clone this object but that is more complex to implement than I have time for
            //          at the moment.

            _route_parameters = value;
            return this;
        }

        /// <summary>
        /// Sets the call to action type for tile, as a default tiles do not have a call to action,
        /// </summary>
        public TileViewModelBuilder call_to_action<T>() 
                                        where T : TileCallToActionModifier, new() {

            _call_to_action = new T();
            return this;
        }

        /// <summary>
        /// Builds the view model from the specified settings.
        /// </summary>
        public TileViewModel build () {
            
            return new TileViewModel {  
                title = _title,
                call_to_action = _call_to_action,
                route_request = new CreateRouteUrlRequest {
                    route_name = _route_name,
                    route_parameters = _route_parameters
                }
            };
        }

        // title that will be used when creating a 
        private string _title = string.Empty;

        // route name that will be used when building the tile 
        private string _route_name = string.Empty;

        // parameters which will be used when creating the route url from the routes url template
        private object _route_parameters = new {};

        // call to action modifier that will be used when building the tile. 
        private TileCallToActionModifier _call_to_action = new TileDoesNotHaveACallToAction();

    }
}
