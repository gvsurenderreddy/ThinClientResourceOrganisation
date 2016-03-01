using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.Employees.Notes.Commands.Update
{
    public class RouteConfiguration : ARouteConfiguration<UpdateNoteController>
    {
        public override string id
        {
            get { return Resources.id; }
        }

        public override string url
        {
            get { return "employee/{employee_id}/note/{note_id}/update-note-details"; }
        }

        public override string action
        {
            get { return "SubmitRequest"; }
        }
    }
}