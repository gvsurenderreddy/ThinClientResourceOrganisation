using System.ComponentModel.Composition;
using System.Web.Mvc;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Web.ThinClient.Components.WhiteSpaceTimeAllocationPalettes.Dynamic.StaticDefinitions.Actions;
using WTS.WorkSuite.Web.ThinClient.Components.WhiteSpaceTimeAllocationPalettes.Dynamic.StaticDefinitions.Model;

namespace WTS.WorkSuite.Web.ThinClient.Components.WhiteSpaceTimeAllocationPalettes.Dynamic.StaticDefinitions.Configuration
{
    [InheritedExport(typeof(IWhiteSpaceTimeAllocationPaletteDefinitionsBuilder))]
    public abstract class WhiteSpaceTimeAllocationPaletteDefinitionsBuilder<S> : IWhiteSpaceTimeAllocationPaletteDefinitionsBuilder
    {
        public void build(IDependencyResolver resolver)
        {
            Guard.IsNotNull(resolver, "resolver");

            var model_definitions_builder = resolver.GetService<DynamicWhiteSpaceTimeAllocationPaletteModelStaticDefinitionBuilder<S>>();
            build_model_definitions(model_definitions_builder);


            var actions_definitions_builder = resolver.GetService<DynamicWhiteSpaceTimeAllocationPaletteActionsStaticDefinitionBuilder<S>>();
            build_action_definitions(actions_definitions_builder);
        }

        protected abstract void build_model_definitions(DynamicWhiteSpaceTimeAllocationPaletteModelStaticDefinitionBuilder<S> model_definitions_builder);

        protected abstract void build_action_definitions(DynamicWhiteSpaceTimeAllocationPaletteActionsStaticDefinitionBuilder<S> actions_definitions_builder);

    }
}