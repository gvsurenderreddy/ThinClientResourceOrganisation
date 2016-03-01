using System;
using WorkSuite.Confgiuration.Web.ThinClient.Application.Management.MaintenanceSession.Status.Query;
using WorkSuite.Configuration.Service.Configuration.Help;
using WorkSuite.Configuration.Service.Messages;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Reports.Metadata.Static;
using Edit = WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ActionDefinitions.Report.Edit;

namespace WorkSuite.Confgiuration.Web.ThinClient.Application.Configuration.Help.Presentation.Report
{
    public class MetadataConfiguration
                 :ReportMetadataBuilder<HelpUrlDetails>
    {
        protected override void build_model_metadata
                                 (IReportModelMetadataBuilder<HelpUrlDetails> model_metadata_builder)
        {
            model_metadata_builder
                .id(m => Resources.report_id)
                .title(Resources.report_title)
                .presenter_id(Resources.report_id)
                .description(ErrorMessages.error_05_0014)
                .should_display_discription( m => GetMaintenanceSessionStatus.is_in_session());
        }

        protected override void build_field_metadata(IReportFieldsMetadataBuilder<HelpUrlDetails> fields_metadata_builder)
        {
            fields_metadata_builder
                .for_field(m => m.location_url)
                .label("Location URL")
                .id(m => "location_url" + DateTime.Now.Ticks);
        } 

        protected override void build_action_metadata(IReportActionsMetadataBuilder<HelpUrlDetails> actions_metadata_builder)
        {
           actions_metadata_builder
               .add_action<Edit>()
               .id(Editor.Resources.id)
             .is_enabled( m => GetMaintenanceSessionStatus.is_in_session())
            ;
        }
    }
}