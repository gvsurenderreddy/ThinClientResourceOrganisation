using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.Employees.EmployeeSkills.Presentation.Page {

    public class RouteConfiguration 
                    : APageRouteConfiguration<EmployeeSkillsPresenter> {
        public override string id {
            get { return Resources.page_id; }
        }

        public override string url
        {
            get { return "employee/{employee_id}/skills"; }
        }

    }
}