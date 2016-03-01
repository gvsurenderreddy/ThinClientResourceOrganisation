using System;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Tiles.StaticTiles.StaticallyDefined.Definitions;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.TileGrids.StaticallyDefined.Metadata {

    public class StaticTileGridTileMetadataBuilder
                    : BaseStaticTileStaticDefinitionBuilder<StaticTileGridTileMetadataBuilder> {

        /// <summary>
        ///     Adds the tile to the grid
        /// </summary>
        public void add () {
            add_tile_to_grid( build() );
        }

        public StaticTileGridTileMetadataBuilder
                ( Action<StaticTileStaticDefinition> add_tile_to_grid_delegate ) {
            
            add_tile_to_grid = Guard.IsNotNull(add_tile_to_grid_delegate, "add_tile_to_grid_delegate");
        }

        //
        private readonly Action<StaticTileStaticDefinition> add_tile_to_grid;
    }
}