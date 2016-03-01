using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.UserActions;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.DateRangePalettes.Dynamic.StaticDefinitions.Actions
{
    public class DynamicDateRangePaletteActionsStaticDefinitionBuilder<S> 
    {
        public DynamicDateRangePaletteActionStaticDefinitionBuilder<S> new_action<T>() where T : CommonActionDefinition, new() 
        {

            var action_definition_template = new T();
            var action_definition_builder = new DynamicDateRangePaletteActionStaticDefinitionBuilder<S>(action_definition => repository.actions.Add(action_definition));

            action_definition_builder
                .title(m => action_definition_template.title )
                .name(m => action_definition_template.action_name )
                .add_class(m => action_definition_template.action_class)
                ;

            return action_definition_builder;
        }

        public DynamicDateRangePaletteActionsStaticDefinitionBuilder(DynamicDateRangePaletteStaticDefinitionRepository<S> the_repository) 
        {
            repository = Guard.IsNotNull( the_repository, "the_repository" );
        }

        private readonly DynamicDateRangePaletteStaticDefinitionRepository<S> repository; 
    }
}
