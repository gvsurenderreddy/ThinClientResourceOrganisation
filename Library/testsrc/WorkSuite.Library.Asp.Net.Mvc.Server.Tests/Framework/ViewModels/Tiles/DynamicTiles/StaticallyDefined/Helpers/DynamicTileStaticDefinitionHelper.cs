using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Tiles;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Tiles.DynamicTiles.StaticallyDefined;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Tiles.DynamicTiles.StaticallyDefined.Definitions;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Tiles.DynamicTiles.StaticallyDefined.Definitions.Fields;
using WorkSuite.Library.Asp.Net.Mvc.Server.Tests.Framework.ViewModels.Helpers;
using WorkSuite.Library.Asp.Net.Mvc.Server.Urls;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Tests.Framework.ViewModels.Tiles.DynamicTiles.StaticallyDefined.Helpers {

    /// <summary>
    ///     Helper for tests for dynamic tiles that are built from static
    /// definitions. 
    /// </summary>
    /// <typeparam name="S">
    ///     The model that the dynamic data for the tile to read from.
    /// </typeparam>
    public class DynamicTileStaticDefinitionHelper<S> {

        public FakeRouteBuilder route_builder { get; private set; }
        public DynamicTileStaticDefinitionBuilder<S> definition_builder { get; private set; }
        public DynamicTileFieldsStaticDefinitionBuilder<S> fields_definition_builder { get; private set; }
        public S model { get; set; }
        public Tile tile {
            get {
                return tile_builder.build(model);
            }
        }

        public DynamicTileStaticDefinitionHelper ( ) {
            route_builder = new FakeRouteBuilder();
            
            var definition_repository = new DynamicTileStaticDefinitionRepository<S>();
            var url_builder = new BuildUrlFromDefinition<S>( route_builder );

            definition_builder = new DynamicTileStaticDefinitionBuilder<S>( definition_repository );
            fields_definition_builder = new DynamicTileFieldsStaticDefinitionBuilder<S>( definition_repository );
            tile_builder = new BuildDynamicTileFromStaticDefinition<S>
                                    ( definition_repository
                                    , url_builder
                                    , route_builder );
        }

        private readonly BuildDynamicTileFromStaticDefinition<S> tile_builder;
    }

}