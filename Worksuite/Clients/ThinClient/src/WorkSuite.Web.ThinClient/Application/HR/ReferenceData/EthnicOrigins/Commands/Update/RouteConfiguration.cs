using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.ReferenceData.EthnicOrigins.Commands.Update
{
    public class RouteConfiguration
                        : ARouteConfiguration< UpdateEthnicOriginController >
    {
        public override string id
        {
            get { return Resources.id; }
        }

        public override string url
        {
            get { return "ethnic-origins/{id}/update"; }
        }

        public override string action
        {
            get { return "SubmitRequest"; }
        }
    }
}