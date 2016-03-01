using Humanizer;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors.Metadata.Static;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.UserActions.Configuration.Static.CallToActionTypes;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ActionDefinitions.Editor;
using WTS.WorkSuite.HR.HR.Employees.Addresses.Edit;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.Employees.Addresses.Presentation.Editor
{
    public class MetadataConfiguration : EditorMetadataBuilder<UpdateAddressRequest>
    {
        protected override void build_model_metadata(IEditorModelMetadataBuilder<UpdateAddressRequest> model_metadata_builder)
        {
            model_metadata_builder
               .id(m => m.address_id + Resources.id)
               .title(m => "Edit " + m.current_priority.ToString().Ordinalize() + " " + Resources.title.Humanize(LetterCasing.LowerCase))
               ;
        }

        protected override void build_field_metadata(IEditorFieldsMetadataBuilder<UpdateAddressRequest> fields_metadata_builder)
        {
            fields_metadata_builder
                .for_field(m => m.number_or_name)
                .id("number_or_name")
                .label("House number or name")
                .is_required(true)
                ;

            fields_metadata_builder
                .for_field(m => m.line_one)
                .id("line1")
                .label("Line 1")

                ;
            fields_metadata_builder
               .for_field(m => m.line_two)
               .id("line2")
               .label("Line 2")
               ;

            fields_metadata_builder
                .for_field(m => m.line_three)
                .id("line3")
                .label("Line 3")
               ;

            fields_metadata_builder
                .for_field(m => m.county)
                .id("county")
                .label("County");

            fields_metadata_builder
                .for_field(m => m.country)
                .id("country")
                .label("Country");

            fields_metadata_builder
               .for_field(m => m.postcode)
               .id("postcode")
               .label("Postcode")
               .is_required(true)
               ;

            fields_metadata_builder
               .for_field(m => m.employee_id)
               .id("employee_id")
               .is_hidden()
               ;

            fields_metadata_builder
              .for_field(m => m.address_id)
              .id("address_id")
              .is_hidden()
              ;
        }

        protected override void build_action_metadata(IEditorActionsMetadataBuilder<UpdateAddressRequest> actions_metadata_builder)
        {
            actions_metadata_builder
             .add_action<Save>()
             .call_to_action<PrimaryCallToAction>()
             .id(Commands.Update.Resources.id)
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