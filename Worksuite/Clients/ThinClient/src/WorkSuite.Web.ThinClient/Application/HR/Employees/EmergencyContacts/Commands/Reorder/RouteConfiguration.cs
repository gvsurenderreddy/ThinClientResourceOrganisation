using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.Employees.EmergencyContacts.Commands.Reorder
{
    public class RouteConfiguration
                        : ARouteConfiguration< ReorderEmergencyContactController >
    {
        public override string id
        {
            get { return Resources.route_name; }
        }

        public override string url
        {
            get { return "employee/{employee_id}/emergency-contact/{emergency_contact_id}/reorder"; }
        }

        public override string action
        {
            get { return "SubmitRequest"; }
        }
    }
}