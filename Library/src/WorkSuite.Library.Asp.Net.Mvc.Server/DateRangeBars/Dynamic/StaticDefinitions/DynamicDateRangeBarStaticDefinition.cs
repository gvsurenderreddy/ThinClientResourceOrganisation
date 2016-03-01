using System;
using WTS.WorkSuite.Library.DomainTypes;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.DateRangeBars.Dynamic.StaticDefinitions
{
    public class DynamicDateRangeBarStaticDefinition<S>
    {
        public Func<S, DateTime> start_date { get; set; }
        public Func<S, ShiftCalendarRange> selected_range { get; set; }
    }
}
