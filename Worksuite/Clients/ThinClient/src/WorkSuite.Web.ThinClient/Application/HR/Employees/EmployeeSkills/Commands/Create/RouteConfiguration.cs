using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.Employees.EmployeeSkills.Commands.Create
{
    public class RouteConfiguration : ARouteConfiguration<CreateEmployeeSkillController>
    {
        public override string id
        {
            get { return Resources.id; }
        }

        public override string url
        {
            get { return "employee-skill/create"; }
        }

        public override string action
        {
            get { return "SubmitRequest"; }
        }
    }
}