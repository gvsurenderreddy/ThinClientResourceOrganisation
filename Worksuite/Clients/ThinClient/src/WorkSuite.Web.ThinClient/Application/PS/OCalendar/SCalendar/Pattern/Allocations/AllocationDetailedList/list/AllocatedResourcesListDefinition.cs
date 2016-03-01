using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.DetailsLists.Metadata.Static.Actions;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.DetailsLists.Metadata.Static.Model;
using WTS.WorkSuite.ThinClient.Query.Application.PlannedSupply.OperationsCalendar.ShiftCalendars.Patterns.Allocations.AllocatedResources.listItem;


namespace WTS.WorkSuite.Web.ThinClient.Application.Operations.OperationalCalendars.PlannedSupply.ShiftCalendars.Patterns.Allocations.AllocatedResources.list
{
    public class AllocatedResourcesListDefinition
                        : global::WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.DetailsLists.Metadata.Static.DetailsListMetadataBuilder<ShiftCalendarPatternResource>
    {
        protected override void build_list_metadata(IDetailsListMetadataBuilder<ShiftCalendarPatternResource> builder)
        {
            builder
                .id(Resources.list_id)
                .title(Resources.list_title)
                ;
        }

        protected override void build_list_actions_metadata(IDetailsListActionsMetadataBuilder<ShiftCalendarPatternResource> builder)
        {
            builder
                .add_action<global::WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ActionDefinitions.Report.View>()
                 .id(AllResources.get.Resources.page_id)
                 .route_parameter_factory(m => new { m.operations_calendar_id, m.shift_calendar_id, m.shift_calendar_pattern_id })
                 .title("new")
                ;
        }
    }
}