using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors.Metadata.Static;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.UserActions.Configuration.Static.CallToActionTypes;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ActionDefinitions.Editor;
using WTS.WorkSuite.SupplyShortage.Employee.Sickness.addSickness;
using Cancel = WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ActionDefinitions.Editor.Cancel;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.employee.Sickness.addSickness.editor
{
    public class AddSicknessEditorDefinition : EditorMetadataBuilder<AddSicknessRequest>
    {
        protected override void build_model_metadata(IEditorModelMetadataBuilder<AddSicknessRequest> model_metadata_builder)
        {
            model_metadata_builder
                 .id(e => e.employee_id + Resources.id)
               .title(content_repository.get_resource_value("add_sickness_editor_title"))
               ;
        }

        protected override void build_field_metadata(IEditorFieldsMetadataBuilder<AddSicknessRequest> fields_metadata_builder)
        {

            fields_metadata_builder
                .for_field(oc => oc.sickness_date)
                .id("sickness_date")
                .is_required(true)
                .is_composed()
                .label(content_repository.get_resource_value("add_sickness_editor_sickness_date_label"))
                .help(content_repository.get_resource_value("add_sickness_editor_sickness_date_help_text"))
                ;

            fields_metadata_builder
                .for_field(h => h.employee_id)
                .id("employee_id")
                .is_hidden()
                ;
        }

        protected override void build_action_metadata(IEditorActionsMetadataBuilder<AddSicknessRequest> actions_metadata_builder)
        {
            actions_metadata_builder
               .add_action<Save>()
               .call_to_action<PrimaryCallToAction>()
               .id(post.Resources.id)
               .route_parameter_factory(r => new { r.employee_id })
               ;  

            actions_metadata_builder
                .add_action<Cancel>()
                .call_to_action<SecondaryCallToAction>()
                .is_not_a_routed_action()
                ;
        }
    }
}