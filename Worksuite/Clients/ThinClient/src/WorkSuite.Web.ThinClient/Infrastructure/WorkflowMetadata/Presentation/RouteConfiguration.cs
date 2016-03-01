using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;

namespace WTS.WorkSuite.Web.ThinClient.Infrastructure.WorkflowMetadata.Presentation
{
    public class RouteConfiguration : ARouteConfiguration<WorkflowMetadataPresenter>
    {
        public override string id
        {
            get { return Resources.id; }
        }

        public override string url
        {
            get { return "workflow"; }
        }

        public override string action
        {
            get { return "Data"; }
        }
    }
}