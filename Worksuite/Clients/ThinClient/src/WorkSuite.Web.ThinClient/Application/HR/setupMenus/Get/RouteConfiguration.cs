using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.setupMenus.Get {

    public class RouteConfiguration 
                    : APageRouteConfiguration<SetupMenusPagePresenter> {

        public override string id {
            get { return Resources.page_id; }
        }

        public override string url {
            get { return "setup-menus"; }
        }
    }
}