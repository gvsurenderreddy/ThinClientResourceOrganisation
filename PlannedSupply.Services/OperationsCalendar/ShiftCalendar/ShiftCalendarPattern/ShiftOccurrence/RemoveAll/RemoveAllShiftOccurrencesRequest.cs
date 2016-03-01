using System.Collections.Generic;
using WTS.WorkSuite.Library.DomainTypes;
using WTS.WorkSuite.Library.DomainTypes.Colour;


namespace WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence.RemoveAll
{
    public class RemoveAllShiftOccurrencesRequest : ShiftOccurrenceIdentity
    {
        public string title { get; set; }

        public RgbColour colour { get; set; }

        public string start_date { get; set; }

        public string start_time { get; set; }

        public string duration { get; set; }

        public IEnumerable<ShiftCalendarOccurencesCountDetails> shift_calendar_affected { get; set; }
    }
}