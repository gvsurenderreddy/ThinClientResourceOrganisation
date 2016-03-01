using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.Employees.EmployeeImage.Presentation.New
{
    public class RouteConfiguration : ARouteConfiguration<NewEmployeeImagePresenter>
    {
        protected override string id
        {
            get { return Resources.id; }
        }

        public override string url
        {
            get { return "employee/{employee_id}/image/new"; }
        }

        protected override string action
        {
            get { return "Editor"; }
        }
    }
}