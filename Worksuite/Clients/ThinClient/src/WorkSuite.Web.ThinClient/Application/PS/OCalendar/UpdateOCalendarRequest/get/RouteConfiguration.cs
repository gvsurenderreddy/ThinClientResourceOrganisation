using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;

namespace WTS.WorkSuite.Web.ThinClient.Application.Operations.OperationalCalendars.Edit.Presentation.Editor
{
    public class RouteConfiguration
                        : ARouteConfiguration< OperationsCalendarDetailsEditorPresenter >
    {
        public override string id
        {
            get { return Resources.id; }
        }

        public override string url
        {
            get { return "operations-calendar/{operations_calendar_id}/operations-calendar-details-editor"; }
        }

        public override string action
        {
            get { return "Editor"; }
        }
    }
}