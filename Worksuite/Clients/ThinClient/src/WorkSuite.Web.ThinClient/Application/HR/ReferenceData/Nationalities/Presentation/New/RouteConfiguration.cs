using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.ReferenceData.Nationalities.Presentation.New
{
    public class RouteConfiguration
                        : ARouteConfiguration< NewNationalityPresenter >
    {
        public override string id
        {
            get { return Resources.id; }
        }

        public override string url
        {
            get { return "nationalities/new"; }
        }

        public override string action
        {
            get { return "Editor"; }
        }
    }
}