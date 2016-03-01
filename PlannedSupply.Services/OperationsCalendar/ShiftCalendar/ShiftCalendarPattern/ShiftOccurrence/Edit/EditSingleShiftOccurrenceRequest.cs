
using WTS.WorkSuite.Library.DomainTypes.Colour;
using WTS.WorkSuite.Library.DomainTypes.Duration;
using WTS.WorkSuite.Library.DomainTypes.Time;

namespace WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence.Edit
{
    public class EditSingleShiftOccurrenceRequest : ShiftOccurrenceIdentity
    {
        public string shift_title { get; set; }
        public RGBColourRequest colour { get; set; }
        public TimeRequest start_time { get; set; }
        public DurationRequest duration { get; set; }
        public string start_date { get; set; }
    }
}