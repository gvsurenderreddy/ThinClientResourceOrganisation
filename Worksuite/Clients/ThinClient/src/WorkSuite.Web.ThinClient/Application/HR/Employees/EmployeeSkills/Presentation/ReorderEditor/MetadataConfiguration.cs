using Humanizer;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors.Metadata.Static;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.UserActions.Configuration.Static.CallToActionTypes;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ActionDefinitions.Editor;
using WTS.WorkSuite.HR.HR.Employees.EmployeeSkills.Reorder;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.Employees.EmployeeSkills.Presentation.ReorderEditor
{
    public class MetadataConfiguration
                        : EditorMetadataBuilder<ReorderEmployeeSkillDetails>
    {
        protected override void build_model_metadata(IEditorModelMetadataBuilder<ReorderEmployeeSkillDetails> model_metadata_builder)
        {
            model_metadata_builder
                .id(m => m.employee_skill_id + Resources.id)
                .title(m => m.current_priority.ToString().Ordinalize() + " " + Resources.title.Humanize(LetterCasing.LowerCase))
                ;
        }

        protected override void build_field_metadata(IEditorFieldsMetadataBuilder<ReorderEmployeeSkillDetails> fields_metadata_builder)
        {
            fields_metadata_builder
                .for_field(m => m.skill)
                .id(m => m.employee_skill_id.ToString() + "skill")
                .label("Skill")
                .is_included(m => !string.IsNullOrWhiteSpace(m.skill))
                .is_readonly()
                ;

            fields_metadata_builder
               .for_field(m => m.employee_id)
               .id("employee_id")
               .is_hidden()
               .is_readonly()
               ;

            fields_metadata_builder
              .for_field(m => m.employee_skill_id)
              .id("employee_skill_id")
              .is_hidden()
              .is_readonly()
              ;

            fields_metadata_builder
              .for_field(m => m.priority)
              .id("priority")
              .is_hidden()
              .is_readonly()
              ;
        }

        protected override void build_action_metadata(IEditorActionsMetadataBuilder<ReorderEmployeeSkillDetails> actions_metadata_builder)
        {
            actions_metadata_builder
                .add_action<Save>()
                .call_to_action<PrimaryCallToAction>()
                .id(Commands.Reorder.Resources.route_name)
                .route_parameter_factory(m => new { m.employee_skill_id })
                ;

            actions_metadata_builder
                .add_action<Cancel>()
                .call_to_action<SecondaryCallToAction>()
                .is_not_a_routed_action()
                ;
        }
    }
}