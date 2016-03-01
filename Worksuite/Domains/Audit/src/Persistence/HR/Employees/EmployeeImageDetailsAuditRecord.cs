using System;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Audit.Framework.AuditRecords;

namespace WTS.WorkSuite.Audit.HR.Employees
{
    /// <summary>
    ///     Record that is created whenever an employees image details are updated.
    /// </summary>
    public class EmployeeImageDetailsAuditRecord
                        : BaseEntity<int>,
                            DefaultAuditRecordFields
    {
        /// <summary>
        ///     The event that caused an employee's image details are updated.
        /// </summary>
        public virtual string triggered_by_event { get; set; }

        /// <summary>
        ///     The time that the employee's image details updated event was received by the audit system.
        /// </summary>
        public virtual DateTime received_at { get; set; }
    }
}