using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.Employees.EmployeeImage.Presentation.Editor
{
    public class RouteConfiguration : ARouteConfiguration<EmployeeImageEditorPresenter>
    {
        public override string id
        {
            get { return Resources.id; }
        }

        public override string url
        {
            get { return "employee/{employee_id}/image-details-editor"; }
        }

        public override string action
        {
            get { return "Editor"; }
        }
    }
}