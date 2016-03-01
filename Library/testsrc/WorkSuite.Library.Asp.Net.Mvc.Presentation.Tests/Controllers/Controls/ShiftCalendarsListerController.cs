using System.Web.Mvc;
using WorkSuite.Library.Asp.Net.Mvc.Server.ShiftCalendarsListers;

namespace WorkSuite.Library.Asp.Net.Mvc.Presentation.Tests.Controllers.Controls
{
    public class ShiftCalendarsListerController
                        : Controller
    {
        public ActionResult Index()
        {
            var shift_calendars_lister = new ShiftCalendarsLister
            {
                title = "A Shift Calendars Lister Title",
                classes = new[] { "a_class", "another_class" },
                actions = new[] {
                    new ShiftCalendarsListerAction
                    {
                        title = "First action title",
                        name = "add-shift-calendar",
                        classes = new [] { "a_class", "another_class" },
                        url = "example url"
                    }
                },
            };

            return View(shift_calendars_lister);
        }
    }
}