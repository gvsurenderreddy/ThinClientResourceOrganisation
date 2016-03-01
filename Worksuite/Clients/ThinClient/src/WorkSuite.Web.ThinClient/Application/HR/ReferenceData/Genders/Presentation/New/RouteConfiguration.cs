using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.ReferenceData.Genders.Presentation.New {


    public class RouteConfiguration
                    : ARouteConfiguration<NewGenderPresenter> {
        public override string id {
            get { return Resources.id; }
        }

        public override string url {
            get { return "genders/new"; }
        }

        public override string action {
            get { return "Editor"; }
        }

    }

}