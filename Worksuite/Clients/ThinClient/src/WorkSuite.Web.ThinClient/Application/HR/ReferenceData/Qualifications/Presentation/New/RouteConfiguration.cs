using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.ReferenceData.Qualifications.Presentation.New
{
    public class RouteConfiguration
                        :   ARouteConfiguration< NewQualificationPresenter >
    {
        public override string id
        {
            get { return Resources.id; }
        }

        public override string url
        {
            get { return "qualification/new"; }
        }

        public override string action
        {
            get { return "Editor"; }
        }
    }
}