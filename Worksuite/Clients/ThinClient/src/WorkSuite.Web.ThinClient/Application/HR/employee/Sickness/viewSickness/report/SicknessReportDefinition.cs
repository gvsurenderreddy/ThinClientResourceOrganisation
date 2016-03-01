using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Reports.Metadata.Static;
using WTS.WorkSuite.ThinClient.Query.Application.HR.employee.Sickness.listItems;
using  WTS.WorkSuite.Library.DomainTypes.Date;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.employee.Sickness.viewSickness.report
{
    public class SicknessReportDefinition : ReportMetadataBuilder<SicknessListItem>
    {
        protected override void build_model_metadata(IReportModelMetadataBuilder<SicknessListItem> model_metadata_builder)
        {
            model_metadata_builder
                .presenter_id(Resources.id)
                .id(m => m.employee_id.ToString())
                ;
        }

        protected override void build_field_metadata(IReportFieldsMetadataBuilder<SicknessListItem> fields_metadata_builder)
        {
            fields_metadata_builder
               .for_field(m => m.sickness_date_display)
               .id("date")
              .label(content_repository.get_resource_value("view_sickness_list_item_report_date_field_label"))
               ;

        }

        protected override void build_action_metadata(IReportActionsMetadataBuilder<SicknessListItem> actions_metadata_builder)
        {
            actions_metadata_builder
                .add_action<global::WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ActionDefinitions.DetailsList.Remove>()
                .id(removeSickness.post.Resources.id)
                .route_parameter_factory(rs => new { rs.employee_id, sickness_date = rs.sickness_date.ToClientSideUrlSafeInvariantCultureString() })
                ;
        }
    }
}