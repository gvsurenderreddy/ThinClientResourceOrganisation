using Content.Services.HR.Messages;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors.Metadata.Static;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.UserActions.Configuration.Static.CallToActionTypes;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ActionDefinitions.Editor;
using WTS.WorkSuite.HR.HR.Employees.EmployeeDocuments.New;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.Employees.EmployeeDocuments.Presentation.New
{
    public class MetadataConfiguration : EditorMetadataBuilder<NewEmployeeDocumentRequest>
    {
        protected override void build_model_metadata(IEditorModelMetadataBuilder<NewEmployeeDocumentRequest> model_metadata_builder)
        {
            model_metadata_builder
                .id("new-employee-document-request")
                .title(Resources.title);
        }

        protected override void build_field_metadata(IEditorFieldsMetadataBuilder<NewEmployeeDocumentRequest> fields_metadata_builder)
        {
            fields_metadata_builder
              .for_field(m => m.document_id)
              .is_required(true)
              .id(a => "document-" + a.document_id)
              .label("Upload a file")
              .help(ValidationMessages.help_02_0009)
              ;

            fields_metadata_builder
              .for_field(m => m.description)
              .is_required(true)
              .id("description")
              .label("Description")
              ;

            fields_metadata_builder
             .for_field(m => m.employee_id)
             .id("employee_id")
             .is_hidden()
             ;
        }

        protected override void build_action_metadata(IEditorActionsMetadataBuilder<NewEmployeeDocumentRequest> actions_metadata_builder)
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