using System.Web.Mvc;
using WorkSuite.Library.Asp.Net.Mvc.Server.DateRangeBars;

namespace WorkSuite.Library.Asp.Net.Mvc.Presentation.Tests.Controllers.Controls {

    public class DateRangeBarController : Controller {

        public ActionResult Index()
        {

            var model = new DateRangeBar()
            {
                date_range_string = "April 12 - 18 2014"
            };

            return View(model);
        }
    }
}
