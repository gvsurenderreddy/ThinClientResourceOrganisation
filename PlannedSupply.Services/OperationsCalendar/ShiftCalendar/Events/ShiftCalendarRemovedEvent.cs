namespace WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.Events
{
    /// <summary>
    ///  Event that is published when a shift calendar is deleted.
    /// </summary>
    public class ShiftCalendarRemovedEvent
                        : ShiftCalendarIdentity
    {
        public string calendar_name { get; set; }
    }
}