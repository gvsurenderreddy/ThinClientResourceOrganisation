using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.Employees.EmergencyContacts.Commands.Update
{
    public class RouteConfiguration  : ARouteConfiguration<UpdateEmergencyContactController>
    {
        public override string id
        {
            get { return Resources.id; }
        }

        public override string url
        {
            get { return "employee/{employee_id}/emergency-contact/{emergency_contact_id}/update-emergency-contact-details"; }
        }

        public override string action
        {
            get { return "SubmitRequest"; }
        }
    }
}