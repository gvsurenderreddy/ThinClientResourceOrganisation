using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.Employees.EmergencyContacts.Commands.Remove
{
    public class RouteConfiguration : ARouteConfiguration<RemoveEmergencyContactController>
    {
        public override string id
        {
            get { return EmergencyContacts.Commands.Remove.Resources.route_name; }
        }

        public override string url
        {
            get { return "employee/{employee_id}/emergency-contact/{emergency_contact_id}/remove"; }
        }

        public override string action
        {
            get { return "SubmitRequest"; }
        }
    }
}