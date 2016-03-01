using Humanizer;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors.Metadata.Static;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.UserActions.Configuration.Static.CallToActionTypes;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ActionDefinitions.Editor;
using WTS.WorkSuite.HR.HR.Employees.EmergencyContacts.Reorder;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.Employees.EmergencyContacts.Presentation.ReorderEditor
{
    public class MetadataConfiguration
                        : EditorMetadataBuilder<ReorderEmergencyContactDetails>
    {
        protected override void build_model_metadata(IEditorModelMetadataBuilder<ReorderEmergencyContactDetails> model_metadata_builder)
        {
            model_metadata_builder
                .id(m => m.emergency_contact_id + Resources.id)
                .title(m => m.current_priority.ToString().Ordinalize() + " " + Resources.title.Humanize(LetterCasing.LowerCase))
                ;
        }

        protected override void build_field_metadata(IEditorFieldsMetadataBuilder<ReorderEmergencyContactDetails> fields_metadata_builder)
        {
            fields_metadata_builder
                .for_field(m => m.name)
                .id("name")
                .label("Name")
                .is_included(m => !string.IsNullOrWhiteSpace(m.name))
                .is_readonly()
                ;

            fields_metadata_builder
                .for_field(m => m.relationship)
                .id(m => m.emergency_contact_id.ToString() + "relationship")
                .label("Relationship")
                .is_included(m => !string.IsNullOrWhiteSpace(m.relationship))
                .is_readonly()
                ;

            fields_metadata_builder
                .for_field(m => m.primary_phone_number)
                .id("contact_number_1")
                .label(Page.Resources.page_field_primary_phone_number_label)
                .is_included(m => !string.IsNullOrWhiteSpace(m.primary_phone_number))
                .is_readonly()
                ;

            fields_metadata_builder
                .for_field(m => m.other_phone_number)
                .id("contact_number_2")
                .label(Page.Resources.page_field_other_phone_number_label)
                .is_included(m => !string.IsNullOrWhiteSpace(m.other_phone_number))
                .is_readonly()
                ;

            fields_metadata_builder
               .for_field(m => m.employee_id)
               .id("employee_id")
               .is_hidden()
               .is_readonly()
               ;

            fields_metadata_builder
              .for_field(m => m.emergency_contact_id)
              .id("emergency_contact_id")
              .is_hidden()
              .is_readonly()
              ;

            fields_metadata_builder
              .for_field(m => m.priority)
              .id("priority")
              .is_hidden()
              .is_readonly()
              ;
        }

        protected override void build_action_metadata(IEditorActionsMetadataBuilder<ReorderEmergencyContactDetails> actions_metadata_builder)
        {
            actions_metadata_builder
                .add_action<Save>()
                .call_to_action<PrimaryCallToAction>()
                .id(Commands.Reorder.Resources.route_name)
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