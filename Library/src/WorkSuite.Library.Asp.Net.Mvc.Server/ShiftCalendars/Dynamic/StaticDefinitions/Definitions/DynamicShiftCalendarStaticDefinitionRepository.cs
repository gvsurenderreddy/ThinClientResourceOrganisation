using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using WorkSuite.Library.Asp.Net.Mvc.Server.ShiftCalendars.Dynamic.StaticDefinitions.Definitions.Actions;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.ShiftCalendars.Dynamic.StaticDefinitions.Definitions
{
    public class DynamicShiftCalendarStaticDefinitionRepository<S>
    {
        /// <summary>
        ///     Model definition for the Shift Calendar component.
        /// </summary>
        public DynamicShiftCalendarStaticDefinition<S> definition { get; set; }

        /// <summary>
        ///     Action definitions that are associated with the Shift Calendar component.
        /// </summary>
        public ICollection<DynamicShiftCalendarActionStaticDefinition<S>> actions { get; set; }

        public DynamicShiftCalendarStaticDefinitionRepository()
        {
            definition = new DynamicShiftCalendarStaticDefinition<S>
            {
                classes = new Collection<Func<S, string>>()
            };

            actions = new Collection<DynamicShiftCalendarActionStaticDefinition<S>>();
        }
    }
}