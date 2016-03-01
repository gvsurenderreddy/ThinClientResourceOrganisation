using System;
using System.Collections.Generic;
using WTS.WorkSuite.Library.DomainTypes;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.ShiftCalendars.Dynamic.StaticDefinitions.Definitions
{
    /// <summary>
    ///     Definition for a Shift Calendar component that will be built from a model.
    /// </summary>
    /// <typeparam name="S">
    ///     The type of the model that the Shift Calendar definition is for.
    /// </typeparam>
    public class DynamicShiftCalendarStaticDefinition<S>
    {
        /// <summary>
        ///     Expression that will generates the title of the Shift Calendar.
        /// </summary>
        public Func<S, string> title { get; set; }

        /// <summary>
        ///     Expression that will generates classes that will be applied to Shift Calendar.
        /// </summary>
        public ICollection<Func<S, string>> classes { get; set; }

        /// <summary>
        /// Expression that exposes the start date from which the shift patterns are returned from
        /// </summary>
        public Func<S, DateTime> start_date { get; set; }

        /// <summary>
        /// Expression that exposes the number of days from which the shift patterns are returned for
        /// </summary>
        public Func<S, ShiftCalendarRange> number_of_days_range { get; set; }


        /// <summary>
        /// Expression that exposes the shift patterns from a model
        /// </summary>
        public Func<S, IEnumerable<IShiftPattern>> patterns { get; set; }
    }
}