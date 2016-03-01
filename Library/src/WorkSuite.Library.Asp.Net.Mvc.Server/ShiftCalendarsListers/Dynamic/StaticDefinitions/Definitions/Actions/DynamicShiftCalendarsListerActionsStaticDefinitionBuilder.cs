using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.UserActions;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.ShiftCalendarsListers.Dynamic.StaticDefinitions.Definitions.Actions
{
    public class DynamicShiftCalendarsListerActionsStaticDefinitionBuilder<S>
    {
        /// <summary>
        ///     Adds action definition for the Shift Calendars Lister Actions builder.
        /// </summary>
        /// <typeparam name="T">
        ///     The type of the action defintion template that will be used
        /// </typeparam>
        /// <returns>
        ///     An action definition builder that allow the defintion to be built and added to the
        ///     Shift Calendars Lister.
        /// </returns>
        public DynamicShiftCalendarsListerActionStaticDefinitionBuilder<S> new_action<T>()
                                where T : CommonActionDefinition, new()
        {
            var action_definition_template = new T();
            var action_definition_builder =
                new DynamicShiftCalendarsListerActionStaticDefinitionBuilder<S>(
                                                                                    action_definition => _repository.actions.Add(action_definition)
                                                                               );

            action_definition_builder
                .title(action_definition_template.title)
                .name(action_definition_template.action_name)
                ;

            return action_definition_builder;
        }

        public DynamicShiftCalendarsListerActionsStaticDefinitionBuilder(DynamicShiftCalendarsListerStaticDefinitionRepository<S> the_repository)
        {
            _repository = Guard.IsNotNull(the_repository, "the_repository");
        }

        private readonly DynamicShiftCalendarsListerStaticDefinitionRepository<S> _repository;
    }
}