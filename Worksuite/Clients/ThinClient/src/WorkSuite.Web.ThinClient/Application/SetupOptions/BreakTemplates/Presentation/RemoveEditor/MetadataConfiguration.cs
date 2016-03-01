using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors.Metadata.Static;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.UserActions.Configuration.Static.CallToActionTypes;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ActionDefinitions;
using WTS.WorkSuite.PlannedSupply.BreakTemplates.Remove;

namespace WTS.WorkSuite.Web.ThinClient.Application.SetupOptions.BreakTemplates.Presentation.RemoveEditor
{
    public class MetadataConfiguration
                    : EditorMetadataBuilder<RemoveBreakTemplateRequest>
    {
        protected override void build_model_metadata(IEditorModelMetadataBuilder<RemoveBreakTemplateRequest> model_metadata_builder)
        {
            model_metadata_builder
                .id(Resources.id)
                .title(Resources.title)
                ;
        }

        protected override void build_field_metadata(IEditorFieldsMetadataBuilder<RemoveBreakTemplateRequest> fields_metadata_builder)
        {
            fields_metadata_builder
                .for_field(sbt => sbt.template_name)
                .id("break_template_name")
                .label("Name")
                .is_readonly()
                ;

            fields_metadata_builder
                .for_field(sbt => sbt.hidden_status)
                .id("hidden_status")
                .label("Hidden")
                .is_readonly()
                ;

            fields_metadata_builder
                .for_field(sbt => sbt.template_id)
                .id("break_template_id")
                .is_hidden()
                ;
        }

        protected override void build_action_metadata(IEditorActionsMetadataBuilder<RemoveBreakTemplateRequest> actions_metadata_builder)
        {
            actions_metadata_builder
                    .add_action<SubmitRemove>()
                    .call_to_action<PrimaryCallToAction>()
                    .id(Commands.Remove.Resources.id)
                    .route_parameter_factory(sbt => new { sbt.template_id })
                    ;

            actions_metadata_builder
                    .add_action<Cancel>()
                    .call_to_action<SecondaryCallToAction>()
                    .is_not_a_routed_action()
                    ;
        }
    }
}