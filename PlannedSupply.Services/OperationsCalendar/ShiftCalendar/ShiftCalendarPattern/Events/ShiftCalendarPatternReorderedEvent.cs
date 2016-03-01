namespace WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.Events
{
    /// <summary>
    ///  Event that is published when a shift calendar pattern is reordered.
    ///     This is an abstract class that has all the common
    ///     properties for a shift calendar pattern reorder event.
    /// </summary>
    public class ShiftCalendarPatternReorderedEvent
                        : ShiftCalendarPatternIdentity
    {
        public string name { get; set; }

        public int number_of_resources { get; set; }

        public int priority { get; set; }
    }

    /// <summary>
    ///     This is a specific implementation for auto reorder event, derived from shift calendar pattern reordered event.
    /// </summary>
    public class ShiftCalendarPatternAutoReorderedEvent
                        : ShiftCalendarPatternReorderedEvent { }

    /// <summary>
    ///     This is a specific implementation for manual reorder event, derived from shift calendar pattern reordered event.
    /// </summary>
    public class ShiftCalendarPatternManualReorderedEvent
                        : ShiftCalendarPatternReorderedEvent { }
}