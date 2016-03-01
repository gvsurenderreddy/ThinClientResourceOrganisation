using WorkSuite.Library.Asp.Net.Mvc.Server.ShiftCalendars.Dynamic.StaticDefinitions.Definitions;
using WorkSuite.Library.Asp.Net.Mvc.Server.ShiftCalendars.Dynamic.StaticDefinitions.Definitions.Actions;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar;

namespace WTS.WorkSuite.Web.ThinClient.Application.Operations.OperationalCalendars.PlannedSupply.Presentation.ShiftCalendars
{
    public class MetadataConfiguration
                        : ShiftCalendarDefinitionsBuilder<ShiftCalendarAggregateOverRange>
    {
        protected override void build_model_definitions(DynamicShiftCalendarStaticDefinitionBuilder<ShiftCalendarAggregateOverRange> the_model_definition_builder)
        {
            the_model_definition_builder
                .title(oc => oc.calendar_name)
                .start_date(oc => oc.patterns_start_date)
                .number_of_days_range(oc=>oc.patterns_range_returned)
                .patterns(oc => oc.shift_calendar_patterns)
                ;
        }

        protected override void build_actions_definitions(DynamicShiftCalendarActionsStaticDefinitionBuilder<ShiftCalendarAggregateOverRange> actions_definitions_builder)
        {
            actions_definitions_builder
            .new_action<global::WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ActionDefinitions.View>()
            .title("edit")
                .url_from_route(sc => Presentation.Page.Resources.page_id, sc => new { sc.shift_calendar_id })
            .add()
            ;

            actions_definitions_builder
           .new_action<global::WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ActionDefinitions.View>()
           .title("publish")
               .url_from_route(sc => PlannedSupply.ShiftCalendars.Presentation.Publish.Get.Resources.page_id, sc => new { sc.shift_calendar_id })
           .add()
           ;

            actions_definitions_builder
            .new_action<global::WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ActionDefinitions.Remove>()
                .url_from_route(sc => Presentation.Remove.Editor.Resources.id, sc => new { sc.shift_calendar_id })
            .add()
            ;
        }
    }
}