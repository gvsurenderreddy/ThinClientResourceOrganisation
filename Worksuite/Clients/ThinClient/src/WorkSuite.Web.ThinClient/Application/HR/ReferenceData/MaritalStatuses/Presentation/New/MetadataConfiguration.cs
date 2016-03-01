using Content.Services.HR.Messages;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors.Metadata.Static;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.UserActions.Configuration.Static.CallToActionTypes;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ActionDefinitions.Editor;
using WTS.WorkSuite.HR.HR.ReferenceData.MaritalStatuses.New;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.ReferenceData.MaritalStatuses.Presentation.New
{
    public class MetadataConfiguration
                        : EditorMetadataBuilder<CreateMaritalStatusRequest>
    {
        protected override void build_model_metadata(IEditorModelMetadataBuilder<CreateMaritalStatusRequest> model_metadata_builder)
        {
            model_metadata_builder
                .id("new-MaritalStatus-request")
                .title(Resources.title)
                ;
        }

        protected override void build_field_metadata(IEditorFieldsMetadataBuilder<CreateMaritalStatusRequest> fields_metadata_builder)
        {
            fields_metadata_builder
                .for_field(m => m.description)
                .id("description")
                .is_required(true)
                .label("Marital status")
                ;

            fields_metadata_builder
                .for_field(m => m.is_hidden)
                .id("is_hidden")
                .label("Hidden")
                .help(ValidationMessages.help_02_0012)
                ;
        }

        protected override void build_action_metadata(IEditorActionsMetadataBuilder<CreateMaritalStatusRequest> actions_metadata_builder)
        {
            actions_metadata_builder
                .add_action<Save>()
                .call_to_action<PrimaryCallToAction>()
                .id(Commands.Create.Resources.id)
                .route_parameter_factory(r => new { })
                ;

            actions_metadata_builder
                .add_action<Cancel>()
                .call_to_action<SecondaryCallToAction>()
                .is_not_a_routed_action()
                ;
        }
    }
}