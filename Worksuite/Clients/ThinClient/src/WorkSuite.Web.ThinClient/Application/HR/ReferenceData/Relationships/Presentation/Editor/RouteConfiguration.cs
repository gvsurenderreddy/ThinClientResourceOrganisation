using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.ReferenceData.Relationships.Presentation.Editor {

    public class RouteConfiguration
                    : ARouteConfiguration<RelationshipEditorPresenter> {
        public override string id {
            get { return Resources.id; }
        }

        public override string url {
            get { return "relationships/{id}/editor"; }
        }

        public override string action {
            get { return "Editor"; }
        } 
    }
}