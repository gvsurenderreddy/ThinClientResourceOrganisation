using WorkSuite.Configuration.Service.Management.MaintenanceSessions.EndAll;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors.Metadata.Static;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.UserActions.Configuration.Static.CallToActionTypes;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ActionDefinitions.Editor;

namespace WorkSuite.Confgiuration.Web.ThinClient.Application.Management.Service.ForceOnline.Editor {

    public class MetadataConfiguration
                    : EditorMetadataBuilder<EndAllMaintenanceSessionsRequest>{

        protected override void build_model_metadata 
                                    ( IEditorModelMetadataBuilder<EndAllMaintenanceSessionsRequest> model_metadata_builder ) {

            model_metadata_builder
                .id( Resources.editor_id )
                .title( Report.Resources.report_title )
                ;
        }

        protected override void build_field_metadata 
                                    ( IEditorFieldsMetadataBuilder<EndAllMaintenanceSessionsRequest> fields_metadata_builder ) {

            fields_metadata_builder
                .for_field( m => m.has_been_confirmed )
                .label( "Confirmation" )
                .is_required( true )
                ;
        }

        protected override void build_action_metadata 
                                    ( IEditorActionsMetadataBuilder<EndAllMaintenanceSessionsRequest> actions_metadata_builder ) {

            actions_metadata_builder
                .add_action<ForceOnlineAction>(  )
                .call_to_action<PrimaryCallToAction>()
                .id( Controller.Resources.id )
                ;

            actions_metadata_builder
                .add_action<Cancel>(  )
                .call_to_action<SecondaryCallToAction>()
                .is_not_a_routed_action(  )
                ;

        }

    }

}