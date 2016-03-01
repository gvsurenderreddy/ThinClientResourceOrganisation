using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.ReferenceData.Titles.Commands.Create {

    public class RouteConfiguration : ARouteConfiguration<CreateTitleController> {
        public override string id {
            get { return Resources.id ; }
        }

        public override string url {
            get { return "titles/create"; }
        }

        public override string action {
            get { return "SubmitRequest"; }
        }

    }

}