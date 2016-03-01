using System.Linq;
using System.Web.Mvc;
using WorkSuite.Library.Asp.Net.Mvc.Server.ShiftCalendars.Dynamic.StaticDefinitions;
using WorkSuite.Library.Asp.Net.Mvc.Server.ShiftCalendarsListers.Dynamic.StaticDefinitions.Definitions;
using WorkSuite.Library.Asp.Net.Mvc.Server.ShiftCalendarsListers.Dynamic.StaticDefinitions.Definitions.Actions;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.GetOverRange;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar;

namespace WTS.WorkSuite.Web.ThinClient.Application.Operations.OperationalCalendars.PlannedSupply.Presentation.ShiftCalendarsLister
{
    public class MetadataConfiguration
                        : ShiftCalendarsListerDefinitionsBuilder<OperationsCalendarAggregateOverRange>
    {
        protected override void build_model_definitions(DynamicShiftCalendarsListerStaticDefinitionBuilder<OperationsCalendarAggregateOverRange> the_model_definitions_builder)
        {
            the_model_definitions_builder
                .title("Shift calendars")
                .get_calendars_via(m =>
                {
                    var calendar_view_model_builder = DependencyResolver.Current.GetService<BuildDynamicShiftCalendarFromStaticDefinition<ShiftCalendarAggregateOverRange>>();

                    return m.all_shift_calendars_details.Select(sc => calendar_view_model_builder.build(sc)).Reverse();
                })
                ;
        }

        protected override void build_action_definitions(DynamicShiftCalendarsListerActionsStaticDefinitionBuilder<OperationsCalendarAggregateOverRange> the_actions_definitions_builder)
        {
            the_actions_definitions_builder
                .new_action<global::WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ActionDefinitions.New>()
                .url_from_route(oc => ShiftCalendars.Presentation.New.Editor.Resources.id, oc => new { })
                .add()
                ;
        }
    }
}