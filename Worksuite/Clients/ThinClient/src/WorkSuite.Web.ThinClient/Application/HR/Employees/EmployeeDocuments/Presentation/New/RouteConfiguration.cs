using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.Employees.EmployeeDocuments.Presentation.New
{
    public class RouteConfiguration : ARouteConfiguration<NewEmployeeDocumentPresenter>
    {
        public override string id
        {
            get { return Resources.id; }
        }

        public override string url
        {
            get { return "employee/{employee_id}/document/new"; }
        }

        public override string action
        {
            get { return "Editor"; }
        }
    }
}