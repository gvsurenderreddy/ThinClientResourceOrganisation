using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.Employees.Notes.Presentation.Editor
{
    public class RouteConfiguration : ARouteConfiguration<NoteEditorPresenter>
    {
        public override string id
        {
            get { return Resources.id; }
        }

        public override string url
        {
            get { return "employee/{employee_id}/note/{note_id}/note-details-editor"; }
        }

        public override string action
        {
            get { return "Editor"; }
        }
    }
}