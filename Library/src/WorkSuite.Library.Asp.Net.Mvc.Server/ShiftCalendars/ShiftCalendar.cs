using System.Collections.Generic;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels;
using WorkSuite.Library.Asp.Net.Mvc.Server.ShiftPatterns;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.ShiftCalendars
{
    /// <summary>
    ///     View model for the Shift Calendar component.
    /// </summary>
    public class ShiftCalendar
                        : IsAViewElement
    {
        /// <summary>
        ///     Title of the Shift Calendar.
        /// </summary>
        public string title { get; set; }

        /// <summary>
        ///     Classes that should be applied to Shift Calendar.
        /// </summary>
        public IEnumerable<string> classes { get; set; }

        /// <summary>
        ///     Actions that can be applied to Shift Calendar.
        /// </summary>
        public IEnumerable<ShiftCalendarAction> actions { get; set; }


        public ShiftPatternGrid shift_pattern_grid { get; set; }
    }
}