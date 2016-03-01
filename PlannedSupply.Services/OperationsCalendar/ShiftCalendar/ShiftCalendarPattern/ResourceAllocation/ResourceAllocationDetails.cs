using System;

namespace WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ResourceAllocation
{
    /// <summary>
    ///     The full details of a resource allocation
    /// </summary>
    public class ResourceAllocationDetails : ResourceAllocationIdentity
    {
        /// <summary>
        ///     Id of the employee
        /// </summary>
        public int employee_id { get; set; }

        /// <summary>
        ///     Date the resource was added
        /// </summary>
        public DateTime created_date { get; set; }

    }
}
