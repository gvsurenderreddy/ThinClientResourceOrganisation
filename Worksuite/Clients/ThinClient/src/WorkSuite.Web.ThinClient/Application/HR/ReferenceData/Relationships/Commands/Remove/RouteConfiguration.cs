using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.ReferenceData.Relationships.Commands.Remove {

    public class RouteConfiguration
                    : ARouteConfiguration<RemoveRelationshipController> {
        public override string id {
            get { return Resources.id ; }
        }

        public override string url {
            get { return "relationships/{id}/remove"; }
        }

        public override string action {
            get { return "SubmitRequest"; }
        }

    }

}