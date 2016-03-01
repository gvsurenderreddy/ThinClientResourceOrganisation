using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.TileGrids.StaticallyDefined.Metadata.Model;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Tiles.StaticTiles.StaticallyDefined.Definitions;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.TileGrids.StaticallyDefined.Metadata {

    public abstract class BaseStaticTileGridMetadataBuilder<ConcreteBuilder>
        where ConcreteBuilder : BaseStaticTileGridMetadataBuilder<ConcreteBuilder> {


        public ConcreteBuilder title
                                ( string value ) {

            grid_tile = () => value;
            return (ConcreteBuilder)this;
        }

        public ConcreteBuilder title
                                ( Func<string> value ) {

            grid_tile = Guard.IsNotNull(value, "value");
            return (ConcreteBuilder)this;
        }


        public ConcreteBuilder add_class
                                ( string class_name ) {

            classes.Add( () => class_name );
            return (ConcreteBuilder)this;
        }


        public ConcreteBuilder add_class
                                    ( Func<string> class_expression) {

            classes.Add( class_expression );
            return (ConcreteBuilder)this;
        }
        public StaticTileGridTileMetadataBuilder new_tile()
        {
            return new StaticTileGridTileMetadataBuilder(m => tiles.Add(m));
        }

        public StaticTileGridMetadata build() {

            return new StaticTileGridMetadata
            {
                title = grid_tile,
                classes = classes.ToList(  ),
                tiles = tiles.ToList(),
            };
        }

        private Func<string> grid_tile = () => string.Empty;
        private readonly ICollection<StaticTileStaticDefinition> tiles = new Collection<StaticTileStaticDefinition>();
        private readonly ICollection<Func<string>> classes = new Collection<Func<string>>();
    }
}