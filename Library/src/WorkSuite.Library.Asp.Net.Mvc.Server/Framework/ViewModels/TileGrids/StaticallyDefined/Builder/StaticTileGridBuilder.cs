using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.TileGrids.StaticallyDefined.Metadata.Model;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Tiles.StaticTiles.StaticallyDefined;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.TileGrids.StaticallyDefined.Builder {

    /// <summary>
    ///     Builds a tile grid from statically defined metadata.
    /// </summary>
    public class StaticTileGridBuilder {

        /// <summary>
        ///     Builds a tile grid that from the supplied metadata.
        /// </summary>
        /// <param name="tile_grid_metadata">
        ///     The metadata that the tile grid should be built from.
        /// </param>
        /// <returns>
        ///     The tile grid built from the supplied metadata.
        /// </returns>
        public TileGrid build
                            ( StaticTileGridMetadata tile_grid_metadata ) {

            Guard.IsNotNull( tile_grid_metadata, "tile_grid_metadata" );

            var tile_builder = new BuildStaticTileFromStaticDefinition();

            return new TileGrid {
                title = tile_grid_metadata.title != null ? tile_grid_metadata.title() : string.Empty,
                classes = tile_grid_metadata.classes.Select( ce => ce() ).ToList(),
                tiles = tile_grid_metadata.tiles.Select( tile_builder.build ),
            };
        }
    }
}