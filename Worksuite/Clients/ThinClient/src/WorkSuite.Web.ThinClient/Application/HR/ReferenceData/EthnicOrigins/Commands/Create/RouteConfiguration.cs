using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.ReferenceData.EthnicOrigins.Commands.Create
{
    public class RouteConfiguration
                        : ARouteConfiguration< CreateEthnicOriginController >
    {
        public override string id
        {
            get { return Resources.id; ; }
        }

        public override string url
        {
            get { return "ethnic-origins/create"; }
        }

        public override string action
        {
            get { return "SubmitRequest"; }
        }
    }
}