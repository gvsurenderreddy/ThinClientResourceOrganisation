using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.Employees.viewEmployees.get {

    public class RouteConfiguration 
                  : APageRouteConfiguration<ViewEmployeesPagePresenter> {

        public override string id {
            get { return Resources.page_id; }
        }
                
        public override string url {
            get { return "employees/view-employees"; }
        }
    }
}