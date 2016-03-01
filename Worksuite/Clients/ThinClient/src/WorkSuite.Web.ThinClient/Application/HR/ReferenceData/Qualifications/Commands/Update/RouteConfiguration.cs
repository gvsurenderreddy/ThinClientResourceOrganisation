using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.ReferenceData.Qualifications.Commands.Update
{
    public class RouteConfiguration
                        : ARouteConfiguration< UpdateQualificationController >
    {
        public override string id
        {
            get { return Resources.id; }
        }

        public override string url
        {
            get { return "qualifications/{id}/update"; }
        }

        public override string action
        {
            get { return "SubmitRequest"; }
        }
    }
}