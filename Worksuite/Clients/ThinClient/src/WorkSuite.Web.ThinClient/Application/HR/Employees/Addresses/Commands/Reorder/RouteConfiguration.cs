using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.Employees.Addresses.Commands.Reorder
{
    public class RouteConfiguration : ARouteConfiguration<ReorderAddressController>
    {
        public override string id
        {
            get { return Resources.route_name; }
        }

        public override string url
        {
            get { return "employee/{employee_id}/address/{address_id}/reorder"; }
        }

        public override string action
        {
            get { return "SubmitRequest"; }
        }
    }
}