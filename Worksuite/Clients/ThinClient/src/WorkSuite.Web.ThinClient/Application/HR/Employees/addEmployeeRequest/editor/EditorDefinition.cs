using Content.Services.HR.Messages;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors.Metadata.Static;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.UserActions.Configuration.Static.CallToActionTypes;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ActionDefinitions;
using WTS.WorkSuite.HR.HR.Employees.addEmployee;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.Employees.addEmployeeRequest.editor
{
    public class NewEmployeeRequestEditorDefinition : EditorMetadataBuilder<AddEmployeeRequest>
    {
        protected override void build_model_metadata(IEditorModelMetadataBuilder<AddEmployeeRequest> metadata_builder)
        {
            metadata_builder
                .id(Resources.id)
                .title(content_repository.get_resource_value("add_employee_request_editor_resource_title"))
                ;
        }

        protected override void build_field_metadata(IEditorFieldsMetadataBuilder<AddEmployeeRequest> metadata_builder)
        {
            metadata_builder
                .for_field(m => m.employee_reference)
                .id("employee_reference")
                .is_required(true)
                .label(content_repository.get_resource_value("add_employee_request_editor_resource_employee_reference_field_label"))
                .help(content_repository.get_resource_value("add_employee_request_editor_resource_employee_reference_field_help"))
                ;

            metadata_builder
                .for_field(m => m.forename)
                .id("forename")
                .is_required(true)
                .label(content_repository.get_resource_value("add_employee_request_editor_resource_forename_field_label"))
                ;

            metadata_builder
                .for_field(m => m.surname)
                .id("surname")
                .is_required(true)
                .label(content_repository.get_resource_value("add_employee_request_editor_resource_surname_field_label"))
                ;
        }

        protected override void build_action_metadata(IEditorActionsMetadataBuilder<AddEmployeeRequest> metadata_builder)
        {
            metadata_builder
                .add_action<SubmitNew>()
                .call_to_action<PrimaryCallToAction>()
                .id(post.Resources.id)
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