using System;
using WorkSuite.Confgiuration.Web.ThinClient.Application.Management.MaintenanceSession.Status.Query;
using WorkSuite.Configuration.Service.Configuration.DatabaseSettings;
using WorkSuite.Configuration.Service.Messages;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Reports.Metadata.Static;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ActionDefinitions.Report;

namespace WorkSuite.Confgiuration.Web.ThinClient.Application.Configuration.DatabaseSetting.Presentation.Report {

    /// <summary>
    ///     Metadata configuration for the database setting report
    /// </summary>
    public class MetadataConfiguration
                    : ReportMetadataBuilder<DatabaseSettingDetails> {

        protected override void build_model_metadata
                                    (IReportModelMetadataBuilder<DatabaseSettingDetails> model_metadata_builder)
        {

            model_metadata_builder
                .id( m => Resources.report_id )
                .title(Resources.report_title)
                .presenter_id( Resources.report_id )
                .description(ErrorMessages.erroe_05_0011)
                .should_display_discription(m => GetMaintenanceSessionStatus.is_in_session())
                ;
        }

        protected override void build_field_metadata
                                    (IReportFieldsMetadataBuilder<DatabaseSettingDetails> field_metadata_builder)
        {

            field_metadata_builder
                .for_field( m => m.connection_string )
                .label( "Connection string" )
                .id(m => "connection_string" + DateTime.Now.Ticks)
                ;
        }

        protected override void build_action_metadata
                                     (IReportActionsMetadataBuilder<DatabaseSettingDetails> action_metadata_builder)
        {

            action_metadata_builder
                .add_action<Edit>()
                .id(Editor.Resources.id)
                .is_enabled(m => GetMaintenanceSessionStatus.is_in_session());


        }
    }
}