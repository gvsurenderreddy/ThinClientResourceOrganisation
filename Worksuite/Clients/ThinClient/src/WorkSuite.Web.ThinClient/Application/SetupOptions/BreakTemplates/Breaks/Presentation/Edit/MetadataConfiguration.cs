using Content.Services.PlannedSupply.Messages;
using Humanizer;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors.Metadata.Static;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.UserActions.Configuration.Static.CallToActionTypes;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ActionDefinitions.Editor;
using WTS.WorkSuite.PlannedSupply.BreakTemplates.Break.Edit;

namespace WTS.WorkSuite.Web.ThinClient.Application.SetupOptions.BreakTemplates.Breaks.Presentation.Edit
{
    public class MetadataConfiguration
                    : EditorMetadataBuilder<UpdateBreakRequest>
    {
        protected override void build_model_metadata(IEditorModelMetadataBuilder<UpdateBreakRequest> model_metadata_builder)
        {
            model_metadata_builder
                .id("update-break-request")
                .title(m => "Edit " + m.current_priority.ToString().Ordinalize() + " " + Resources.title.Humanize(LetterCasing.LowerCase))
                ;
        }

        protected override void build_field_metadata(IEditorFieldsMetadataBuilder<UpdateBreakRequest> fields_metadata_builder)
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
                .for_field(sb => sb.is_paid)
                .id("is_paid")
                .label("Paid")
                ;

            fields_metadata_builder
                .for_field(sb => sb.break_id)
                .id("break_id")
                .is_hidden()
                ;

            fields_metadata_builder
                .for_field(sb => sb.template_id)
                .id("template_id")
                .is_hidden()
                ;
        }

        protected override void build_action_metadata(IEditorActionsMetadataBuilder<UpdateBreakRequest> actions_metadata_builder)
        {
            actions_metadata_builder
                .add_action<Save>()
                .call_to_action<PrimaryCallToAction>()
                .id(Commands.Update.Resources.id)
                .route_parameter_factory(r => new { r.template_id, r.break_id })
                ;

            actions_metadata_builder
                .add_action<Cancel>()
                .call_to_action<SecondaryCallToAction>()
                .is_not_a_routed_action()
                ;
        }
    }
}