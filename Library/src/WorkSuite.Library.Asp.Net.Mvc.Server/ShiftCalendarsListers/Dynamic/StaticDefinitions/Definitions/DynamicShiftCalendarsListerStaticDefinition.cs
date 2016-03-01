using System;
using System.Collections.Generic;
using WorkSuite.Library.Asp.Net.Mvc.Server.ShiftCalendars;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.ShiftCalendarsListers.Dynamic.StaticDefinitions.Definitions
{
    /// <summary>
    ///     Definitions for a Shift Calendars Lister that will be built from a model
    /// </summary>
    /// <typeparam name="S">
    ///     The type of the model that the Shift Calendars Lister definition is for
    /// </typeparam>
    public class DynamicShiftCalendarsListerStaticDefinition<S>
    {
        /// <summary>
        ///     Expression that will generate the Shift Calendars Lister title
        /// </summary>
        public Func<S, string> title { get; set; }

        /// <summary>
        ///     Expression that will generate classes that should be applied to Shift Calendars Lister.
        /// </summary>
        public ICollection<Func<S, string>> classes { get; set; }

        /// <summary>
        ///     Expression that will generate shift calendars that should be part of a Shift Calendar Lister
        /// </summary>
        public Func<S, IEnumerable<ShiftCalendar>> create_shift_calendars { get; set; }
    }
}