using WTS.WorkSuite.Library.DomainTypes.Colour;

namespace WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence.GetSingleDetails
{
    public class SingleOccurrenceDetails : ShiftOccurrenceIdentity
    {

        public string shift_title { get; set; }

        public RgbColour colour { get; set; }

        public string start_time { get; set; }

        public string duration { get; set; }

        public string start_date { get; set; }
    }
}
