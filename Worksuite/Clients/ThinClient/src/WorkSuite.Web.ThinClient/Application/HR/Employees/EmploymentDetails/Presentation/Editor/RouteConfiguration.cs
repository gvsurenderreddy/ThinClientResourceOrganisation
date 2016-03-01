using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.Employees.EmploymentDetails.Presentation.Editor
{
    public class RouteConfiguration : ARouteConfiguration<EmploymentDetailsEditorPresenter>
    {
        public override string id
        {
            get { return Resources.id; }
        }

        public override string url
        {
            get { return "employee/{employee_id}/employment-details-editor"; }
        }

        public override string action
        {
            get { return "Editor"; }
        }
    }
}