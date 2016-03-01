using System.Collections.Generic;
using System.Collections.ObjectModel;
using WorkSuite.Library.Asp.Net.Mvc.Server.DateRangePalettes.Dynamic.StaticDefinitions.Actions;
using WorkSuite.Library.Asp.Net.Mvc.Server.DateRangePalettes.Dynamic.StaticDefinitions.Model;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.DateRangePalettes.Dynamic.StaticDefinitions
{
    public class DynamicDateRangePaletteStaticDefinitionRepository<S>
    {
        public DynamicDateRangePaletteStaticDefinition<S> definition { get; private set; }

        public ICollection<DynamicDateRangePaletteActionStaticDefinition<S>> actions { get; set; }

        public DynamicDateRangePaletteStaticDefinitionRepository()
        {
            definition = new DynamicDateRangePaletteStaticDefinition<S>();

            actions = new Collection<DynamicDateRangePaletteActionStaticDefinition<S>>();
        }
    }
}