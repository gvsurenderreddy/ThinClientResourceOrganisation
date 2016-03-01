using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;

namespace WTS.WorkSuite.Web.ThinClient.Application.Operations.OperationalCalendars.View.Page
{
    public class RouteConfiguration
                        : APageRouteConfiguration< ViewOperationsCalendarsPresenter >
    {
        public override string id
        {
            get { return Resources.page_id; }
        }

        public override string url
        {
            get { return "operations-calendars/view"; }
        }
    }
}