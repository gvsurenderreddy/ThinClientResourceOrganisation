using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.Employees.Notes.Commands.Remove
{
    public class RouteConfiguration : ARouteConfiguration<RemoveNoteController>
    {
        public override string id
        {
            get { return Resources.route_name; }
        }

        public override string url
        {
            get { return "employee/{employee_id}/note/{note_id}/remove"; }
        }

        public override string action
        {
            get { return "SubmitRequest"; }
        }
    }
}