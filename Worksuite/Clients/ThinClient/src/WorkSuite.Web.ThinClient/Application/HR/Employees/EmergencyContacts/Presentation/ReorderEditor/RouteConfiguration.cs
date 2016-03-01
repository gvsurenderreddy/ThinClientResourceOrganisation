using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.Employees.EmergencyContacts.Presentation.ReorderEditor
{
    public class RouteConfiguration
                        : ARouteConfiguration< ReorderEmergencyContactEditorPresenter >
    {
        public override string id
        {
            get { return Resources.id; }
        }

        public override string url
        {
            get { return "employee/{employee_id}/emergency-contact/{emergency_contact_id}/emergency-contact-reorder-editor"; }
        }

        public override string action
        {
            get { return "Editor"; }
        }
    }
}