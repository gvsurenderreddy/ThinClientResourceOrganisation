using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.ReferenceData.Qualifications.Presentation.Page
{


    public class RouteConfiguration
                    :   APageRouteConfiguration< ConfigureQualificationsController > {
        public override string id
        {
            get { return Resources.page_id; }
        }

        public override string url
        {
            get { return "qualification"; }
        }

    }
}