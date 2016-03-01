using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.Employees.Addresses.Commands.Create
{
    public class RouteConfiguration : ARouteConfiguration<CreateAddressController>
    {
        public override string id
        {
            get { return Resources.id; }
        }

        public override string url
        {
            get { return "address/create"; }
        }

        public override string action
        {
            get { return "SubmitRequest"; }
        }
    }
}