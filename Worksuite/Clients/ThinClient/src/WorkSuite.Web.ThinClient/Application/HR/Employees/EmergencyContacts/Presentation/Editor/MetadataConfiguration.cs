using Content.Services.HR.Messages;
using Humanizer;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors.Metadata.Static;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.UserActions.Configuration.Static.CallToActionTypes;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ActionDefinitions.Editor;
using WTS.WorkSuite.HR.HR.Employees.EmergencyContacts.Edit;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.Employees.EmergencyContacts.Presentation.Editor
{
    public class MetadataConfiguration : EditorMetadataBuilder<UpdateRequest>
    {
        protected override void build_model_metadata(IEditorModelMetadataBuilder<UpdateRequest> model_metadata_builder)
        {
            model_metadata_builder
               .id(m => m.emergency_contact_id + Resources.id)
               .title(m => "Edit " + m.current_priority.ToString().Ordinalize() + " " + Resources.title.Humanize(LetterCasing.LowerCase))
               ;
        }

        protected override void build_field_metadata(IEditorFieldsMetadataBuilder<UpdateRequest> fields_metadata_builder)
        {
            fields_metadata_builder
                .for_field(m => m.name)
                .id("name")
                .label("Name")
                .is_required(true)
                ;

            fields_metadata_builder
                .for_field(m => m.primary_phone_number)
                .id("contact_number_1")
                .label(Page.Resources.page_field_primary_phone_number_label)
                .is_required(true)
                .help(ValidationMessages.help_02_0010)
                ;

            fields_metadata_builder
                .for_field(m => m.other_phone_number)
                .id("contact_number_2")
                .label(Page.Resources.page_field_other_phone_number_label)
                .help(ValidationMessages.help_02_0011)
                ;

            fields_metadata_builder
              .for_field(m => m.relationship_id)
              .id("relationship_id")
              .label("Relationship")
              .is_lookup()
              .help(ValidationMessages.help_02_0006)
              ;

            fields_metadata_builder
               .for_field(m => m.employee_id)
               .id("employee_id")
               .is_hidden()
               ;

            fields_metadata_builder
              .for_field(m => m.emergency_contact_id)
              .id("emergency_contact_id")
              .is_hidden()
              ;
        }

        protected override void build_action_metadata(IEditorActionsMetadataBuilder<UpdateRequest> actions_metadata_builder)
        {
            actions_metadata_builder
             .add_action<Save>()
             .call_to_action<PrimaryCallToAction>()
             .id(Commands.Update.Resources.id)
             .route_parameter_factory(m => new { m.emergency_contact_id })
             ;

            actions_metadata_builder
                .add_action<Cancel>()
                .call_to_action<SecondaryCallToAction>()
                .is_not_a_routed_action()
                ;
        }
    }
}