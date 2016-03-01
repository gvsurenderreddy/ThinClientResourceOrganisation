using System.Collections.Generic;
using System.Collections.ObjectModel;
using WTS.WorkSuite.Web.ThinClient.Components.WhiteSpaceTimeAllocationPalettes.Dynamic.StaticDefinitions.Actions;
using WTS.WorkSuite.Web.ThinClient.Components.WhiteSpaceTimeAllocationPalettes.Dynamic.StaticDefinitions.Model;

namespace WTS.WorkSuite.Web.ThinClient.Components.WhiteSpaceTimeAllocationPalettes.Dynamic.StaticDefinitions
{
    public class DynamicWhiteSpaceTimeAllocationPaletteStaticDefinitionRepository<S>
    {
        public DynamicWhiteSpaceTimeAllocationPaletteModelStaticDefinition definition { get; private set; }

        public ICollection<DynamicWhiteSpaceTimeAllocationPaletteActionStaticDefinition<S>> actions { get; set; }

        public DynamicWhiteSpaceTimeAllocationPaletteStaticDefinitionRepository()
        {
            definition = new DynamicWhiteSpaceTimeAllocationPaletteModelStaticDefinition()
            {
                classes = new Collection<string>(),
            };

            actions = new Collection<DynamicWhiteSpaceTimeAllocationPaletteActionStaticDefinition<S>>();
        }
    }
}