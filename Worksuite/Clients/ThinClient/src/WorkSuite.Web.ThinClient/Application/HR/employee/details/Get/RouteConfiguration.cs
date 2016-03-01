using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.employee.details.Get {

    public class RouteConfiguration 
                    : APageRouteConfiguration<EmployeeDetailsPagePresenter> {
        public override string id {
            get { return Resources.page_id; }
        }

        public override string url {
            get { return "employee/{employee_id}"; }
        }

    }
}