using WorkSuite.Confgiuration.Web.ThinClient.Application.Management.MaintenanceSession.Status.States;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Reports.Metadata.Static;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ActionDefinitions.Report;

namespace WorkSuite.Confgiuration.Web.ThinClient.Application.Management.MaintenanceSession.Status.Report {

    /// <summary>
    ///     Metadata configuration for the Maintenance session report
    /// </summary>
    public class MetadataConfiguration
                    : ReportMetadataBuilder<AMaintenanceSesssionStatus> {

        protected override void build_model_metadata
                                    ( IReportModelMetadataBuilder<AMaintenanceSesssionStatus> model_metadata_builder ) {

            model_metadata_builder
                .id( m => Resources.report_id )
                .title(Resources.report_title)                
                .presenter_id( Resources.report_id )
                ;
        }

        protected override void build_field_metadata
                                    ( IReportFieldsMetadataBuilder<AMaintenanceSesssionStatus> field_metadata_builder ) {

            field_metadata_builder
                .for_field( m => m.state )
                .label( "Status" )                
                .humanize()
                ;
        }

        protected override void build_action_metadata
                                    ( IReportActionsMetadataBuilder<AMaintenanceSesssionStatus> action_metadata_builder ) {

            action_metadata_builder
                .add_action<Edit>()
                .id( Editor.Resources.editor_id )
                ;

        }
    }
}