using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence;
using ActionDefinitions = WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ActionDefinitions;
using WTS.WorkSuite.Web.ThinClient.Components.ShiftTimeAllocationPalettes.Dynamic.StaticDefinitions.Actions;
using WTS.WorkSuite.Web.ThinClient.Components.ShiftTimeAllocationPalettes.Dynamic.StaticDefinitions.Configuration;
using WTS.WorkSuite.Web.ThinClient.Components.ShiftTimeAllocationPalettes.Dynamic.StaticDefinitions.Model;

namespace WTS.WorkSuite.Web.ThinClient.Application.Operations.OperationalCalendars.PlannedSupply.ShiftTimeAllocationPalette
{
    public class MetadataConfiguration : ShiftTimeAllocationPaletteDefinitionsBuilder<ShiftOccurrenceDetails>
    {
        protected override void build_model_definitions(DynamicShiftTimeAllocationPaletteModelStaticDefinitionBuilder<ShiftOccurrenceDetails> model_definitions_builder)
        {
            model_definitions_builder
                .title("Shift")
                .shift_title(x => x.shift_title)
                .time_period(x => x.time_period)
                .breaks(x => x.breaks)
                ;
        }

        protected override void build_action_definitions(DynamicShiftTimeAllocationPaletteActionsStaticDefinitionBuilder<ShiftOccurrenceDetails> actions_definitions_builder)
        {
            actions_definitions_builder
             .edit_action<ActionDefinitions.Edit>()
             .title(m => "edit")
             .add_class(m => "primary-action")
             .url_from_route(m => ShiftCalendars.Patterns.ShiftOccurrences.Edit.Presentation.Page.Resources.page_id
                            , m => new { m.operations_calendar_id, m.shift_calendar_id, m.shift_calendar_pattern_id, m.shift_occurrence_id })
             .add();

            actions_definitions_builder
                .new_action<ActionDefinitions.Remove>()
                .add_class(m => "primary-action")
                .url_from_route(m => ShiftCalendars.Patterns.ShiftOccurrences.Remove.Presentation.Page.Resources.page_id
                                , m => new { m.operations_calendar_id, m.shift_calendar_id, m.shift_calendar_pattern_id, m.shift_occurrence_id })
                .add();

            actions_definitions_builder
              .edit_all_action<ActionDefinitions.Edit>()
              .title(m => "edit all")
              .add_class(m => "primary-action")
              .url_from_route(m => ShiftCalendars.Patterns.ShiftOccurrences.EditAll.Presentation.Page.Resources.page_id
                             , m => new { m.operations_calendar_id, m.shift_calendar_id, m.shift_calendar_pattern_id, m.shift_occurrence_id })
              .add();

            actions_definitions_builder
              .remove_all_action<ActionDefinitions.Remove>()
              .title(m => "remove all")
              .add_class(m => "primary-action")
              .url_from_route(m => ShiftCalendars.Patterns.ShiftOccurrences.RemoveAll.Presentation.Page.Resources.page_id
                             , m => new { m.operations_calendar_id, m.shift_calendar_id, m.shift_calendar_pattern_id, m.shift_occurrence_id })
              .add();

        }
    }
}