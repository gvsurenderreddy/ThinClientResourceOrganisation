namespace WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.Events {

    /// <summary>
    ///  Event that is published when an shift calendar is updated.
    /// </summary>
    public class ShiftCalendarUpdatedEvent 
                    : ShiftCalendarIdentity {

        public string calendar_name { get; set; }
    }
}