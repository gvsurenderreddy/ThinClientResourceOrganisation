using System;
using WTS.WorkSuite.Library.DomainTypes.Colour;
using WTS.WorkSuite.Library.DomainTypes.Duration;
using WTS.WorkSuite.Library.DomainTypes.Time;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.TimeAllocationOccurrence;

namespace WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence.New
{
    public class NewShiftOccurrenceRequest : TimeBlockIdentity
    {
        public string shift_title { get; set; }
        public RGBColourRequest colour { get; set; }
        //We are overriding the start_date only because the order of the properties 
        //in the request type is what is used to order the fields in the editor.
        public new DateTime start_date { get; set; }
        public TimeRequest start_time { get; set; }
        public DurationRequest duration { get; set; }
    }
}