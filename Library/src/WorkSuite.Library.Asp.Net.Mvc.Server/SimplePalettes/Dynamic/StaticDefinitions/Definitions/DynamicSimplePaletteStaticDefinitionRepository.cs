using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using WorkSuite.Library.Asp.Net.Mvc.Server.SimplePalettes.Dynamic.StaticDefinitions.Definitions.Actions;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.SimplePalettes.Dynamic.StaticDefinitions.Definitions {

    public class DynamicSimplePaletteStaticDefinitionRepository<S> {

        /// <summary>
        ///     Model defintion for the simple palette
        /// </summary>
        public DynamicSimplePaletteStaticDefinition<S> definition { get; private set; }


        /// <summary>
        ///     Action definitions that are associated with the palette
        /// </summary>
        public ICollection<DynamicSimplePaletteActionStaticDefintion<S>> actions { get; set; }


        public DynamicSimplePaletteStaticDefinitionRepository()
        {
            definition = new DynamicSimplePaletteStaticDefinition<S> {
                classes = new Collection<Func<S,string>>(),
            };
            actions = new Collection<DynamicSimplePaletteActionStaticDefintion<S>>();
        }


    }
}