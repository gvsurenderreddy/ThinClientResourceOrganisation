using System;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.UserActions.Configuration.Static.CallToActionTypes;
using WorkSuite.Library.Asp.Net.Mvc.Server.SimplePalettes.Dynamic.StaticDefinitions.Definitions;
using WorkSuite.Library.Asp.Net.Mvc.Server.SimplePalettes.Dynamic.StaticDefinitions.Definitions.Actions;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.GetOverRange;

namespace WTS.WorkSuite.Web.ThinClient.Application.Operations.OperationalCalendars.PlannedSupply.Presentation.SimplePalette
{
    public class MetadataConfiguration : SimplePaletteDefinitionsBuilder<OperationsCalendarAggregateOverRange>
    {
        protected override void build_model_definitions(DynamicSimplePaletteStaticDefinitionBuilder<OperationsCalendarAggregateOverRange> model_definitions_builder)
        {
            model_definitions_builder
                .title("Operation Calendar")
                .description(p => p.calendar_name)
                ;
        }

        protected override void build_action_definitions(DynamicSimplePaletteActionsStaticDefintionBuilder<OperationsCalendarAggregateOverRange> actions_definitions_builder)
        {
            actions_definitions_builder
                .new_action<global::WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ActionDefinitions.Edit>()
                .component_context("content-header")
                .add_class("primary-action")
                .url_from_route(oc => Edit.Presentation.Editor.Resources.id, oc => new { oc.operations_calendar_id })
                .add()
                ;

            actions_definitions_builder
                .new_action<global::WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ActionDefinitions.Remove>()
                .component_context("content-header")
                .add_class("secondary-action")
                .url_from_route(oc => Remove.Presentation.Editor.Resources.id, oc => new { oc.operations_calendar_id })
                .add()
                ;
        }
    }
}