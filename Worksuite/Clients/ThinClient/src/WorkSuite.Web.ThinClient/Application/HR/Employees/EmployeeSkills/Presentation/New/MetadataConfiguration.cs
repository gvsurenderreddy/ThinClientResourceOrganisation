using Content.Services.HR.Messages;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors.Metadata.Static;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.UserActions.Configuration.Static.CallToActionTypes;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ActionDefinitions.Editor;
using WTS.WorkSuite.HR.HR.Employees.EmployeeSkills.New;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.Employees.EmployeeSkills.Presentation.New
{
    public class MetadataConfiguration : EditorMetadataBuilder<NewEmployeeSkillRequest>
    {
        protected override void build_model_metadata(IEditorModelMetadataBuilder<NewEmployeeSkillRequest> model_metadata_builder)
        {
            model_metadata_builder
                .id("new-employee-skill-request")
                .title(EmployeeSkills.Presentation.New.Resources.title);
        }

        protected override void build_field_metadata(IEditorFieldsMetadataBuilder<NewEmployeeSkillRequest> fields_metadata_builder)
        {
            fields_metadata_builder
              .for_field(m => m.skill_id)
              .id("skill_id")
              .label("Skill")
              .is_required(true)
              .is_lookup()
              .help(ValidationMessages.help_02_0008)
              ;

            fields_metadata_builder
             .for_field(m => m.employee_id)
             .id("employee_id")
             .is_hidden()
             ;
        }

        protected override void build_action_metadata(IEditorActionsMetadataBuilder<NewEmployeeSkillRequest> actions_metadata_builder)
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