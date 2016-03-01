using System.Web.Mvc;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.Employees.Addresses.Commands.Remove
{
    public class RouteConfiguration : ARouteConfiguration<RemoveAddressController>
    {
        public override string id
        {
            get { return Resources.route_name; }
        }

        public override string url
        {
            get { return "employee/{employee_id}/address/{address_id}/remove"; }
        }

        public override string action
        {
            get { return "SubmitRequest"; }
        }
    }
}