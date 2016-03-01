using System;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Audit.Framework.AuditRecords;

namespace WTS.WorkSuite.Audit.HR.Employees
{
    /// <summary>
    ///     Record that is created whenever an employees note details are changed.
    /// </summary>
    public class EmployeeNoteDetailsAuditRecord
                        : BaseEntity<int>,
                            DefaultAuditRecordFields
    {
        /// <summary>
        ///     The event that caused an employee's note details are changed.
        /// </summary>
        public virtual string triggered_by_event { get; set; }

        /// <summary>
        ///     The time that the employee's note details change event was received by the audit system.
        /// </summary>
        public virtual DateTime received_at { get; set; }

        /// <summary>
        ///     The id of the note details are changed.
        /// </summary>
        public virtual int note_id { get; set; }

        /// <summary>
        ///     The note of an employeee note.
        /// </summary>
        public virtual string notes { get; set; }
    }
}