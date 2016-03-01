using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;
using WTS.WorkSuite.Web.ThinClient.Application.HR.employee.Notes.notes.page;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.employee.Notes.notes.get
{
    public class RouteConfiguration : APageRouteConfiguration<NotesPagePresenter>
    {
        public override string id
        {
            get { return Resources.page_id; }
        }

        public override string url
        {
            get { return "employee/{employee_id}/notes"; }
        }
    }
}