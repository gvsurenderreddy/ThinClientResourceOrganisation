using System;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Audit.Framework.AuditRecords;

namespace WTS.WorkSuite.Audit.HR.Employees
{
    /// <summary>
    ///     Record that is created whenever an employees document details are changed.
    /// </summary>
    public class EmployeeDocumentDetailsAuditRecord
                        : BaseEntity<int>,
                            DefaultAuditRecordFields
    {
        /// <summary>
        ///     The event that caused an employee's document details are changed.
        /// </summary>
        public virtual string triggered_by_event { get; set; }

        /// <summary>
        ///     The time that the employee's document details change event was received by the audit system.
        /// </summary>
        public virtual DateTime received_at { get; set; }

        /// <summary>
        ///     The name of an employeee document.
        /// </summary>
        public virtual string name { get; set; }

        /// <summary>
        ///     The description of an employeee document.
        /// </summary>
        public virtual string description { get; set; }
    }
}