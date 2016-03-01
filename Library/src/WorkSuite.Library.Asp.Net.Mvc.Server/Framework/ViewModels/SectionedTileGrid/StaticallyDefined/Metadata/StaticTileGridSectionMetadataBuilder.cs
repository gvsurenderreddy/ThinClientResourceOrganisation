using System;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.TileGrids.StaticallyDefined.Metadata;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.TileGrids.StaticallyDefined.Metadata.Model;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.SectionedTileGrid.StaticallyDefined.Metadata {
    public class StaticTileGridSectionMetadataBuilder
        : BaseStaticTileGridMetadataBuilder<StaticTileGridSectionMetadataBuilder> {


        public void add () {
            add_section_to_grid( build() );
        }

        public StaticTileGridSectionMetadataBuilder 
            ( Action<StaticTileGridMetadata> add_section_to_grid_delegate ) {
            
            add_section_to_grid = Guard.IsNotNull( add_section_to_grid_delegate, "add_section_to_grid_delegate");
        }

        private Action<StaticTileGridMetadata> add_section_to_grid;
    }
}