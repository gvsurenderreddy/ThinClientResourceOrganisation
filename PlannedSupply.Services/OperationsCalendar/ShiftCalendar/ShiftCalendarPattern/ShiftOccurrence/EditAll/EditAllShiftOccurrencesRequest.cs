using System.Collections.Generic;
using WTS.WorkSuite.Library.DomainTypes;
using WTS.WorkSuite.Library.DomainTypes.Colour;
using WTS.WorkSuite.Library.DomainTypes.Duration;
using WTS.WorkSuite.Library.DomainTypes.Time;

namespace WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence.EditAll
{
    public class EditAllShiftOccurrencesRequest : ShiftOccurrenceIdentity
    {
        public string shift_title { get; set; }
        public RGBColourRequest colour { get; set; }
        public TimeRequest start_time { get; set; }
        public DurationRequest duration { get; set; }
        public IEnumerable<ShiftCalendarOccurencesCountDetails> affected_shift_calendars { get; set; }
    }
}