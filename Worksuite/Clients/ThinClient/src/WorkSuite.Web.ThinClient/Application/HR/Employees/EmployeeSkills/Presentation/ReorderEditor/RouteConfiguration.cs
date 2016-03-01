using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.Employees.EmployeeSkills.Presentation.ReorderEditor
{
    public class RouteConfiguration
                        : ARouteConfiguration<ReorderEmployeeSkillEditorPresenter>
    {
        public override string id
        {
            get { return Resources.id; }
        }

        public override string url
        {
            get { return "employee/{employee_id}/employee-skill/{employee_skill_id}/reorder-editor"; }
        }

        public override string action
        {
            get { return "Editor"; }
        }
    }
}