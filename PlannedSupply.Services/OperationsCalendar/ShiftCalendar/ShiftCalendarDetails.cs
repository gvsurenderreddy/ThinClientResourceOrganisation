using System;
using System.Collections.Generic;
using WTS.WorkSuite.Library.DomainTypes;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern;

namespace WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar
{
    public class ShiftCalendarDetails
                        : ShiftCalendarIdentity
    {
        /// <summary>
        /// Gets or sets the calendar name of shift calendar
        /// </summary>
        /// <value>
        /// The calendar name
        /// </value>
        public string calendar_name { get; set; }
    }

    public class ShiftCalendarAggregate
                        : ShiftCalendarDetails
    {

        /// <summary>
        ///     List of all shift calendar patterns that belong to a shift calendar.
        /// </summary>
        public IEnumerable<ShiftCalendarPatternDetails> shift_calendar_patterns { get; set; }
    }

    public class ShiftCalendarAggregateOverRange : ShiftCalendarAggregate
    {
        /// <summary>
        /// The start date from which the patterns have been returned from
        /// </summary>
        public DateTime patterns_start_date { get; set; }

        /// <summary>
        /// The range from which the patterns have been returned from
        /// </summary>
        public ShiftCalendarRange patterns_range_returned { get; set; }
    }
    
}