using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.Employees.addEmployeeRequest.post
{

    public class RouteConfiguration : ARouteConfiguration<AddEmployeeRequestController> {
        public override string id {
            get { return Resources.id ; }
        }

        public override string url {
            get { return "employees/add-employee-request"; }
        }

        public override string action {
            get { return "Post"; }
        }

    }

}