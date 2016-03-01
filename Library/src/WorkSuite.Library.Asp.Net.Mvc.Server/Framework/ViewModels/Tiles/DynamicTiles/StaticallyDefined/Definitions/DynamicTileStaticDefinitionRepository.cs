using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Tiles.DynamicTiles.StaticallyDefined.Definitions.Fields;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Tiles.DynamicTiles.StaticallyDefined.Definitions {

    /// <summary>
    ///     Repository that stores a staticaly defined defintion for a dynamic tile.
    /// </summary>
    /// <typeparam name="S">
    ///     The type of the model for the dynamic tile
    /// </typeparam>
    public class DynamicTileStaticDefinitionRepository<S> {

        public DynamicTileStaticDefinition<S> definition { get; private set; }
        public ICollection<DynamicTileFieldStaticDefinition<S>> fields { get; private set; }

        public DynamicTileStaticDefinitionRepository ( ) {
            definition = new DynamicTileStaticDefinition<S>{
                classes = new Collection<Func<S, string>>(),
            };
            fields = new Collection<DynamicTileFieldStaticDefinition<S>>();
        }
    }

}