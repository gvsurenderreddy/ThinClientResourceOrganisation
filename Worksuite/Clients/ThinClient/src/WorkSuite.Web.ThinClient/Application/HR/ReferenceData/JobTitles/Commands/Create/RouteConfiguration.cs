using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.ReferenceData.JobTitles.Commands.Create
{
    public class RouteConfiguration
                    : ARouteConfiguration<CreateJobTitleController>
    {
        public override string id
        {
            get { return Resources.id; }
        }

        public override string url
        {
            get { return "job-titles/create"; }
        }

        public override string action
        {
            get { return "SubmitRequest"; }
        }
    }
}