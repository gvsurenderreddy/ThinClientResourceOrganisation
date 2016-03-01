using System;
using System.Collections.ObjectModel;
using System.Linq;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.SectionedTileGrid.StaticallyDefined.Metadata.Model;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.TileGrids.StaticallyDefined.Metadata.Model;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.SectionedTileGrid.StaticallyDefined.Metadata {

    public class StaticSectionedTileGridMetadataBuilder {

        public StaticTileGridSectionMetadataBuilder new_section 
                                                        ( string section_title ) {
            
            var section_builder = new StaticTileGridSectionMetadataBuilder( m => sections.Add( m ));

            return section_builder
                        .title( section_title )
                        ;
        }

        public StaticSectionedTileGridMetadataBuilder add_class
                                                        ( string class_to_add ) {

            classes.Add( () => class_to_add );
            return this;
        }

        public StaticSectionedTileGridMetadataBuilder add_class
                                                        ( Func<string> class_expression ) {

            classes.Add( class_expression );
            return this;
        }

        public SectionedStaticTileGridMetadata build() {

            return new SectionedStaticTileGridMetadata {
                sections = sections.ToList(),
                classes = classes.ToList(),
            };
        }

        private readonly Collection<StaticTileGridMetadata> sections = new Collection<StaticTileGridMetadata>();
        private readonly Collection<Func<string>> classes = new Collection<Func<string>>();
    }
}