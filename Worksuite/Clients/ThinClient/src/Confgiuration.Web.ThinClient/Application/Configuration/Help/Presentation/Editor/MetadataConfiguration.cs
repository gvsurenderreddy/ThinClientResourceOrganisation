using WorkSuite.Configuration.Service.Configuration.Help.Edit;
using WorkSuite.Configuration.Service.Messages;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors.Metadata.Static;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.UserActions.Configuration.Static.CallToActionTypes;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ActionDefinitions.Editor;

namespace WorkSuite.Confgiuration.Web.ThinClient.Application.Configuration.Help.Presentation.Editor
{
    public class MetadataConfiguration
                   : EditorMetadataBuilder<UpdateHelpRequest>
    {
        protected override void build_model_metadata
                                (IEditorModelMetadataBuilder<UpdateHelpRequest> model_metadata_builder)
        {
            model_metadata_builder
                .id(m => "help-"+Resources.id)
                .title(Resources.title);
        }

        protected override void build_field_metadata
                               (IEditorFieldsMetadataBuilder<UpdateHelpRequest> fields_metadata_builder)
        {
            fields_metadata_builder
                .for_field(m => m.location_url)
                .id(m => "location_url")
                .label("Location URL")
                .is_required(true)
                .help(HelpMessages.help_02_0018);
        }

        protected override void build_action_metadata
                               (IEditorActionsMetadataBuilder<UpdateHelpRequest> actions_metadata_builder)
        {
            actions_metadata_builder
                .add_action<Save>()
                .call_to_action<PrimaryCallToAction>()
                .id(Command.Update.Resources.editor_id)
                .route_parameter_factory(m => new {m.location_url});

            actions_metadata_builder
                .add_action<Cancel>()
                .call_to_action<SecondaryCallToAction>()
                .is_not_a_routed_action();
        }
    }
}