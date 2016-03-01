using System;
using WTS.WorkSuite.Library.DomainTypes;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.DateRangePalettes.Dynamic.StaticDefinitions.Model
{
    public class DynamicDateRangePaletteStaticDefinition<S>
    {
        public Func<S, string> title { get; set; }
        public Func<S, DateTime> calendar_start_date { get; set; }
        public Func<S, DateTime> selected_start_date { get; set; }
        public Func<S, ShiftCalendarRange> selected_range { get; set; }
    }
}
