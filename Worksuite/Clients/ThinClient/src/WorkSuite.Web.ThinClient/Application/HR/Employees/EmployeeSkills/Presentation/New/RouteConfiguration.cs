using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.Employees.EmployeeSkills.Presentation.New
{
    public class RouteConfiguration : ARouteConfiguration<NewEmployeeSkillPresenter>
    {
        public override string id
        {
            get { return Resources.id; }
        }

        public override string url
        {
            get { return "employee/{employee_id}/skill/new"; }
        }

        public override string action
        {
            get { return "Editor"; }
        }
    }
}