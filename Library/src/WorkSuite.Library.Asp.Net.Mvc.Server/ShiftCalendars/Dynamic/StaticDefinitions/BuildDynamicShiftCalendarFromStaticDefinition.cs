using System.Collections.Generic;
using System.Linq;
using WorkSuite.Library.Asp.Net.Mvc.Server.ShiftCalendars.Dynamic.StaticDefinitions.Definitions;
using WorkSuite.Library.Asp.Net.Mvc.Server.ShiftCalendars.Dynamic.StaticDefinitions.Definitions.Actions;
using WorkSuite.Library.Asp.Net.Mvc.Server.ShiftPatterns;
using WorkSuite.Library.Asp.Net.Mvc.Server.ShiftPatterns.Dynamic;
using WorkSuite.Library.Asp.Net.Mvc.Server.Urls;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.DomainTypes;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.ShiftCalendars.Dynamic.StaticDefinitions
{
    /// <summary>
    ///     Builder that will create a dynamic Shift Calendar from statically defined definition.
    /// </summary>
    /// <typeparam name="S">
    ///     The type of the model that the dynamic Shift Calendar is built from.
    /// </typeparam>
    public class BuildDynamicShiftCalendarFromStaticDefinition<S>
    {
        public ShiftCalendar build(S model)
        {
            return new ShiftCalendar
            {
                title = definition.title.value_or_default(string.Empty)(model),
                classes = definition.classes.Select(c => c(model)).ToList(),
                actions = actions.Select(action_definition => create_action(action_definition, model)).ToList(),
                shift_pattern_grid = build_shift_patterns(model)
            };
        }

        private ShiftCalendarAction create_action(DynamicShiftCalendarActionStaticDefinition<S> the_action_definition,
                                                    S the_model
                                                 )
        {
            return new ShiftCalendarAction
            {
                title = the_action_definition.title(the_model),
                name = the_action_definition.name(the_model),
                url = _url_builder.build(the_action_definition.url, the_model),
                classes = the_action_definition.classes.Select(class_definition => class_definition(the_model)).ToList()
            };
        }

        private ShiftPatternGrid build_shift_patterns(S model)
        {
            var shift_pattern_model = Enumerable.Empty<IShiftPattern>();
            var start_date = definition.start_date(model);
            var shift_calendar_range = definition.number_of_days_range(model);

            if (definition.patterns != null)
            {
                shift_pattern_model = definition.patterns(model);
            }

            var patterns = shift_pattern_grid_builder.build(start_date, shift_calendar_range, shift_pattern_model);

            return patterns;
        }

        private DynamicShiftCalendarStaticDefinition<S> definition
        {
            get { return _repository.definition; }
        }

        private IEnumerable<DynamicShiftCalendarActionStaticDefinition<S>> actions
        {
            get { return _repository.actions; }
        }

        public BuildDynamicShiftCalendarFromStaticDefinition(DynamicShiftCalendarStaticDefinitionRepository<S> the_repository,
                                                                BuildUrlFromDefinition<S> the_url_builder
                                                            )
        {
            _repository = Guard.IsNotNull(the_repository, "the_repository");
            _url_builder = Guard.IsNotNull(the_url_builder, "the_url_builder");
            shift_pattern_grid_builder = new ShiftPatternGridViewModelBuilder();
        }

        private readonly DynamicShiftCalendarStaticDefinitionRepository<S> _repository;
        private readonly BuildUrlFromDefinition<S> _url_builder;
        private readonly ShiftPatternGridViewModelBuilder shift_pattern_grid_builder;
    }
}