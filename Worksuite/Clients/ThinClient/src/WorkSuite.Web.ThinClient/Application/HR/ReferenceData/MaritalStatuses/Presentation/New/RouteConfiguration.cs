using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.ReferenceData.MaritalStatuses.Presentation.New
{
    public class RouteConfiguration
                        :   ARouteConfiguration<NewMaritalStatusPresenter>
    {
        public override string id
        {
            get { return MaritalStatuses.Presentation.New.Resources.id; }
        }

        public override string url
        {
            get { return "marital-statuses/new"; }
        }

        public override string action
        {
            get { return "Editor"; }
        }
    }
}