using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.ReferenceData.Qualifications.Commands.Create
{
    public class RouteConfiguration
                        : ARouteConfiguration< CreateQualificationController >
    {
        public override string id
        {
            get { return Resources.id; }
        }

        public override string url
        {
            get { return "qualification/create"; }
        }

        public override string action
        {
            get { return "SubmitRequest"; }
        }
    }
}