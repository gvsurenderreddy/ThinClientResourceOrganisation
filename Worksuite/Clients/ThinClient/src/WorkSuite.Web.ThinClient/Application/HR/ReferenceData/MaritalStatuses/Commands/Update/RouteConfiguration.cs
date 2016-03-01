using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;
using WTS.WorkSuite.Web.ThinClient.Application.HR.ReferenceData.MaritalStatuses.Commands.Update;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.ReferenceData.MaritalStatuses.Commands.Update
{
    public class RouteConfiguration
                        :   ARouteConfiguration< UpdateMaritalStatusController >
    {
        public override string id
        {
            get { return MaritalStatuses.Commands.Update.Resources.id; }
        }

        public override string url
        {
            get { return "marital-statuses/{id}/update"; }
        }

        public override string action
        {
            get { return "SubmitRequest"; }
        }
    }
}