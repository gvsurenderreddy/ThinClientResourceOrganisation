using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.Employees.PersonalDetails.Presentation.Editor {

    public class RouteConfiguration : ARouteConfiguration<PersonalDetailsEditorPresenter> {
        public override string id {
            get { return Resources.id; }
        }

        public override string url {
            get { return "employee/{employee_id}/personal-details-editor"; }
        }

        public override string action {
            get { return "Editor"; }
        }

    }

}