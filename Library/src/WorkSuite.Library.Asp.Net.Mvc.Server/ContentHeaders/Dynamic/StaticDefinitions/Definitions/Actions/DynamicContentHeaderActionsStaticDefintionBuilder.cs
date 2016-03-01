using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.UserActions;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.ContentHeaders.Dynamic.StaticDefinitions.Definitions.Actions {

    public class DynamicContentHeaderActionsStaticDefintionBuilder<S> {

        /// <summary>
        ///     Creates a new action definition builder.
        /// </summary>
        /// <typeparam name="T">
        ///     The type of the action defintion template that will be used
        /// </typeparam>
        /// <returns>
        ///     An action definition builder that allow the defintion to be built and added to the 
        /// content header
        /// </returns>
        public DynamicContentHeaderActionStaticDefinitionBuilder<S> new_action<T>() 
                                                                        where T : CommonActionDefinition, new() {

            var action_definition_template = new T();
            var action_definition_builder = new DynamicContentHeaderActionStaticDefinitionBuilder<S>(
                action_definition => repository.actions.Add( action_definition )
            );

            action_definition_builder
                .title( action_definition_template.title )
                .name( action_definition_template.action_name )
                ;

            return action_definition_builder;
        }

        public DynamicContentHeaderActionsStaticDefintionBuilder 
                ( DynamicContentHeaderStaticDefinitionRepository<S> the_repository ) {

            repository = Guard.IsNotNull( the_repository, "the_repository" );
        }

        // repository that stores the action deifinitions 
        private readonly DynamicContentHeaderStaticDefinitionRepository<S> repository; 
    }
}