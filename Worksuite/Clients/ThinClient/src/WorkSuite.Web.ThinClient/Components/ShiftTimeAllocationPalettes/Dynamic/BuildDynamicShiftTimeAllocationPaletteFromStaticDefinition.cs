using System.Collections.Generic;
using System.Linq;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.UserActions;
using WorkSuite.Library.Asp.Net.Mvc.Server.Urls;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.DomainTypes;
using WTS.WorkSuite.Library.DomainTypes.Duration;
using WTS.WorkSuite.Library.DomainTypes.Time.Clocks;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence;
using WTS.WorkSuite.Web.ThinClient.Components.ShiftTimeAllocationPalettes.Dynamic.StaticDefinitions;
using WTS.WorkSuite.Web.ThinClient.Components.ShiftTimeAllocationPalettes.Dynamic.StaticDefinitions.Model;

namespace WTS.WorkSuite.Web.ThinClient.Components.ShiftTimeAllocationPalettes.Dynamic
{
    public class BuildDynamicShiftTimeAllocationPaletteFromStaticDefinition<S> where S : ShiftOccurrenceDetails
    {
        public ShiftTimeAllocationPalette build(S the_model)
        {
            set_model(the_model);

            return new ShiftTimeAllocationPalette
            {
                title = model_definition.title,
                shift_title = model_definition.shift_title(model),
                time_period = model_definition.time_period(model),
                breaks = build_shift_palette_breaks(),
                classes = model_definition.classes.ToList(),
                remove_shift_action = build_remove_shift_action(model),
                remove_all_shift_action = build_build_remove_all_shift_action(model),
                edit_all_shift_action = build_build_edit_all_shift_action(model),
                edit_shift_action = build_edit_shift_action(model),
            };
        }

        public BuildDynamicShiftTimeAllocationPaletteFromStaticDefinition(DynamicShiftTimeAllocationPaletteStaticDefinitionRepository<S> the_repository
                                                                                , BuildUrlFromDefinition<S> the_url_builder)
        {
            repository = Guard.IsNotNull(the_repository, "the_repository ");
            url_builder = Guard.IsNotNull(the_url_builder, "the_url_builder ");
        }

        private S model;

        private void set_model(S the_model)
        {
            model = Guard.IsNotNull(the_model, "the_model");
        }

        private DynamicShiftTimeAllocationPaletteModelStaticDefinition<S> model_definition
        {
            get { return repository.definition; }
        }

        private readonly DynamicShiftTimeAllocationPaletteStaticDefinitionRepository<S> repository;

        private readonly BuildUrlFromDefinition<S> url_builder;

        private IEnumerable<ShiftTimeAllocationPaletteBreak> build_shift_palette_breaks()
        {
            var breaks_model = model_definition.breaks(model);

            return breaks_model.Select(bm => new ShiftTimeAllocationPaletteBreak()
            {
                title = string.Format("Break {0}", bm.position),
                start_time = get_domain_format_string(get_break_start_time(bm)),
                end_time = get_domain_format_string(get_break_end_time(bm)),
                payment_type = bm.is_paid ? "Paid" : "Unpaid"
            });
        }

        private UtcTime shift_start_time
        {
            get { return model_definition.time_period(model).start_at; }
        }

        private UtcTime get_break_start_time(ITimeAllocationBreak the_break)
        {
            var break_offset_in_seconds = the_break.offset_from_start_time.to_seconds();
            return shift_start_time.end_time_utc_format(break_offset_in_seconds);
        }

        private UtcTime get_break_end_time(ITimeAllocationBreak the_break)
        {
            var break_start_offset_in_seconds = the_break.offset_from_start_time.to_seconds();
            var break_duration_in_seconds = the_break.duration.to_seconds();

            var break_end_offset_in_seconds = break_start_offset_in_seconds + break_duration_in_seconds;

            return shift_start_time.end_time_utc_format(break_end_offset_in_seconds);
        }

        private string get_domain_format_string(UtcTime utc_time)
        {
            return utc_time.hours.ToString("00") + ":" + utc_time.minutes.ToString("00");
        }


        private RoutedAction build_remove_shift_action(S model)
        {
            return new RoutedAction
            {
                title = repository.remove_action.title(model),
                name = repository.remove_action.name(model),
                url = url_builder.build(repository.remove_action.url, model),
                classes = repository.remove_action.classes.Select(class_definition => class_definition(model)).ToList(),
            };
        }

        private RoutedAction build_build_remove_all_shift_action(S model)
        {
            return new RoutedAction
            {
                title = repository.remove_all_action.title(model),
                name = repository.remove_all_action.name(model),
                url = url_builder.build(repository.remove_all_action.url, model),
                classes = repository.remove_all_action.classes.Select(class_definition => class_definition(model)).ToList(),
            };
        }

        private RoutedAction build_build_edit_all_shift_action(S model)
        {
            return new RoutedAction
            {
                title = repository.edit_all_action.title(model),
                name = repository.edit_all_action.name(model),
                url = url_builder.build(repository.edit_all_action.url, model),
                classes = repository.edit_all_action.classes.Select(class_definition => class_definition(model)).ToList(),
            };
        }
        private RoutedAction build_edit_shift_action(S model)
        {
            return new RoutedAction
            {
                title = repository.edit_action.title(model),
                name = repository.edit_action.name(model),
                url = url_builder.build(repository.edit_action.url, model),
                classes = repository.edit_action.classes.Select(class_definition => class_definition(model)).ToList(),
            };
        }
    }
}
