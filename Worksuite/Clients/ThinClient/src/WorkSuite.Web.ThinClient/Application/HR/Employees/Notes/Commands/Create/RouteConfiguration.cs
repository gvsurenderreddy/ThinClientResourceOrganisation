using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.Employees.Notes.Commands.Create
{
    public class RouteConfiguration : ARouteConfiguration<CreateNoteController>
    {
        public override string id
        {
            get { return Resources.id; }
        }

        public override string url
        {
            get { return "note/create"; }
        }

        public override string action
        {
            get { return "SubmitRequest"; }
        }
    }
}