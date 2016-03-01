using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.Employees.ContactDetails.Presentation.Editor 
{

    public class RouteConfiguration : ARouteConfiguration<ContactDetailsEditorPresenter> 
    {
        public override string id {
            get { return Resources.id; }
        }

        public override string url {
            get { return "employee/{employee_id}/contact-details-editor"; }
        }

        public override string action {
            get { return "Editor"; }
        }

    }

}