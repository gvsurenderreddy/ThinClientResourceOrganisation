using WTS.WorkSuite.Web.ThinClient.Application.HR.ReferenceData.Titles.Commands.Update;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.ReferenceData.Genders.Commands.Update {

    public class RouteConfiguration
                    : ARouteConfiguration<UpdateGenderController> {
        public override string id {
            get { return Resources.id; }
        }

        public override string url {
            get { return "genders/{id}/update"; }
        }

        public override string action {
            get { return "SubmitRequest"; }
        }
    }
}