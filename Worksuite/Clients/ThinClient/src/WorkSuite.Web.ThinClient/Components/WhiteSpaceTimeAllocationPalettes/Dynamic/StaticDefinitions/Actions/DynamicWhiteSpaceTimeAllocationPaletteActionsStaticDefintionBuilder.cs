using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.UserActions;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Web.ThinClient.Components.WhiteSpaceTimeAllocationPalettes.Dynamic.StaticDefinitions.Actions {

    public class DynamicWhiteSpaceTimeAllocationPaletteActionsStaticDefinitionBuilder<S> 
    {
        public DynamicWhiteSpaceTimeAllocationPaletteActionStaticDefinitionBuilder<S> new_action<T>() where T : CommonActionDefinition, new() 
        {

            var action_definition_template = new T();
            var action_definition_builder = new DynamicWhiteSpaceTimeAllocationPaletteActionStaticDefinitionBuilder<S>(action_definition => repository.actions.Add(action_definition));

            action_definition_builder
                .title(m => action_definition_template.title )
                .name(m => action_definition_template.action_name )
                ;

            return action_definition_builder;
        }

        public DynamicWhiteSpaceTimeAllocationPaletteActionsStaticDefinitionBuilder ( DynamicWhiteSpaceTimeAllocationPaletteStaticDefinitionRepository<S> the_repository ) 
        {
            repository = Guard.IsNotNull( the_repository, "the_repository" );
        }

        private readonly DynamicWhiteSpaceTimeAllocationPaletteStaticDefinitionRepository<S> repository; 
    }
}