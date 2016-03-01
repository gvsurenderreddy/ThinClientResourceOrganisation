using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors.Metadata.Static;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.UserActions.Configuration.Static.CallToActionTypes;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ActionDefinitions.Editor;
using WTS.WorkSuite.HR.HR.Employees.Notes.Edit;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.Employees.Notes.Presentation.Editor
{
    public class MetadataConfiguration : EditorMetadataBuilder<UpdateRequest>
    {
        protected override void build_model_metadata(IEditorModelMetadataBuilder<UpdateRequest> model_metadata_builder)
        {
            model_metadata_builder
             .id(m => m.note_id + Resources.id)
             .title(Resources.title)
             ;
        }

        protected override void build_field_metadata(IEditorFieldsMetadataBuilder<UpdateRequest> fields_metadata_builder)
        {
            fields_metadata_builder
                .for_field(m => m.note)
                .id("note")
                .label("Note")
                .is_required(true)
                ;

            fields_metadata_builder
              .for_field(m => m.employee_id)
              .id("employee_id")
              .is_hidden()
              ;

            fields_metadata_builder
              .for_field(m => m.note_id)
              .id("note_id")
              .is_hidden()
              ;
        }

        protected override void build_action_metadata(IEditorActionsMetadataBuilder<UpdateRequest> actions_metadata_builder)
        {
            actions_metadata_builder
            .add_action<Save>()
            .call_to_action<PrimaryCallToAction>()
            .id(Commands.Update.Resources.id)
            .route_parameter_factory(m => new { m.note_id })
            ;

            actions_metadata_builder
                .add_action<Cancel>()
                .call_to_action<SecondaryCallToAction>()
                .is_not_a_routed_action()
                ;
        }
    }
}