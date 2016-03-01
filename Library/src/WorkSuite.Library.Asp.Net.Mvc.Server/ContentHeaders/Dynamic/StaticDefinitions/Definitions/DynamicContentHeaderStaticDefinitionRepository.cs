using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using WorkSuite.Library.Asp.Net.Mvc.Server.ContentHeaders.Dynamic.StaticDefinitions.Definitions.Actions;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.ContentHeaders.Dynamic.StaticDefinitions.Definitions {

    public class DynamicContentHeaderStaticDefinitionRepository<S> {

        /// <summary>
        ///     Model defintion for the content header
        /// </summary>
        public DynamicContentHeaderStaticDefinition<S> definition { get; private set; }

        /// <summary>
        ///     Action definitions that are associated with the header
        /// </summary>
        public ICollection<DynamicContentHeaderActionStaticDefintion<S>> actions { get; set; }


        public DynamicContentHeaderStaticDefinitionRepository () {
            definition = new DynamicContentHeaderStaticDefinition<S> {
                classes = new Collection<Func<S,string>>(),
            };
            actions = new Collection<DynamicContentHeaderActionStaticDefintion<S>>();
        }


    }
}