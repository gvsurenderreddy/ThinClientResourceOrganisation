using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.Employees.Notes.Presentation.New
{
    public class RouteConfiguration : ARouteConfiguration<NewNotesPresenter>
    {
        public override string id
        {
            get { return Resources.id; }
        }

        public override string url
        {
            get { return "employee/{employee_id}/notes/new"; }
        }

        public override string action
        {
            get { return "Editor"; }
        }
    }
}