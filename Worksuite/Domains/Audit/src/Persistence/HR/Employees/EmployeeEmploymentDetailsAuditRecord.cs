using System;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Audit.Framework.AuditRecords;

namespace WTS.WorkSuite.Audit.HR.Employees
{
    /// <summary>
    ///     Record that is created whenever an employee's employment details are modified
    /// </summary>
    public class EmployeeEmploymentDetailsAuditRecord
                    : BaseEntity<int>
                    , DefaultAuditRecordFields
    {
        /// <summary>
        ///     The event that caused an employee's employment details to be updated.
        /// </summary>
        public virtual string triggered_by_event { get; set; }

        /// <summary>
        ///     The time that the update event was received by the audit system
        /// </summary>
        public DateTime received_at { get; set; }

        /// <summary>
        ///     The state of an employee's employee refence after the event was triggered.
        /// </summary>
        public virtual string employee_reference { get; set; }

        /// <summary>
        ///     The employee's job title - job title reference id & description
        /// </summary>
        public virtual int? job_title_id { get; set; }

        public virtual string job_title_description { get; set; }

        /// <summary>
        ///     The employee's location - location reference id & description
        /// </summary>
        public virtual int? location_id { get; set; }

        public virtual string location_description { get; set; }
    }
}