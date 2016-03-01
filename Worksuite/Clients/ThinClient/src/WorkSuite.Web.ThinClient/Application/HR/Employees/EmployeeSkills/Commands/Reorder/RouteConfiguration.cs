using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.Employees.EmployeeSkills.Commands.Reorder
{
    public class RouteConfiguration
                        : ARouteConfiguration<ReorderEmployeeSkillController>
    {
        public override string id
        {
            get { return Resources.route_name; }
        }

        public override string url
        {
            get { return "employee/{employee_id}/employee-skill/{employee_skill_id}/reorder"; }
        }

        public override string action
        {
            get { return "SubmitRequest"; }
        }
    }
}