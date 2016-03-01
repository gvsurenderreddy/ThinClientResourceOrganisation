using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.Employees.Addresses.Presentation.New
{
    public class RouteConfiguration : ARouteConfiguration<NewAddressPresenter>
    {
        public override string id
        {
            get { return Resources.id; }
        }

        public override string url
        {
            get { return "employee/{employee_id}/address/new"; }
        }

        public override string action
        {
            get { return "Editor"; }
        }
    }
}