using System;
using System.Collections.ObjectModel;
using System.Linq;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Tiles.StaticTiles.StaticallyDefined.Definitions;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Tiles.StaticTiles.StaticallyDefined {

    /// <summary>
    ///     Builds a tile from statically defined metadata
    /// </summary>
    public class BuildStaticTileFromStaticDefinition {

        /// <summary>
        ///     Builds a tile from the metadata supplied.
        /// </summary>
        /// <param name="metadata">
        ///     The metadata that defines all the data needed to build the tile.
        /// </param>
        /// <returns>
        ///     The tile that has been built from the supplied metadata.
        /// </returns>
        public Tile build 
                        ( StaticTileStaticDefinition metadata ) {

            return new Tile {

                id = metadata.id.value_or_default( string.Empty ),
                url = metadata.url.value_or_default( string.Empty ),
                title = metadata.title.value_or_default( string.Empty ),
                classes = metadata.classes.Select(e => e()).ToList(),
                fields = new Collection<TileField>(),

            };
        }

        // used to safely return the value of an expression or a default value. 
        // By safe I mean avoid null pointer exceptions.
        private string value_or_default
                        ( Func<string> expression
                        , string default_value ) {

            return expression != null ? expression() : default_value;
        }
    }
}