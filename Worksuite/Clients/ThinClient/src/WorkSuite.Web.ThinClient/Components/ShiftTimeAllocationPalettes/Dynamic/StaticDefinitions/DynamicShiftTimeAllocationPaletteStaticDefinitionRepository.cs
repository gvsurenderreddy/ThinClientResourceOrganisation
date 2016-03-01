using System.Collections.ObjectModel;
using WTS.WorkSuite.Web.ThinClient.Components.ShiftTimeAllocationPalettes.Dynamic.StaticDefinitions.Actions;
using WTS.WorkSuite.Web.ThinClient.Components.ShiftTimeAllocationPalettes.Dynamic.StaticDefinitions.Model;

namespace WTS.WorkSuite.Web.ThinClient.Components.ShiftTimeAllocationPalettes.Dynamic.StaticDefinitions
{
    public class DynamicShiftTimeAllocationPaletteStaticDefinitionRepository<S>
    {
        public DynamicShiftTimeAllocationPaletteModelStaticDefinition<S> definition { get; private set; }

        public DynamicShiftTimeAllocationPaletteActionStaticDefinition<S> remove_action { get; set; }

        public DynamicShiftTimeAllocationPaletteActionStaticDefinition<S> remove_all_action { get; set; }

        public DynamicShiftTimeAllocationPaletteActionStaticDefinition<S> edit_all_action { get; set; }

        public DynamicShiftTimeAllocationPaletteActionStaticDefinition<S> edit_action { get; set; }

        public DynamicShiftTimeAllocationPaletteStaticDefinitionRepository()
        {
            definition = new DynamicShiftTimeAllocationPaletteModelStaticDefinition<S>()
            {
                classes = new Collection<string>(),
            };
        }
    }
}