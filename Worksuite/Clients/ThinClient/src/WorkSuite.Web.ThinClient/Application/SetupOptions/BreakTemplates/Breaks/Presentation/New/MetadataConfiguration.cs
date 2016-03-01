using Content.Services.PlannedSupply.Messages;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors.Metadata.Static;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.UserActions.Configuration.Static.CallToActionTypes;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ActionDefinitions.Editor;
using WTS.WorkSuite.PlannedSupply.BreakTemplates.Break.New;

namespace WTS.WorkSuite.Web.ThinClient.Application.SetupOptions.BreakTemplates.Breaks.Presentation.New
{
    public class MetadataConfiguration
                    : EditorMetadataBuilder<NewBreakRequest>
    {
        protected override void build_model_metadata(IEditorModelMetadataBuilder<NewBreakRequest> model_metadata_builder)
        {
            model_metadata_builder
                .id("new-break-request")
                .title(Resources.title)
                ;
        }

        protected override void build_field_metadata(IEditorFieldsMetadataBuilder<NewBreakRequest> fields_metadata_builder)
        {
            fields_metadata_builder
                .for_field(sb => sb.off_set)
                .id("off-set-in-seconds")
                .is_required(true)
                .help(HelperMessage.help_02_0021)
                .label("Starts after")
                ;

            fields_metadata_builder
                .for_field(sb => sb.duration)
                .id("duration-in-seconds")
                .is_required(true)
                .help(HelperMessage.help_02_0022)
                .label("Duration")
                ;

            fields_metadata_builder
                .for_field(m => m.is_paid)
                .id("is_paid")
                .label("Paid")
                ;
        }

        protected override void build_action_metadata(IEditorActionsMetadataBuilder<NewBreakRequest> actions_metadata_builder)
        {
            actions_metadata_builder
                .add_action<Save>()
                .call_to_action<PrimaryCallToAction>()
                .id(Commands.Create.Resources.id)
                .route_parameter_factory(r => new { r.template_id })
                ;

            actions_metadata_builder
                .add_action<Cancel>()
                .call_to_action<SecondaryCallToAction>()
                .is_not_a_routed_action()
                ;
        }
    }
}