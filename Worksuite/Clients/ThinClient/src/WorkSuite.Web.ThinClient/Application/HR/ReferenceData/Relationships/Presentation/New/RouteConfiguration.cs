using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.ReferenceData.Relationships.Presentation.New
{
    public class RouteConfiguration
                    : ARouteConfiguration<NewRelationshipPresenter>
    {
        public override string id
        {
            get { return Resources.id; }
        }

        public override string url
        {
            get { return "relationships/new"; }
        }

        public override string action
        {
            get { return "Editor"; }
        }

    }
}