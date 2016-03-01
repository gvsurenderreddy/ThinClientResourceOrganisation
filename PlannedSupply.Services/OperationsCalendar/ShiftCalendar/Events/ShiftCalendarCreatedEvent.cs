namespace WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.Events {

    /// <summary>
    ///     Event that is published when an new shift calendar is created
    /// </summary>
    public class ShiftCalendarCreatedEvent
                    : ShiftCalendarIdentity {

        public string calendar_name { get; set; }
    }

}