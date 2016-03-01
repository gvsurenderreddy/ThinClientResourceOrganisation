using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.ReferenceData.Qualifications.Commands.Remove
{
    public class RouteConfiguration
                        : ARouteConfiguration< RemoveQualificationController >
    {
        public override string id
        {
            get { return Resources.id; }
        }

        public override string url
        {
            get { return "qualifications/{id}/remove"; }
        }

        public override string action
        {
            get { return "SubmitRequest"; }
        }
    }
}