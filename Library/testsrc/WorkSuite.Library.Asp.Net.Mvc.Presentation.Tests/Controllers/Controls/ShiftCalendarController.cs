using System.Web.Mvc;
using WorkSuite.Library.Asp.Net.Mvc.Presentation.Tests.Helpers.Controls;
using WorkSuite.Library.Asp.Net.Mvc.Server.ShiftCalendars;

namespace WorkSuite.Library.Asp.Net.Mvc.Presentation.Tests.Controllers.Controls
{
    public class ShiftCalendarController
                        : Controller
    {
        public ActionResult Index()
        {
            var shift_calendar = new ShiftCalendar
            {
                title = "A Shift Calendar title",
                classes = new[] { "a_class", "another_class" },
                actions = new[]
                {
                    new ShiftCalendarAction
                    {
                        title = "First Action title",
                        name = "edit-shift-calendar",
                        classes = new[] {"a_class", "another_class"},
                        url = "first action url"
                    },
                    new ShiftCalendarAction
                    {
                        title = "Second Action title",
                        name = "remove-shift-calendar",
                        classes = new[] {"a_class", "another_class"},
                        url = "second action url"
                    }
                },
                shift_pattern_grid = ShiftPatternGridHelper.create_shift_pattern_grid()
            };

            return View(shift_calendar);
        }
    }
}