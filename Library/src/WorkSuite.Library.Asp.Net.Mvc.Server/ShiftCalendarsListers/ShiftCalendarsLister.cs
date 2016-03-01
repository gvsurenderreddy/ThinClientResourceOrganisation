using System.Collections.Generic;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels;
using WorkSuite.Library.Asp.Net.Mvc.Server.ShiftCalendars;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.ShiftCalendarsListers
{
    /// <summary>
    ///     View model for the Shift Calendars Lister component.
    /// </summary>
    public class ShiftCalendarsLister
                        : IsAViewElement
    {
        /// <summary>
        ///     Title of the Shift Calendars Lister.
        /// </summary>
        public string title { get; set; }

        /// <summary>
        ///     Classes that should be applied to Shift Calendars Lister.
        /// </summary>
        public IEnumerable<string> classes { get; set; }

        /// <summary>
        ///     Actions that can be applied to Shift Calendars Lister.
        /// </summary>
        public IEnumerable<ShiftCalendarsListerAction> actions { get; set; }

        /// <summary>
        ///     Shift Calendars that are part of the Shift Calendar Lister.
        /// </summary>
        public IEnumerable<ShiftCalendar> all_shift_calendars { get; set; }
    }
}