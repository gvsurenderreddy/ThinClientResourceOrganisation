using WorkSuite.Confgiuration.Web.ThinClient.Application.Management.MaintenanceSession.Status.States;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors.Metadata.Static;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.UserActions.Configuration.Static.CallToActionTypes;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ActionDefinitions.Editor;

namespace WorkSuite.Confgiuration.Web.ThinClient.Application.Management.MaintenanceSession.Start.Editor {

    /// <summary>
    ///     Metadata configuration for the start maintenance session editor.  Note it is more a
    /// command than an editor as there is nothing to edit you just submit the request.
    /// </summary>
    public class MetadataConfiguration 
                    : EditorMetadataBuilder<NotInMaintenanceSession> {

        protected override void build_model_metadata
                                    ( IEditorModelMetadataBuilder<NotInMaintenanceSession> model_metadata_builder ) {

            model_metadata_builder
                .id( m => Status.Editor.Resources.editor_id)
                .title( Status.Editor.Resources.editor_title )
                ;
        }

        protected override void build_field_metadata
                                    ( IEditorFieldsMetadataBuilder<NotInMaintenanceSession> field_metadata_builder ) {

            // Note - There are no fields to edit as this is more just a request that is submitted rather than an
            //        a update of some existing data.

        }

        protected override void build_action_metadata
                                    ( IEditorActionsMetadataBuilder<NotInMaintenanceSession> action_metadata_builder ) {

            action_metadata_builder
                .add_action<StartMaintenanceSessionAction>(  )
                .call_to_action<PrimaryCallToAction>()
                .id( Controller.Resources.command_id )
                ;

            action_metadata_builder
                .add_action<Cancel>()
                .call_to_action<SecondaryCallToAction>()
                .is_not_a_routed_action()
                ;
        }
    }
}