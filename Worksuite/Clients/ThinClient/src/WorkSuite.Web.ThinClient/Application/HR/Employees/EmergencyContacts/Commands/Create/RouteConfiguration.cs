using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.Employees.EmergencyContacts.Commands.Create
{
    public class RouteConfiguration : ARouteConfiguration<CreateEmergencyContactController>
    {
        public override string id
        {
            get { return Resources.id; }
        }

        public override string url
        {
            get { return "emergency-contact/create"; }
        }

        public override string action
        {
            get { return "SubmitRequest"; }
        }
    }
}