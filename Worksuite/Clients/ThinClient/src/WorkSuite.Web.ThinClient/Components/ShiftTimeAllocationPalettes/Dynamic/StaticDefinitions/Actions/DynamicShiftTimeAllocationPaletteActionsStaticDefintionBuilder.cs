using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.UserActions;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Web.ThinClient.Components.ShiftTimeAllocationPalettes.Dynamic.StaticDefinitions.Actions {

    public class DynamicShiftTimeAllocationPaletteActionsStaticDefinitionBuilder<S> 
    {
        public DynamicShiftTimeAllocationPaletteActionStaticDefinitionBuilder<S> new_action<T>() where T : CommonActionDefinition, new() 
        {

            var action_definition_template = new T();
            var action_definition_builder = new DynamicShiftTimeAllocationPaletteActionStaticDefinitionBuilder<S>(action_definition => repository.remove_action = action_definition);

            action_definition_builder
                .title(m => action_definition_template.title )
                .name(m => action_definition_template.action_name )
                ;

            return action_definition_builder;
        }

        public DynamicShiftTimeAllocationPaletteActionStaticDefinitionBuilder<S> remove_all_action<T>() where T : CommonActionDefinition, new()
        {

            var action_definition_template = new T();
            var action_definition_builder = new DynamicShiftTimeAllocationPaletteActionStaticDefinitionBuilder<S>(action_definition => repository.remove_all_action = action_definition);

            action_definition_builder
                .title(m => action_definition_template.title)
                .name(m => action_definition_template.action_name)
                ;

            return action_definition_builder;
        }

        public DynamicShiftTimeAllocationPaletteActionStaticDefinitionBuilder<S> edit_all_action<T>() where T : CommonActionDefinition, new()
        {

            var action_definition_template = new T();
            var action_definition_builder = new DynamicShiftTimeAllocationPaletteActionStaticDefinitionBuilder<S>(action_definition => repository.edit_all_action = action_definition);

            action_definition_builder
                .title(m => action_definition_template.title)
                .name(m => action_definition_template.action_name)
                ;

            return action_definition_builder;
        }

        public DynamicShiftTimeAllocationPaletteActionStaticDefinitionBuilder<S> edit_action<T>() where T : CommonActionDefinition, new()
        {

            var action_definition_template = new T();
            var action_definition_builder = new DynamicShiftTimeAllocationPaletteActionStaticDefinitionBuilder<S>(action_definition => repository.edit_action = action_definition);

            action_definition_builder
                .title(m => action_definition_template.title)
                .name(m => action_definition_template.action_name)
                ;

            return action_definition_builder;
        }

        public DynamicShiftTimeAllocationPaletteActionsStaticDefinitionBuilder ( DynamicShiftTimeAllocationPaletteStaticDefinitionRepository<S> the_repository ) 
        {
            repository = Guard.IsNotNull( the_repository, "the_repository" );
        }

        private readonly DynamicShiftTimeAllocationPaletteStaticDefinitionRepository<S> repository; 
    }
}