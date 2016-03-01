using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.Employees.Addresses.Presentation.List
{
    public class RouteConfiguration : ARouteConfiguration<AddressListPresenter>
    {
        public override string id
        {
            get { return Resources.route_name; }
        }

        public override string url
        {
            get { return "employee/{employee_id}/addresses"; }
        }

        public override string action
        {
            get { return "List"; }
        }
    }
}