using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.Employees.EmergencyContacts.Presentation.Editor
{
    public class RouteConfiguration : ARouteConfiguration<EmergencyContactEditorPresenter>
    {
        public override string id
        {
            get { return Resources.id; }
        }

        public override string url
        {
            get { return "employee/{employee_id}/emergency-contact/{emergency_contact_id}/emergency-contact-details-editor"; }
        }

        public override string action
        {
            get { return "Editor"; }
        }
    }
}