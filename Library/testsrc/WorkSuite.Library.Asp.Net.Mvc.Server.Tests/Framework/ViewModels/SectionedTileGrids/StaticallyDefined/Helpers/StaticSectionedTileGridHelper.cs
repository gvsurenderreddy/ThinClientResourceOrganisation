using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.SectionedTileGrid;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.SectionedTileGrid.StaticallyDefined.Builder;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.SectionedTileGrid.StaticallyDefined.Metadata;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Tests.Framework.ViewModels.SectionedTileGrids.StaticallyDefined.Helpers {

    public class StaticSectionedTileGridHelper {

        public StaticSectionedTileGridMetadataBuilder metadata_builder { get; private set; }
        public StaticSectionedTileGridBuilder view_model_builder { get; private set; }

        public SectionedTileGrid sectioned_tile_grid {
            get { return view_model_builder.build( metadata_builder .build() ); }
        }

        public StaticSectionedTileGridHelper() {
            metadata_builder = new StaticSectionedTileGridMetadataBuilder();
            view_model_builder = new StaticSectionedTileGridBuilder();
        }

    }
}