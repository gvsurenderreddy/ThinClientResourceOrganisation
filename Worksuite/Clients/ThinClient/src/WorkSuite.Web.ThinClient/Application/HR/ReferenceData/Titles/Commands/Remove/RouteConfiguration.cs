using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.ReferenceData.Titles.Commands.Remove {

    public class RouteConfiguration : ARouteConfiguration<RemoveTitleController> {
        public override string id {
            get { return Resources.id ; }
        }

        public override string url {
            get { return "title/{id}/remove"; }
        }

        public override string action {
            get { return "SubmitRequest"; }
        }

    }

}