using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Reports.Metadata.Static;
using WTS.WorkSuite.ThinClient.Query.Application.PlannedSupply.OperationsCalendar.ShiftCalendars.Patterns.Allocations.AllocatedResources.listItem;


namespace WTS.WorkSuite.Web.ThinClient.Application.Operations.OperationalCalendars.PlannedSupply.ShiftCalendars.Patterns.Allocations.AllocatedResources.report
{
    public class AllocatedResourcesReportDefinition : ReportMetadataBuilder<ShiftCalendarPatternResource>
    {
        protected override void build_model_metadata(IReportModelMetadataBuilder<ShiftCalendarPatternResource> model_metadata_builder)
        {
            model_metadata_builder
                .presenter_id(Resources.id)
                .id(m => m.resource_allocation_id.ToString())
                .title(m => m.resource_label)
                ;
        }

        protected override void build_field_metadata(IReportFieldsMetadataBuilder<ShiftCalendarPatternResource> fields_metadata_builder)
        {
            fields_metadata_builder
                .for_field(m => m.name)
                .id("name")
                .label("Name")
                ;

            fields_metadata_builder
                .for_field(m => m.employee_reference)
                .id("employee_reference")
                .label("Employee reference")
                ;

            fields_metadata_builder
                .for_field(m => m.location)
                .id("location")
                .label("Location")
                .is_included(m => !string.IsNullOrWhiteSpace(m.location))
                ;

            fields_metadata_builder
                .for_field(m => m.job_title)
                .id("job_title")
                .label("Job title")
                .is_included(m => !string.IsNullOrWhiteSpace(m.job_title))
                ;
        }

        protected override void build_action_metadata(IReportActionsMetadataBuilder<ShiftCalendarPatternResource> actions_metadata_builder)
        {
            actions_metadata_builder
               .add_action<global::WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ActionDefinitions.DetailsList.Remove>()
               .id(RemoveAllocation.post.Resources.id)
               .title("remove")
               .route_parameter_factory(sc => new { sc.resource_allocation_id })
               ;
        }
    }
}