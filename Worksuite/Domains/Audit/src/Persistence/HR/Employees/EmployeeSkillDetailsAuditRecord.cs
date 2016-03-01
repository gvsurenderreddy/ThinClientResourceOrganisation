using System;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Audit.Framework.AuditRecords;

namespace WTS.WorkSuite.Audit.HR.Employees
{
    /// <summary>
    ///     Record that is created whenever an employees skill details are changed.
    /// </summary>
    public class EmployeeSkillDetailsAuditRecord
                        : BaseEntity<int>,
                            DefaultAuditRecordFields
    {
        /// <summary>
        ///     The event that caused an employee's skill details are changed.
        /// </summary>
        public virtual string triggered_by_event { get; set; }

        /// <summary>
        ///     The time that the employee's skill details change event was received by the audit system.
        /// </summary>
        public virtual DateTime received_at { get; set; }

        /// <summary>
        ///     The employee's skill - skill reference id & description and priority.
        /// </summary>
        public virtual int skill_id { get; set; }

        public virtual string skill_description { get; set; }

        public virtual int priority { get; set; }
    }
}