using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.Employees.EmployeeQualifications.Commands.Remove
{
    public class RouteConfiguration
                        : ARouteConfiguration< RemoveEmployeeQualificationController >
    {
        public override string id
        {
            get { return Resources.route_name; }
        }

        public override string url
        {
            get { return "employee/{employee_id}/qualification/{employee_qualification_id}/remove"; }
        }

        public override string action
        {
            get { return "SubmitRequest"; }
        }
    }
}