using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.Employees.ContactDetailsAndAddresses.Page
{
    public class RouteConfiguration
                    : APageRouteConfiguration<ContactDetailsAndAddressesPresenter>
    {
        public override string id
        {
            get { return Resources.page_id; }
        }

        public override string url
        {
            get { return "employee/{employee_id}/contact-details-and-addresses"; }
        }
    }
}