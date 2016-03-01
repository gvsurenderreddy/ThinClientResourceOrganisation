namespace WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.Events
{
    /// <summary>
    ///  Event that is published when a shift calendar pattern is created.
    /// </summary>
    public class ShiftCalendarPatternCreatedEvent
                        : ShiftCalendarPatternIdentity
    {
        public string name { get; set; }

        public int number_of_resources { get; set; }

        public int priority { get; set; }
    }
}