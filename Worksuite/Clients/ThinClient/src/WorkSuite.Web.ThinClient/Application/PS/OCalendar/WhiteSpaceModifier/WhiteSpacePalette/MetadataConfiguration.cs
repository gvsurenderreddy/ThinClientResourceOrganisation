using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ActionDefinitions;
using WTS.WorkSuite.Library.DomainTypes.Date;
using WTS.WorkSuite.Web.ThinClient.Components.WhiteSpaceTimeAllocationPalettes.Dynamic.StaticDefinitions.Actions;
using WTS.WorkSuite.Web.ThinClient.Components.WhiteSpaceTimeAllocationPalettes.Dynamic.StaticDefinitions.Configuration;
using WTS.WorkSuite.Web.ThinClient.Components.WhiteSpaceTimeAllocationPalettes.Dynamic.StaticDefinitions.Model;

namespace WTS.WorkSuite.Web.ThinClient.Application.Operations.OperationalCalendars.PlannedSupply.WhiteSpaceTimeAllocationPalette
{
    public class MetadataConfiguration : WhiteSpaceTimeAllocationPaletteDefinitionsBuilder<WhiteSpacePaletteDetails>
    {
        protected override void build_model_definitions(DynamicWhiteSpaceTimeAllocationPaletteModelStaticDefinitionBuilder<WhiteSpacePaletteDetails> model_definitions_builder)
        {
            model_definitions_builder
                .title("Shift")
                ;
        }

        protected override void build_action_definitions(DynamicWhiteSpaceTimeAllocationPaletteActionsStaticDefinitionBuilder<WhiteSpacePaletteDetails> actions_definitions_builder)
        {
            actions_definitions_builder
                .new_action<SubmitApply>()
                .add_class(m => "primary-action")
                .url_from_route(m => ShiftCalendars.Patterns.ShiftOccurrences.Commands.CreateFromShiftTemplate.Resources.id, m => new { m.operations_calendar_id, m.shift_calendar_id, m.shift_calendar_pattern_id })
                .add();

            actions_definitions_builder
              .new_action<global::WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ActionDefinitions.New>()
              .add_class(m => "primary-action")
              .url_from_route(m => ShiftCalendars.Patterns.ShiftOccurrences.New.Presentation.Page.Resources.page_id, m => new { m.operations_calendar_id, m.shift_calendar_id, m.shift_calendar_pattern_id, start_date = m.start_date.ToClientSideUrlSafeInvariantCultureString() })
              .add();

        }
    }
}