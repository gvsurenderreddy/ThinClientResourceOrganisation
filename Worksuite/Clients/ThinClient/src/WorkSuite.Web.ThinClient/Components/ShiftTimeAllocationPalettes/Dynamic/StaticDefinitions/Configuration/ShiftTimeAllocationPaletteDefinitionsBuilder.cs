using System.ComponentModel.Composition;
using System.Web.Mvc;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Web.ThinClient.Components.ShiftTimeAllocationPalettes.Dynamic.StaticDefinitions.Actions;
using WTS.WorkSuite.Web.ThinClient.Components.ShiftTimeAllocationPalettes.Dynamic.StaticDefinitions.Model;

namespace WTS.WorkSuite.Web.ThinClient.Components.ShiftTimeAllocationPalettes.Dynamic.StaticDefinitions.Configuration
{
    [InheritedExport(typeof(IShiftTimeAllocationPaletteDefinitionsBuilder))]
    public abstract class ShiftTimeAllocationPaletteDefinitionsBuilder<S> : IShiftTimeAllocationPaletteDefinitionsBuilder
    {
        public void build(IDependencyResolver resolver)
        {
            Guard.IsNotNull(resolver, "resolver");

            var model_definitions_builder = resolver.GetService<DynamicShiftTimeAllocationPaletteModelStaticDefinitionBuilder<S>>();
            build_model_definitions(model_definitions_builder);


            var actions_definitions_builder = resolver.GetService<DynamicShiftTimeAllocationPaletteActionsStaticDefinitionBuilder<S>>();
            build_action_definitions(actions_definitions_builder);
        }

        protected abstract void build_model_definitions(DynamicShiftTimeAllocationPaletteModelStaticDefinitionBuilder<S> model_definitions_builder);

        protected abstract void build_action_definitions(DynamicShiftTimeAllocationPaletteActionsStaticDefinitionBuilder<S> actions_definitions_builder);

    }
}