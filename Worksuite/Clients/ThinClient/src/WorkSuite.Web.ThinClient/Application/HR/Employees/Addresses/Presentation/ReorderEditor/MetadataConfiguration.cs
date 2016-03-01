using Humanizer;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors.Metadata.Static;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.UserActions.Configuration.Static.CallToActionTypes;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ActionDefinitions.Editor;
using WTS.WorkSuite.HR.HR.Employees.Addresses.Reorder;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.Employees.Addresses.Presentation.ReorderEditor
{
    public class MetadataConfiguration : EditorMetadataBuilder<ReorderAddressDetails>
    {
        protected override void build_model_metadata(IEditorModelMetadataBuilder<ReorderAddressDetails> model_metadata_builder)
        {
            model_metadata_builder
               .id(m => m.address_id + Resources.id)
               .title(m => m.current_priority.ToString().Ordinalize() + " " + Resources.title.Humanize(LetterCasing.LowerCase))
               ;
        }

        protected override void build_field_metadata(IEditorFieldsMetadataBuilder<ReorderAddressDetails> fields_metadata_builder)
        {
            fields_metadata_builder
                .for_field(m => m.number_or_name)
                .id("number_or_name")
                .label("House number or name")
                .is_included(m => !string.IsNullOrWhiteSpace(m.number_or_name))
                .is_readonly()
                ;

            fields_metadata_builder
                .for_field(m => m.line1)
                .id("line1")
                .label("Line 1")
                .is_included(m => !string.IsNullOrWhiteSpace(m.line1))
                .is_readonly()

                ;
            fields_metadata_builder
               .for_field(m => m.line2)
               .id("line2")
               .label("Line 2")
               .is_included(m => !string.IsNullOrWhiteSpace(m.line2))
               .is_readonly()
               ;

            fields_metadata_builder
                .for_field(m => m.line3)
                .id("line3")
                .label("Line 3")
                .is_included(m => !string.IsNullOrWhiteSpace(m.line3))
                .is_readonly()
               ;

            fields_metadata_builder
                .for_field(m => m.county)
                .id("county")
                .label("County")
                .is_included(m => !string.IsNullOrWhiteSpace(m.county))
                .is_readonly()
                ;

            fields_metadata_builder
                .for_field(m => m.country)
                .id("country")
                .label("Country")
                .is_included(m => !string.IsNullOrWhiteSpace(m.country))
                .is_readonly()
                ;

            fields_metadata_builder
               .for_field(m => m.postcode)
               .id("postcode")
               .label("Postcode")
               .is_included(m => !string.IsNullOrWhiteSpace(m.postcode))
               .is_readonly()
               ;

            fields_metadata_builder
               .for_field(m => m.employee_id)
               .id("employee_id")
               .is_hidden()
               .is_readonly()
               ;

            fields_metadata_builder
              .for_field(m => m.address_id)
              .id("address_id")
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

        protected override void build_action_metadata(IEditorActionsMetadataBuilder<ReorderAddressDetails> actions_metadata_builder)
        {
            actions_metadata_builder
             .add_action<Save>()
             .call_to_action<PrimaryCallToAction>()
             .id(Commands.Reorder.Resources.route_name)
             .route_parameter_factory(m => new { m.address_id })
             ;

            actions_metadata_builder
                .add_action<Cancel>()
                .call_to_action<SecondaryCallToAction>()
                .is_not_a_routed_action()
                ;
        }
    }
}