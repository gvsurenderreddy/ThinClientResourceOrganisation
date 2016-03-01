using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.ReferenceData.MaritalStatuses.Commands.Remove
{
    public class RouteConfiguration
                        :   ARouteConfiguration< RemoveMaritalStatusController >
    {
        public override string id
        {
            get { return MaritalStatuses.Commands.Remove.Resources.id; }
        }

        public override string url
        {
            get { return "marital-statuses/{id}/remove"; }
        }

        public override string action
        {
            get { return "SubmitRequest"; }
        }
    }
}