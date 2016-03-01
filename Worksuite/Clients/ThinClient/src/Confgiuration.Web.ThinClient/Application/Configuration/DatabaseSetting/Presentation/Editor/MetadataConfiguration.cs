using WorkSuite.Configuration.Service.Configuration.DatabaseSettings.Edit;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors.Metadata.Static;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.UserActions.Configuration.Static.CallToActionTypes;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ActionDefinitions.Editor;

namespace WorkSuite.Confgiuration.Web.ThinClient.Application.Configuration.DatabaseSetting.Presentation.Editor
{
    public class MetadataConfiguration
                            : EditorMetadataBuilder<UpdateDatabaseSettingRequest>
    {
        protected override void build_model_metadata(IEditorModelMetadataBuilder<UpdateDatabaseSettingRequest> model_metadata_builder)
        {
            model_metadata_builder
                .id(m => "database-setting-" + Resources.id)
                .title(Resources.title)
                ;
        }

        protected override void build_field_metadata(IEditorFieldsMetadataBuilder<UpdateDatabaseSettingRequest> fields_metadata_builder)
        {
            fields_metadata_builder
                .for_field(m => m.connection_string)
                .id("connection_string")
                .label("Connection string")
                .is_required(true)
                ;

        }

        protected override void build_action_metadata(IEditorActionsMetadataBuilder<UpdateDatabaseSettingRequest> actions_metadata_builder)
        {
            actions_metadata_builder
                .add_action<Save>()
                .call_to_action<PrimaryCallToAction>()
                .id(DatabaseSetting.Commands.update.Resources.editor_id)
                .route_parameter_factory(m => new { m.connection_string })
                ;

            actions_metadata_builder
                .add_action<Cancel>()
                .call_to_action<SecondaryCallToAction>()
                .is_not_a_routed_action()
                ;
        }
    }
}