using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.Employees.Addresses.Commands.Update
{
    public class RouteConfiguration  : ARouteConfiguration<UpdateAddressController>
    {
        public override string id
        {
            get { return Resources.id; }
        }

        public override string url
        {
            get { return "employee/{employee_id}/address/{address_id}/update-title-details"; }
        }

        public override string action
        {
            get { return "SubmitRequest"; }
        }
    }
}