using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;

namespace WorkSuite.Confgiuration.Web.ThinClient.Application.Configuration.DatabaseSetting.Commands.update
{
    public class RouteConfiguration
                        :   ARouteConfiguration< UpdateDatabaseSettingController >
    {
        public override string id
        {
            get { return Resources.editor_id; }
        }

        public override string url
        {
            get { return "database_setting/update"; }
        }

        public override string action
        {
            get { return "SubmitRequest"; }
        }
    }
}