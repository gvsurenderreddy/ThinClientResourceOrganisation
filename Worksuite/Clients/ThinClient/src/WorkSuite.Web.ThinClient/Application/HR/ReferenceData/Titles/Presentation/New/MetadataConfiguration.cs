using Content.Services.HR.Messages;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors.Metadata.Static;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.UserActions.Configuration.Static.CallToActionTypes;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ActionDefinitions.Editor;
using WTS.WorkSuite.HR.HR.ReferenceData.Titles.New;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.ReferenceData.Titles.Presentation.New
{
    public class MetadataConfiguration : EditorMetadataBuilder<CreateTitleRequest>
    {
        protected override void build_model_metadata(IEditorModelMetadataBuilder<CreateTitleRequest> metadata_builder)
        {
            metadata_builder
                // to do: if we just want an id here then we should allow the id to be set to just text
                .id("new-title-request")
                .title(Resources.title)
                ;
        }

        protected override void build_field_metadata(IEditorFieldsMetadataBuilder<CreateTitleRequest> metadata_builder)
        {
            metadata_builder
                .for_field(m => m.description)
                .id("description")
                .is_required(true)
                .label("Title")
                ;

            // to do: introduce boolean field
            metadata_builder
                .for_field(m => m.is_hidden)
                .id("is_hidden")
                .label("Hidden")
                .help(ValidationMessages.help_02_0012)
                ;
        }

        protected override void build_action_metadata(IEditorActionsMetadataBuilder<CreateTitleRequest> metadata_builder)
        {
            // to do: add actions later

            metadata_builder
                .add_action<Save>()
                .call_to_action<PrimaryCallToAction>()
                .id(Commands.Create.Resources.id)
                .route_parameter_factory(r => new { })
                ;

            metadata_builder
                .add_action<Cancel>()
                .call_to_action<SecondaryCallToAction>()
                .is_not_a_routed_action()
                ;
        }
    }
}