using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Fields.HiddenField;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Fields.LookupField;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.UserActions;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ActionDefinitions;
using WorkSuite.Library.Asp.Net.Mvc.Server.Urls;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.DomainTypes.Date;
using WTS.WorkSuite.Web.ThinClient.Application.Operations.OperationalCalendars.PlannedSupply.WhiteSpaceTimeAllocationPalette;
using WTS.WorkSuite.Web.ThinClient.Components.WhiteSpaceTimeAllocationPalettes.Dynamic.StaticDefinitions;
using WTS.WorkSuite.Web.ThinClient.Components.WhiteSpaceTimeAllocationPalettes.Dynamic.StaticDefinitions.Model;

namespace WTS.WorkSuite.Web.ThinClient.Components.WhiteSpaceTimeAllocationPalettes.Dynamic
{
    public class BuildDynamicWhiteSpaceTimeAllocationPaletteFromStaticDefinition<S> where S : WhiteSpacePaletteDetails
    {
        public WhiteSpaceTimeAllocationPalette build(S model)
        {
            return new WhiteSpaceTimeAllocationPalette
            {
                title = model_definition.title,
                classes = model_definition.classes.ToList(),
                operational_calendar_id = build_operation_calendar_id_field(model.operations_calendar_id),
                shift_calendar_id = build_shift_calendar_id_field(model.shift_calendar_id),
                shift_calendar_pattern_id = build_shift_calendar_pattern_id_field(model.shift_calendar_pattern_id),
                start_date = build_start_date_field(model.start_date),
                time_allocation_templates = build_shift_template_id_field(model.shift_template_id),
                change_time_allocation_action = build_change_time_allocation_action(model),
                new_shift_action = build_new_shift_action(model)

            };
        }

        public BuildDynamicWhiteSpaceTimeAllocationPaletteFromStaticDefinition<S> set_time_allocation_template_lookup_values(IEnumerable<LookupValue> time_allocations)
        {
            lookup_values = time_allocations;

            return this;
        }

        public BuildDynamicWhiteSpaceTimeAllocationPaletteFromStaticDefinition(DynamicWhiteSpaceTimeAllocationPaletteStaticDefinitionRepository<S> the_repository
                                                                                , BuildUrlFromDefinition<S> the_url_builder)
        {
            repository = Guard.IsNotNull(the_repository, "the_repository ");
            url_builder = Guard.IsNotNull(the_url_builder, "the_url_builder ");

            lookup_values = Enumerable.Empty<LookupValue>();
        }

        private DynamicWhiteSpaceTimeAllocationPaletteModelStaticDefinition model_definition
        {
            get { return repository.definition; }
        }

        private IEnumerable<LookupValue> lookup_values;

        private readonly DynamicWhiteSpaceTimeAllocationPaletteStaticDefinitionRepository<S> repository;

        private readonly BuildUrlFromDefinition<S> url_builder;

        private AHiddenField build_operation_calendar_id_field(int model)
        {
            return new AHiddenField()
            {
                id = "operations-calendar-id",
                value = model.ToString(CultureInfo.InvariantCulture),
                property_name = "operations_calendar_id"
            };
        }

        private AHiddenField build_shift_calendar_id_field(int model)
        {
            return new AHiddenField()
            {
                id = "shift-calendar-id",
                value = model.ToString(CultureInfo.InvariantCulture),
                property_name = "shift_calendar_id"
            };
        }

        private AHiddenField build_shift_calendar_pattern_id_field(int model)
        {
            return new AHiddenField()
            {
                id = "shift-calendar-pattern-id",
                value = model.ToString(CultureInfo.InvariantCulture),
                property_name = "shift_calendar_pattern_id"
            };
        }

        private AHiddenField build_start_date_field(DateTime model)
        {
            return new AHiddenField()
            {
                id = "start-date",
                value = model.ToClientSideDateString(),
                property_name = "start_date"
            };
        }

        private ALookupField build_shift_template_id_field(int model)
        {
            return new ALookupField()
            {
                id = "shift-template-id",
                value = model,
                property_name = "shift_template_id",
                lookup_values = lookup_values
            };
        }

        private RoutedAction build_change_time_allocation_action(S model)
        {
            var action_definition = repository.actions.First(ac => ac.name(model) == new SubmitApply().action_name);

            return new RoutedAction()
            {
                title = action_definition.title(model),
                name = action_definition.name(model),
                url = url_builder.build(action_definition.url, model),
                classes = action_definition.classes.Select(class_definition => class_definition(model)).ToList(),
            };
        }

        private RoutedAction build_new_shift_action(S model)
        {
            var action_definition = repository.actions.First(ac => ac.name(model) == new New().action_name);

            return new RoutedAction()
            {
                title = action_definition.title(model),
                name = action_definition.name(model),
                url = url_builder.build(action_definition.url,model),
                classes = action_definition.classes.Select(class_definition => class_definition(model)).ToList(),
                is_enabled = true
            };
        }
    }
}
