using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.Employees.Remove.Commands.Delete
{
    public class RouteConfiguration : ARouteConfiguration<DeleteEmployeeController> {
        public override string id {
            get { return Resources.id; }
        }

        public override string url {
            get { return "employee/{employee_id}/remove-employee-editor"; }
        }

        public override string action {
            get { return "SubmitRequest"; }
        }

    }
}