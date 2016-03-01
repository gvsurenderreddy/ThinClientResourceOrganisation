using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.ReferenceData.JobTitles.Presentation.New
{
    public class RouteConfiguration
                    : ARouteConfiguration<NewJobTitlePresenter>
    {
        public override string id
        {
            get { return Resources.id; }
        }

        public override string url
        {
            get { return "job-titles/new"; }
        }

        public override string action
        {
            get { return "Editor"; }
        }
    }
}