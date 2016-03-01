using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.ReferenceData.MaritalStatuses.Commands.Create
{
    public class RouteConfiguration
                        :   ARouteConfiguration<CreateMaritalStatusController>
    {
        public override string id
        {
            get { return MaritalStatuses.Commands.Create.Resources.id; }
        }

        public override string url
        {
            get { return "marital-statuses/create"; }
        }

        public override string action
        {
            get { return "SubmitRequest"; }
        }
    }
}