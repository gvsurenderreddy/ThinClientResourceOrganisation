using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.Employees.EmployeeQualifications.Presentation.List
{
    public class RouteConfiguration
                    : ARouteConfiguration< EmployeeQualificationsListPresenter >
    {
        public override string id
        {
            get { return Resources.route_name; }
        }

        public override string url
        {
            get { return "employee/{employee_id}/employee-qualifications/list"; }
        }

        public override string action
        {
            get { return "List"; }
        }
    }
}