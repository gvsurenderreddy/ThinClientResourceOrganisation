using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using WorkSuite.Library.Asp.Net.Mvc.Server.ShiftCalendars;
using WorkSuite.Library.Asp.Net.Mvc.Server.ShiftCalendars.Dynamic.StaticDefinitions.Definitions;
using WorkSuite.Library.Asp.Net.Mvc.Server.ShiftCalendarsListers.Dynamic.StaticDefinitions.Definitions.Actions;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.ShiftCalendarsListers.Dynamic.StaticDefinitions.Definitions
{
    public class DynamicShiftCalendarsListerStaticDefinitionRepository<S>
    {
        /// <summary>
        ///     Model defintion for the Shift Calendars Lister
        /// </summary>
        public DynamicShiftCalendarsListerStaticDefinition<S> definition { get; set; }

        /// <summary>
        ///     Action definitions that are associated with the Shift Calendars Lister
        /// </summary>
        public ICollection<DynamicShiftCalendarsListerActionStaticDefinition<S>> actions { get; set; }

        /// <summary>
        ///     Shift Calendar defintions that are part of the Shift Calendar Lister;
        /// </summary>
        public ICollection<DynamicShiftCalendarStaticDefinition<S>> all_shift_calendars { get; set; }

        public DynamicShiftCalendarsListerStaticDefinitionRepository()
        {
            definition = new DynamicShiftCalendarsListerStaticDefinition<S>
            {
                classes = new Collection<Func<S, string>>(),
                create_shift_calendars = new Func<S, IEnumerable<ShiftCalendar>>(sc =>
                {
                    return new List<ShiftCalendar>();
                })
            };

            actions = new Collection<DynamicShiftCalendarsListerActionStaticDefinition<S>>();

            all_shift_calendars = new Collection<DynamicShiftCalendarStaticDefinition<S>>();
        }
    }
}