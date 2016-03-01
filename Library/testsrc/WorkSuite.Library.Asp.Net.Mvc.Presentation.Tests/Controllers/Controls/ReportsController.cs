using System.Web.Mvc;
using WorkSuite.Library.Asp.Net.Mvc.Presentation.Tests.Helpers.Controls;

namespace WorkSuite.Library.Asp.Net.Mvc.Presentation.Tests.Controllers.Controls {

    public class ReportsController : Controller {

        public ActionResult Index() {

            return View( ReportHelper.create_a_report() );
        }

    }
}
