using System.Collections.Generic;
using System.Linq;
using WorkSuite.Library.Asp.Net.Mvc.Server.ShiftCalendarsListers.Dynamic.StaticDefinitions.Definitions;
using WorkSuite.Library.Asp.Net.Mvc.Server.ShiftCalendarsListers.Dynamic.StaticDefinitions.Definitions.Actions;
using WorkSuite.Library.Asp.Net.Mvc.Server.Urls;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.ShiftCalendarsListers.Dynamic.StaticDefinitions
{
    /// <summary>
    ///     Builder that will create a dynamic Shift Calendars Lister from statically defined definition
    /// </summary>
    /// <typeparam name="S">
    ///     The type of the model that the dynamic Shift Calendars Lister is built from
    /// </typeparam>
    public class BuildDynamicShiftCalendarsListerFromStaticDefinition<S>
    {
        public ShiftCalendarsLister build(S model)
        {
            return new ShiftCalendarsLister
            {
                title = definition.title.value_or_default(string.Empty)(model),
                classes = definition.classes.Select(ce => ce(model)).ToList(),
                actions = actions.Select(action_definition => create_action(action_definition, model)).ToList(),
                all_shift_calendars = definition.create_shift_calendars(model)
            };
        }

        private ShiftCalendarsListerAction create_action(DynamicShiftCalendarsListerActionStaticDefinition<S> the_action_definition,
                                                        S model
                                                       )
        {
            return new ShiftCalendarsListerAction
            {
                title = the_action_definition.title(model),
                name = the_action_definition.name(model),
                url = _url_builder.build(the_action_definition.url, model),
                classes = the_action_definition.classes.Select(class_definition => class_definition(model)).ToList()
            };
        }

        private DynamicShiftCalendarsListerStaticDefinition<S> definition
        {
            get { return _repository.definition; }
        }

        private IEnumerable<DynamicShiftCalendarsListerActionStaticDefinition<S>> actions
        {
            get { return _repository.actions; }
        }

        public BuildDynamicShiftCalendarsListerFromStaticDefinition(DynamicShiftCalendarsListerStaticDefinitionRepository<S> the_repository,
                                                                    BuildUrlFromDefinition<S> the_url_builder
                                                                   )
        {
            _repository = Guard.IsNotNull(the_repository, "the_repository");
            _url_builder = Guard.IsNotNull(the_url_builder, "the_url_builder");
        }

        private readonly DynamicShiftCalendarsListerStaticDefinitionRepository<S> _repository;
        private readonly BuildUrlFromDefinition<S> _url_builder;
    }
}