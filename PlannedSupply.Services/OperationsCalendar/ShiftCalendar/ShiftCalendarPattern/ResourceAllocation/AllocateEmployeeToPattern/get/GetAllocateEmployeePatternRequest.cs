namespace WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ResourceAllocation.AllocateEmployeeToPattern.get
{
    /// <summary>
    ///     Shift calendar pattern employee identity class
    /// </summary>
    public class GetAllocateEmployeePatternRequest
                        : ShiftCalendarPatternIdentity
    {
        /// <summary>
        ///     Gets or sets the employee id
        /// </summary>
        /// <value>
        ///     The id.
        /// </value>
        public int employee_id { get; set; }
    }
}
