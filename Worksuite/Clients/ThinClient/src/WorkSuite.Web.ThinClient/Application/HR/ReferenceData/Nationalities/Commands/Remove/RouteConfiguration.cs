using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.ReferenceData.Nationalities.Commands.Remove
{
    public class RouteConfiguration
                        : ARouteConfiguration< RemoveNationalityController >
    {
        public override string id
        {
            get { return Resources.id; }
        }

        public override string url
        {
            get { return "nationalities/{id}/remove"; }
        }

        public override string action
        {
            get { return "SubmitRequest"; }
        }
    }
}