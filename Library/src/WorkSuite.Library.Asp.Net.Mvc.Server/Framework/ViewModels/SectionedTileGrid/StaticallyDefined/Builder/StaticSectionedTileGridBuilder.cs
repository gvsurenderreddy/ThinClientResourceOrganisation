using System.Linq;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.SectionedTileGrid.StaticallyDefined.Metadata.Model;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.TileGrids.StaticallyDefined.Builder;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.SectionedTileGrid.StaticallyDefined.Builder {

    /// <summary>
    ///     Creates sectioned tile grids from statically defined metadata
    /// </summary>
    public class StaticSectionedTileGridBuilder {

        public SectionedTileGrid build 
                                    ( SectionedStaticTileGridMetadata metadata ) {

            var tile_grid_builder = new StaticTileGridBuilder();

            return new SectionedTileGrid {
                sections = metadata.sections.Select( tile_grid_builder.build ).ToList(),
                classes = metadata.classes.Select( ce => ce() ).ToList(),
            };
        }
    }

}