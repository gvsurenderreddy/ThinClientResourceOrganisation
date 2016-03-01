using WorkSuite.Library.Asp.Net.Mvc.Server.ContentHeaders.Dynamic.StaticDefinitions.Definitions;
using WorkSuite.Library.Asp.Net.Mvc.Server.ContentHeaders.Dynamic.StaticDefinitions.Definitions.Actions;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.GetOverRange;

namespace WTS.WorkSuite.Web.ThinClient.Application.Operations.OperationalCalendars.PlannedSupply.Presentation.ContentHeader
{
    public class MetadataConfigurations
                        : ContentHeaderDefinitionsBuilder<OperationsCalendarAggregateOverRange>
    {
        protected override void build_model_definitions(DynamicContentHeaderStaticDefinitionBuilder<OperationsCalendarAggregateOverRange> model_definitions_builder)
        {
            model_definitions_builder
                .title(oc => oc.calendar_name)
                ;
        }

        protected override void build_action_definitions(DynamicContentHeaderActionsStaticDefintionBuilder<OperationsCalendarAggregateOverRange> actions_definitions_builder)
        {
            actions_definitions_builder
                .new_action<global::WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ActionDefinitions.Edit>()
                .url_from_route(oc => Edit.Presentation.Editor.Resources.id, oc => new { oc.operations_calendar_id })
                .add()
                ;

            actions_definitions_builder
                .new_action<global::WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ActionDefinitions.Remove>()
                .url_from_route(oc => Remove.Presentation.Editor.Resources.id, oc => new { oc.operations_calendar_id })
                .add()
                ;
        }
    }
}