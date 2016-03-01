using System;
using System.Collections.Generic;
using WTS.WorkSuite.Library.DomainTypes;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar;

namespace WTS.WorkSuite.PlannedSupply.OperationsCalendar.GetOverRange
{
    public class OperationsCalendarAggregateOverRange : OperationsCalendarDetails
    {
        public DateTime start_date { get; set; }

        public ShiftCalendarRange range_returned { get; set; }

        public IEnumerable<ShiftCalendarAggregateOverRange> all_shift_calendars_details { get; set; }
    }
}