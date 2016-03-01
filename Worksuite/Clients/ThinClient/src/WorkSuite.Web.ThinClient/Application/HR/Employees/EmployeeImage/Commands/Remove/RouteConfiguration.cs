using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.Employees.EmployeeImage.Commands.Remove
{
    public class RouteConfiguration : ARouteConfiguration<RemoveEmployeeImageController>
    {
        public override string id
        {
            get { return Resources.route_name; }
        }

        public override string url
        {
            get { return "employee/{employee_id}/remove-employee-image"; }
        }

        public override string action
        {
            get { return "SubmitRequest"; }
        }
    }
}