using WTS.WorkSuite.Library.DomainTypes.Colour;

namespace WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence.Remove
{
    public class RemoveShiftOccurrenceRequest : ShiftOccurrenceIdentity
    {
        public string title { get; set; }

        public RgbColour colour { get; set; }

        public string start_date { get; set; }

        public string start_time { get; set; }

        public string duration { get; set; }
    }
}