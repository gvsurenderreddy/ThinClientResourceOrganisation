using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.Employees.EmergencyContacts.Presentation.New
{
    public class RouteConfiguration : ARouteConfiguration<NewEmergencyContactPresenter>
    {
        public override string id
        {
            get { return EmergencyContacts.Presentation.New.Resources.id; }
        }

        public override string url
        {
            get { return "employee/{employee_id}/emergency-contact/new"; }
        }

        public override string action
        {
            get { return "Editor"; }
        }
    }
}