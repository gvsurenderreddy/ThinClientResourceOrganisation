using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;
using WTS.WorkSuite.Web.ThinClient.Application.HR.Employees.addNewEmployee.page;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.Employees.addNewEmployee.get
{

    public class RouteConfiguration
                    : APageRouteConfiguration<AddNewEmployeePagePresenter> {
        public override string id {
            get { return Resources.page_id; }
        }
                
        public override string url {
            get { return "employees/new"; }
        }
    }
}