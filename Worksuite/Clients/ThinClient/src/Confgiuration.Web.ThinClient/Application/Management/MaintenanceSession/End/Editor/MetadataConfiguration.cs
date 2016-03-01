using WorkSuite.Confgiuration.Web.ThinClient.Application.Management.MaintenanceSession.Status.States;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors.Metadata.Static;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.UserActions.Configuration.Static.CallToActionTypes;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ActionDefinitions.Editor;

namespace WorkSuite.Confgiuration.Web.ThinClient.Application.Management.MaintenanceSession.End.Editor {

    /// <summary>
    ///     Metadata configuration for the end maintenance session editor. Note it is more a
    /// command than an editor as there is nothing to edit you just submit the request.
    /// </summary>
    public class MetadataConfiguration 
                    : EditorMetadataBuilder<InMaintenanceSession> {

        protected override void build_model_metadata
                                    ( IEditorModelMetadataBuilder<InMaintenanceSession> model_metadata_builder ) {

            model_metadata_builder
                .id( Status.Editor.Resources.editor_id )
                .title( Status.Editor.Resources.editor_title )
                ;
        }

        protected override void build_field_metadata
                                    ( IEditorFieldsMetadataBuilder<InMaintenanceSession> fields_metadata_builder ) {
            
            // Note - There are no field to display in this in this editor as it basically just submits a command.

        }

        protected override void build_action_metadata
                                    ( IEditorActionsMetadataBuilder<InMaintenanceSession> actions_metadata_builder ) {

            actions_metadata_builder
                .add_action<EndMaintenanceSessionAction>()
                .call_to_action<PrimaryCallToAction>()
                .id( Controller.Resources.id )
                ;

            actions_metadata_builder
                .add_action<Cancel>()
                .call_to_action<SecondaryCallToAction>()
                .is_not_a_routed_action()
                ;
        }
    }
}