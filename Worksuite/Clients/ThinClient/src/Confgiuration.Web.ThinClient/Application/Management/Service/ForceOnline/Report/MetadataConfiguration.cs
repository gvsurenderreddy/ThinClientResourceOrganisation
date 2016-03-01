using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Reports.Metadata.Static;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ActionDefinitions.Report;
using WTS.WorkSuite.Library.DomainTypes.ServiceStates;

namespace WorkSuite.Confgiuration.Web.ThinClient.Application.Management.Service.ForceOnline.Report {

    public class MetadataConfiguration 
                    : ReportMetadataBuilder<AServiceState> {

        protected override void build_model_metadata 
                                    ( IReportModelMetadataBuilder<AServiceState> model_metadata_builder ) {

            model_metadata_builder
                .id( m => Resources.report_id )
                .title( Resources.report_title )
                ;

        }

        protected override void build_field_metadata 
                                    ( IReportFieldsMetadataBuilder<AServiceState> fields_metadata_builder ) {

            
        }

        protected override void build_action_metadata 
                                    ( IReportActionsMetadataBuilder<AServiceState> actions_metadata_builder ) {
            
            actions_metadata_builder
                .add_action<Edit>()
                .id( Editor.Resources.editor_id )
                ;            
        }
    }
}