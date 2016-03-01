
using System.Collections.Generic;
using WTS.WorkSuite.Library.DomainTypes;
using WTS.WorkSuite.Library.DomainTypes.Colour;

namespace WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence.GetAllDetails
{
    public class AllOccurrencesDetails : ShiftOccurrenceIdentity
    {
        public string shift_title { get; set; }

        public RgbColour colour { get; set; }

        public string start_time { get; set; }

        public string duration { get; set; }

        public IEnumerable<ShiftCalendarOccurencesCountDetails> affected_shift_calendars { get; set; }
    }
}
