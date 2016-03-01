using System;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Audit.Framework.AuditRecords;

namespace WTS.WorkSuite.Audit.HR.Employees
{
    /// <summary>
    ///     Record that is created whenever an employees contact details are changed.
    /// </summary>

    public class EmployeeContactDetailsAuditRecord
                        : BaseEntity<int>,
                            DefaultAuditRecordFields
    {
        /// <summary>
        ///     The event that caused an employee's contact details are changed.
        /// </summary>
        public virtual string triggered_by_event { get; set; }

        /// <summary>
        ///     The time that the employee's contact details change event was received by the audit system
        /// </summary>
        public virtual DateTime received_at { get; set; }

        /// <summary>
        ///     The employee's contact phone number
        /// </summary>
        public virtual string phone_number { get; set; }

        /// <summary>
        ///     The employee's contact email address
        /// </summary>
        public virtual string email { get; set; }

        /// <summary>
        ///     The employee's contact mobile
        /// </summary>
        public virtual string mobile { get; set; }

        /// <summary>
        ///     The employee's other contact details
        /// </summary>
        public virtual string other { get; set; }
    }
}