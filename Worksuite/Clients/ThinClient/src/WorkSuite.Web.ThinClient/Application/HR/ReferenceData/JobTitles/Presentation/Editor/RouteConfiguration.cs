using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.ReferenceData.JobTitles.Presentation.Editor
{
    public class RouteConfiguration
                    : ARouteConfiguration<JobTitleEditorPresenter>
    {
        public override string id
        {
            get { return Resources.id; }
        }

        public override string url
        {
            get { return "job-title/editor"; }
        }

        public override string action
        {
            get { return "Editor"; }
        }
    }
}