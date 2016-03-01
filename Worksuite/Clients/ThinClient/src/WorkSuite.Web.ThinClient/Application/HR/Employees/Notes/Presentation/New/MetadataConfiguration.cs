using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors.Metadata.Static;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.UserActions.Configuration.Static.CallToActionTypes;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ActionDefinitions.Editor;
using WTS.WorkSuite.HR.HR.Employees.Notes.New;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.Employees.Notes.Presentation.New
{
    public class MetadataConfiguration : EditorMetadataBuilder<NewNoteRequest>
    {
        protected override void build_model_metadata(IEditorModelMetadataBuilder<NewNoteRequest> model_metadata_builder)
        {
            model_metadata_builder
                .id("new-notes-request")
                .title(Resources.title);
        }

        protected override void build_field_metadata(IEditorFieldsMetadataBuilder<NewNoteRequest> fields_metadata_builder)
        {
            fields_metadata_builder
                .for_field(m => m.note)
                .id("note")
                .is_required(true)
                .label("Note");

            fields_metadata_builder
            .for_field(m => m.employee_id)
            .id("employee_id")
            .is_hidden()
            ;
        }

        protected override void build_action_metadata(IEditorActionsMetadataBuilder<NewNoteRequest> actions_metadata_builder)
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