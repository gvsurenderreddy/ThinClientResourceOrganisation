using System.Web.Mvc;
using WorkSuite.Library.Asp.Net.Mvc.Presentation.Tests.Helpers.Controls;

namespace WorkSuite.Library.Asp.Net.Mvc.Presentation.Tests.Controllers.Controls {

    public class BreadCrumbNavigationController 
                    : Controller {

        public ActionResult Index() {

            return View( BreadCrumbNavigationHelper.create_bread_crumb_navigation() );
        }
    }
}
