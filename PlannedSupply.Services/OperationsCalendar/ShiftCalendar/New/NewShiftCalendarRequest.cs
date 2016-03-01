namespace WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.New
{
    /// <summary>
    ///     Request accepted by the add shift calendar command
    /// </summary>
    public class NewShiftCalendarRequest
                        : OperationsCalendarIdentity
    {
        public string calendar_name { get; set; }
    }
}