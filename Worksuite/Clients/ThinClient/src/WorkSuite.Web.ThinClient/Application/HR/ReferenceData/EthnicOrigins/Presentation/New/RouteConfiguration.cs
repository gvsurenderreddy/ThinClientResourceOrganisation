using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.ReferenceData.EthnicOrigins.Presentation.New
{
    public class RouteConfiguration
                        : ARouteConfiguration< NewEthnicOriginPresenter >
    {
        public override string id
        {
            get { return Resources.id; }
        }

        public override string url
        {
            get { return "ethnic-origins/new"; }
        }

        public override string action
        {
            get { return "Editor"; }
        }
    }
}