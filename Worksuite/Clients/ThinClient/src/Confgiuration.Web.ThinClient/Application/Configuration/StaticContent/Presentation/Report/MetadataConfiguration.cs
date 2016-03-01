using System;
using WorkSuite.Confgiuration.Web.ThinClient.Application.Management.MaintenanceSession.Status.Query;
using WorkSuite.Configuration.Service.Configuration.StaticContent;
using WorkSuite.Configuration.Service.Messages;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Reports.Metadata.Static;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ActionDefinitions.Report;

namespace WorkSuite.Confgiuration.Web.ThinClient.Application.Configuration.StaticContent.Presentation.Report
{
    public class MetadataConfiguration
        :ReportMetadataBuilder<StaticContentDetails>
    {
        protected override void build_model_metadata
                                     (IReportModelMetadataBuilder<StaticContentDetails> model_metadata_builder)
        {
            model_metadata_builder
                .id(m => Resources.report_id)
                .title(Resources.report_title)
                .presenter_id(Resources.report_id)
                .description(ErrorMessages.error_05_0012)
                .should_display_discription(m => GetMaintenanceSessionStatus.is_in_session());

        }

        protected override void build_field_metadata
                                      (IReportFieldsMetadataBuilder<StaticContentDetails> fields_metadata_builder)
        {
           fields_metadata_builder
               .for_field(m=>m.location_url)
               .label("Location URL")
               .id(m => "location_url" + DateTime.Now.Ticks);
        }

        protected override void build_action_metadata
                                     (IReportActionsMetadataBuilder<StaticContentDetails> actions_metadata_builder)
        {
          actions_metadata_builder
              .add_action<Edit>()
              .id(Editor.Resourcse.id)
              .is_enabled( m => GetMaintenanceSessionStatus.is_in_session());
        }
    }
}