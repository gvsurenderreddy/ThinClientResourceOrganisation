using System.Globalization;
using Humanizer;
using WTS.WorkSuite.HR.HR.Employees.EmployeeSkills;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Reports.Metadata.Static;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.Employees.EmployeeSkills.Presentation.Report
{
    public class MetadataConfiguration : ReportMetadataBuilder<EmployeeSkillDetails>
    {
        protected override void build_model_metadata(IReportModelMetadataBuilder<EmployeeSkillDetails> model_metadata_builder)
        {
            model_metadata_builder
              .presenter_id(Resources.id)
              .id(m => m.employee_skill_id.ToString())
              .title(m => m.priority.Ordinalize() + " " + Resources.title.Humanize(LetterCasing.LowerCase))
              ;
        }

        protected override void build_field_metadata(IReportFieldsMetadataBuilder<EmployeeSkillDetails> field_metadata_builder)
        {

            field_metadata_builder
              .for_field(m => m.skill)
              .id(m => m.employee_skill_id.ToString(CultureInfo.InvariantCulture) + "-skill")
              .is_included(m => !string.IsNullOrWhiteSpace(m.skill))
              .label("Skill")
              ;

        }

        protected override void build_action_metadata(IReportActionsMetadataBuilder<EmployeeSkillDetails> action_metadata_builder)
        {
            action_metadata_builder
               .add_action<global::WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ActionDefinitions.DetailsList.Remove>()
               .id(Commands.Remove.Resources.route_name)
               .route_parameter_factory(m => new { m.employee_skill_id })
               ;

            action_metadata_builder
                .add_action<global::WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ActionDefinitions.DetailsList.Reorder>()
                .id(EmployeeSkills.Presentation.ReorderEditor.Resources.id)
                .route_parameter_factory(m => new { m.employee_skill_id });
            ;
        }
    }
}