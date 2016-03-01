using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.Employees.EmployeeSkills.Commands.Remove
{
    public class RouteConfiguration : ARouteConfiguration<RemoveEmployeeSkillController>
    {
        public override string id
        {
            get { return Resources.route_name; }
        }

        public override string url
        {
            get { return "employee/{employee_id}/skill/{employee_skill_id}/remove"; }
        }

        public override string action
        {
            get { return "SubmitRequest"; }
        }
    }
}