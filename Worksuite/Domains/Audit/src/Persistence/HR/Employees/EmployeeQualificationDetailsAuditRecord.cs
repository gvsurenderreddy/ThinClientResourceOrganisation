using System;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Audit.Framework.AuditRecords;

namespace WTS.WorkSuite.Audit.HR.Employees
{
    /// <summary>
    ///     Record that is created whenever an employees qualification details are changed.
    /// </summary>
    public class EmployeeQualificationDetailsAuditRecord
                        : BaseEntity<int>,
                            DefaultAuditRecordFields
    {
        /// <summary>
        ///     The event that caused an employee's qualification details are changed.
        /// </summary>
        public virtual string triggered_by_event { get; set; }

        /// <summary>
        ///     The time that the employee's qualification details change event was received by the audit system.
        /// </summary>
        public virtual DateTime received_at { get; set; }

        /// <summary>
        ///     The employee's qualification - qualification reference id & description and priority.
        /// </summary>
        public virtual int? qualification_id { get; set; }

        public virtual string qualification_description { get; set; }
    }
}