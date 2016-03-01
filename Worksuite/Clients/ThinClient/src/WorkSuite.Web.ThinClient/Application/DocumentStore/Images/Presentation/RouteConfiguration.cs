using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;

namespace WTS.WorkSuite.Web.ThinClient.Application.DocumentStore.Images.Presentation
{
    public class RouteConfiguration : ARouteConfiguration<ImagePresenter>
    {
        public override string id
        {
            get { return Resources.id; }
        }

        public override string url
        {
            get { return "document-store/image/{document_id}"; }
        }

        public override string action
        {
            get { return "Image"; }
        }
    }
}