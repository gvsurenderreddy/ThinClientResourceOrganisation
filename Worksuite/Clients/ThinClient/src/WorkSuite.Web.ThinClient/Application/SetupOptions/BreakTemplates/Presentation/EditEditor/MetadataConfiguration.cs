using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors.Metadata.Static;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.UserActions.Configuration.Static.CallToActionTypes;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ActionDefinitions;
using WTS.WorkSuite.PlannedSupply.BreakTemplates.Edit;

namespace WTS.WorkSuite.Web.ThinClient.Application.SetupOptions.BreakTemplates.Presentation.EditEditor
{
    public class MetadataConfiguration
                        : EditorMetadataBuilder<UpdateBreakTemplateRequest>
    {
        protected override void build_model_metadata(IEditorModelMetadataBuilder<UpdateBreakTemplateRequest> model_metadata_builder)
        {
            model_metadata_builder
                .id(Resources.id)
                .title(Resources.title)
                ;
        }

        protected override void build_field_metadata(IEditorFieldsMetadataBuilder<UpdateBreakTemplateRequest> fields_metadata_builder)
        {
            fields_metadata_builder
                .for_field(sbt => sbt.template_name)
                .id("break_template_name")
                .is_required(true)
                .label("Name")
                ;

            fields_metadata_builder
                .for_field(sbt => sbt.is_hidden)
                .id("is_hidden")
                .label("Hidden")
                .help("Tick hidden to remove this item from all selectable options where it has not been previously selected.")
                ;

            fields_metadata_builder
                .for_field(sbt => sbt.template_id)
                .id("break_template_id")
                .is_hidden()
                ;
        }

        protected override void build_action_metadata(IEditorActionsMetadataBuilder<UpdateBreakTemplateRequest> actions_metadata_builder)
        {
            actions_metadata_builder
                .add_action<SubmitEdit>()
                .call_to_action<PrimaryCallToAction>()
                .id(Commands.Update.Resources.id)
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