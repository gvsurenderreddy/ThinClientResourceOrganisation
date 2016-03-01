using System;
using System.Collections.Generic;
using System.Web.Mvc;
using WorkSuite.Library.Asp.Net.Mvc.Server.DateRangePalettes;

namespace WorkSuite.Library.Asp.Net.Mvc.Presentation.Tests.Controllers.Controls
{

    public class DateRangePaletteController : Controller
    {

        public ActionResult Index()
        {
            var the_day = new DateTime(2014, 9, 1);

            var model = new DateRangePalette()
            {
                title = "Date Range",
                calendar = get_calendar(the_day)

            };
            return View(model);
        }

        private DateRangeCalendar get_calendar(DateTime selected_date)
        {
            return new DateRangeCalendar()
            {
                calendar_start_date = selected_date,
                week_days = new List<string>()
                {
                    "M", "T", "W", "T", "F", "S", "S"
                },
                dates = new List<IEnumerable<CalendarDate>>()
                {
                    new List<CalendarDate>()
                    {
                        build_date(selected_date, true, true), //is in month and selected
                        build_date(selected_date.AddDays(1), true, true), //|
                        build_date(selected_date.AddDays(2), true, true), //|
                        build_date(selected_date.AddDays(3), true, true), //|
                        build_date(selected_date.AddDays(4), true, true), //|
                        build_date(selected_date.AddDays(5), true, true), //|
                        build_date(selected_date.AddDays(6), true, true)//ends here
                    },
                    new List<CalendarDate>()
                    {
                        build_date(selected_date.AddDays(7), true, false), //is in month and not selected
                        build_date(selected_date.AddDays(8), true, false), //|
                        build_date(selected_date.AddDays(9), true, false), //|
                        build_date(selected_date.AddDays(11), true, false),//|
                        build_date(selected_date.AddDays(12), true, false),//|
                        build_date(selected_date.AddDays(13), true, false),//|
                        build_date(selected_date.AddDays(14), true, false),//|
                    },                                                     
                    new List<CalendarDate>()
                    {
                        build_date(selected_date.AddDays(15), true, false), //|
                        build_date(selected_date.AddDays(16), true, false), //|
                        build_date(selected_date.AddDays(17), true, false), //|
                        build_date(selected_date.AddDays(18), true, false), //|
                        build_date(selected_date.AddDays(19), true, false), //|
                        build_date(selected_date.AddDays(20), true, false), //|
                        build_date(selected_date.AddDays(21), true, false), //|
                    },
                    new List<CalendarDate>()
                    {
                        build_date(selected_date.AddDays(22), true, false), //|
                        build_date(selected_date.AddDays(23), true, false), //|
                        build_date(selected_date.AddDays(24), true, false), //|
                        build_date(selected_date.AddDays(25), true, false), //|
                        build_date(selected_date.AddDays(26), true, false), //|
                        build_date(selected_date.AddDays(27), true, false), //|
                        build_date(selected_date.AddDays(28), true, false), //|
                    },
                    new List<CalendarDate>()
                    {
                        build_date(selected_date.AddDays(29), true, false), 
                        build_date(selected_date.AddDays(30), true, false), //ends here
                        build_date(selected_date.AddDays(31), false, false), //is not in month and not selected
                        build_date(selected_date.AddDays(32), false, false), //|
                        build_date(selected_date.AddDays(33), false, false), //|
                        build_date(selected_date.AddDays(34), false, false), //|
                        build_date(selected_date.AddDays(35), false, false), //|
                    },
                },
                selected_start_date = selected_date
            };
        }

        private CalendarDate build_date(DateTime selected_date, bool is_in_month, bool is_selected)
        {
            return new CalendarDate()
            {
                date = selected_date,
                is_in_selected_month = is_in_month,
                is_selected = is_selected
            };
        }
    }
}
