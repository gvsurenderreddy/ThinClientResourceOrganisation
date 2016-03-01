using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors.Metadata.Static;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.UserActions.Configuration.Static.CallToActionTypes;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ActionDefinitions.Editor;
using WTS.WorkSuite.HR.HR.Employees.Addresses.New;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.Employees.Addresses.Presentation.New
{
    public class MetadataConfiguration : EditorMetadataBuilder<NewAddressRequest>
    {
        protected override void build_model_metadata(IEditorModelMetadataBuilder<NewAddressRequest> model_metadata_builder)
        {
            model_metadata_builder
                .id("new-address-request")
                .title(Resources.title);
        }

        protected override void build_field_metadata(IEditorFieldsMetadataBuilder<NewAddressRequest> fields_metadata_builder)
        {
            fields_metadata_builder
              .for_field(m => m.number_or_name)
              .id("number_or_name")
              .is_required(true)
              .label("House name or number")
              ;

            fields_metadata_builder
                .for_field(m => m.line_one)
                .id("line_one")
                .label("Line 1")
                ;

            fields_metadata_builder
                .for_field(m => m.line_two)
                .id("line_two")
                .label("Line 2")
                ;

            fields_metadata_builder
              .for_field(m => m.line_three)
              .id("line_three")
              .label("Line 3")
              ;

            fields_metadata_builder
             .for_field(m => m.county)
             .id("county")
             .label("County")
             ;

            fields_metadata_builder
             .for_field(m => m.country)
             .id("country")
             .label("Country")
             ;

            fields_metadata_builder
              .for_field(m => m.postcode)
              .id("postcode")
              .is_required(true)
              .label("Postcode")
              ;

            fields_metadata_builder
             .for_field(m => m.employee_id)
             .id("employee_id")
             .is_hidden()
             ;
        }

        protected override void build_action_metadata(IEditorActionsMetadataBuilder<NewAddressRequest> actions_metadata_builder)
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