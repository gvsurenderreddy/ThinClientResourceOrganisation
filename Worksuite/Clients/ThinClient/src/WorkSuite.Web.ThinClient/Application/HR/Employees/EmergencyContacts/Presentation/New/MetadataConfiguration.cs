using Content.Services.HR.Messages;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors.Metadata.Static;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.UserActions.Configuration.Static.CallToActionTypes;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ActionDefinitions.Editor;
using WTS.WorkSuite.HR.HR.Employees.EmergencyContacts.New;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.Employees.EmergencyContacts.Presentation.New
{
    public class MetadataConfiguration : EditorMetadataBuilder<NewEmergencyContactRequest>
    {
        protected override void build_model_metadata(IEditorModelMetadataBuilder<NewEmergencyContactRequest> model_metadata_builder)
        {
            model_metadata_builder
                .id("new-emergency-contact-request")
                .title(Resources.title);
        }

        protected override void build_field_metadata(IEditorFieldsMetadataBuilder<NewEmergencyContactRequest> fields_metadata_builder)
        {
            fields_metadata_builder
              .for_field(m => m.name)
              .is_required(true)
              .id("name")
              .label("Name")
              ;

            fields_metadata_builder
              .for_field(m => m.relationship_id)
              .id("relationship_id")
              .label("Relationship")
              .is_lookup()
              .help(ValidationMessages.help_02_0006)
              ;

            fields_metadata_builder
              .for_field(m => m.primary_phone_number)
              .is_required(true)
              .id("contact_number_1")
              .label(Page.Resources.page_field_primary_phone_number_label)
              .help(ValidationMessages.help_02_0010)
              ;

            fields_metadata_builder
              .for_field(m => m.other_phone_number)
              .id("contact_number_2")
              .label(Page.Resources.page_field_other_phone_number_label)
              .help(ValidationMessages.help_02_0011)
              ;

            fields_metadata_builder
             .for_field(m => m.employee_id)
             .id("employee_id")
             .is_hidden()
             ;
        }

        protected override void build_action_metadata(IEditorActionsMetadataBuilder<NewEmergencyContactRequest> actions_metadata_builder)
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