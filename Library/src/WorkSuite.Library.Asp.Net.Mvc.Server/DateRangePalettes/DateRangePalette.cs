using System;
using System.Collections.Generic;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels;
using WTS.WorkSuite.Library.DomainTypes;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.DateRangePalettes
{
    public class DateRangePalette : IsAViewElement
    {
        public string title { get; set; }

        public DateRangeCalendar calendar { get; set; }

        public ShiftCalendarRange selected_range { get; set; }

        public IEnumerable<DateRangePaletteAction> actions { get; set; }
    }

    public class DateRangeCalendar
    {
        public DateTime selected_start_date { get; set; }

        public DateTime calendar_start_date { get; set; }

        public IEnumerable<string> week_days { get; set; }

        public IEnumerable<IEnumerable<CalendarDate>> dates { get; set; }

    }


    public class CalendarDate
    {
        public DateTime date { get; set; }

        public bool is_selected { get; set; }

        public bool is_in_selected_month { get; set; }

    }
}
