using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors.Metadata.Static;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.UserActions.Configuration.Static.CallToActionTypes;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ActionDefinitions;
using WTS.WorkSuite.PlannedSupply.ShiftTemplates.Remove;

namespace WTS.WorkSuite.Web.ThinClient.Application.SetupOptions.ShiftTemplates.Presentation.EditOrRemove.RemoveEditor
{
    public class MetadataConfiguration
                         : EditorMetadataBuilder<RemoveShiftTemplateRequest>
    {
        protected override void build_model_metadata
                                  (IEditorModelMetadataBuilder<RemoveShiftTemplateRequest> model_metadata_builder)
        {
            model_metadata_builder
                .id(Resources.id)
                .title(Resources.title);
        }

        protected override void build_field_metadata
                                 (IEditorFieldsMetadataBuilder<RemoveShiftTemplateRequest> fields_metadata_builder)
        {
            fields_metadata_builder
                .for_field(x => x.shift_template_id)
                .id("shift_template_id")
                .is_hidden();
        }

        protected override void build_action_metadata
                               (IEditorActionsMetadataBuilder<RemoveShiftTemplateRequest> actions_metadata_builder)
        {
            actions_metadata_builder
                .add_action<SubmitRemove>()
                .call_to_action<PrimaryCallToAction>()
                .id(Commands.Remove.Resources.id)
                .route_parameter_factory(x => new {x.shift_template_id});
        }
    }
}