using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;

namespace WTS.WorkSuite.Web.ThinClient.Application.DocumentStore.Documents.Presentation
{
    public class RouteConfiguration : ARouteConfiguration<DocumentPresenter>
    {
        public override string id
        {
            get { return Resources.id; }
        }

        public override string url
        {
            get { return "document-store/document/{document_id}"; }
        }

        public override string action
        {
            get { return "Download"; }
        }
    }
}