using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors.Metadata.Static;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.UserActions.Configuration.Static.CallToActionTypes;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ActionDefinitions.Editor;
using WTS.WorkSuite.PlannedSupply.BreakTemplates.New;

namespace WTS.WorkSuite.Web.ThinClient.Application.SetupOptions.BreakTemplates.Presentation.New.Editor
{
    public class MetadataConfiguration
                    : EditorMetadataBuilder<NewBreakTemplateRequest>
    {
        protected override void build_model_metadata(IEditorModelMetadataBuilder<NewBreakTemplateRequest> model_metadata_builder)
        {
            model_metadata_builder
                .id(Resources.id)
                .title(Resources.title)
                ;
        }

        protected override void build_field_metadata(IEditorFieldsMetadataBuilder<NewBreakTemplateRequest> fields_metadata_builder)
        {
            fields_metadata_builder
                .for_field(bt => bt.template_name)
                .id("template_name")
                .is_required(true)
                .label("Name")
                ;

            fields_metadata_builder
                .for_field(m => m.is_hidden)
                .id("is_hidden")
                .label("Hidden")
                .help("Tick hidden to remove this item from all selectable options where it has not been previously selected.")
                ;
        }

        protected override void build_action_metadata(IEditorActionsMetadataBuilder<NewBreakTemplateRequest> actions_metadata_builder)
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