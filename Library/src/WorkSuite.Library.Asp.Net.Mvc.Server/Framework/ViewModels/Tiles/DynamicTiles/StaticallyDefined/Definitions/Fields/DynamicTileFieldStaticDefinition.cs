using System;
using System.Collections.Generic;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Tiles.DynamicTiles.StaticallyDefined.Definitions.Fields {

    /// <summary>
    ///     Defintion for a dynamic field for a tile that is created via 
    /// a static configuration.  i.e. it is created via a builder in code
    /// rather than being read from a service layer.
    /// </summary>
    /// <typeparam name="S">
    ///     The model of the dynamic tile
    /// </typeparam>
    public class DynamicTileFieldStaticDefinition<S> {


        /// <summary>
        ///     The name that will be given to fields built from this definition
        /// </summary>
        public string field_name { get; set; }


        /// <summary>
        ///     Collection of class name generators that create the clases that
        /// are assigned to the field.
        /// </summary>
        public ICollection<Func<S,string>> classes { get; set; }


        /// <summary>
        ///     Expression that generates the title for the field
        /// </summary>
        public Func<S, string> title { get; set; }

    }

}