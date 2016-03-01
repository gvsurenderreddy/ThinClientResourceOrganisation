using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.TileGrids;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.TileGrids.StaticallyDefined.Builder;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.TileGrids.StaticallyDefined.Metadata;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Tests.Framework.ViewModels.TileGrids.StaticallyDefined.Helpers {

    public class StaticTileGridHelper {

        public StaticTileGridMetadataBuilder metadata_builder { get; private set; }
        public StaticTileGridBuilder view_model_builder { get; private set; }

        public TileGrid tile_grid {
            get { return view_model_builder.build( metadata_builder .build() ); }
        }

        public StaticTileGridHelper() {
            metadata_builder = new StaticTileGridMetadataBuilder();
            view_model_builder = new StaticTileGridBuilder();
        }
    }
}