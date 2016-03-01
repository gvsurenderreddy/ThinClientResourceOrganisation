using System;
using System.Collections.Generic;
using WTS.WorkSuite.Library.DomainTypes;

namespace WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern
{
    /// <summary>
    ///     The full details of a shift calendar pattern.
    /// </summary>
    public class ShiftCalendarPatternDetails
                        : ShiftCalendarPatternIdentity, IShiftPattern
    {
        /// <summary>
        ///     Name of the shift calendar pattern
        /// </summary>
        public string shift_calendar_pattern_name { get; set; }

        /// <summary>
        ///     Number of resources required for the shift calendar pattern
        /// </summary>
        public int number_of_resources { get; set; }

        /// <summary>
        ///     Number of resources allocated to the shift calendar pattern
        /// </summary>
        public int resource_allocation_summary { get; set; }
        /// <summary>
        /// The time segements in this pattern
        /// Break, Work, Holiday etc
        /// </summary>
        public IEnumerable<ITimeAllocationOccurrence> time_allocation_occurrences { get; set; }


        /// <summary>
        /// The ordering priority of the item
        /// </summary>
        public int priority { get; set; }
    }
}