using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.ReferenceData.MaritalStatuses.Presentation.Page
{

    public class RouteConfiguration
                        : APageRouteConfiguration<ConfigureMaritalStatusesPresenter>
    {
        public override string id
        {
            get { return Resources.page_id; }
        }

        public override string url
        {
            get { return "marital-statuses"; }
        }
    }
}