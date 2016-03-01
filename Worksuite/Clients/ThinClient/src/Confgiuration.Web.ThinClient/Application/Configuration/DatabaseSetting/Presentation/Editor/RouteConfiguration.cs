using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;

namespace WorkSuite.Confgiuration.Web.ThinClient.Application.Configuration.DatabaseSetting.Presentation.Editor
{

    public class RouteConfiguration
                : ARouteConfiguration<DatabaseSettingEditorPresenter>
    {
        public override string id
        {
            get { return Resources.id; }
        }

        public override string url
        {
            get { return "database_setting/editor"; }
        }

        public override string action
        {
            get { return "Editor"; }
        }
    }

}