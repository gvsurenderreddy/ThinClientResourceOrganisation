using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Tiles;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Tiles.StaticTiles.StaticallyDefined;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Tiles.StaticTiles.StaticallyDefined.Definitions;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Tests.Framework.ViewModels.Tiles.StaticTiles.StaticallyDefined.Helpers {

    public class StaticTileHelper {

        public StaticTileStaticDefinitionBuilder model_metadata_builder { get; private set; }
        public BuildStaticTileFromStaticDefinition tile_builder { get; set; }

        public Tile tile {
            get { return tile_builder.build(model_metadata_builder.build()); }
        }

        public StaticTileHelper () {
            model_metadata_builder = new StaticTileStaticDefinitionBuilder();
            tile_builder = new BuildStaticTileFromStaticDefinition();
        }

    }
}