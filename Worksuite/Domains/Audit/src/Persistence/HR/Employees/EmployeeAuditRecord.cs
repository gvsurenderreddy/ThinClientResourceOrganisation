using System;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Audit.Framework.AuditRecords;

namespace WTS.WorkSuite.Audit.HR.Employees {

    /// <summary>
    ///     Audits changes to the employee aggregated
    /// </summary>
    public class EmployeeAuditRecord 
                    : BaseEntity<int> 
                    , DefaultAuditRecordFields {

        /// <summary>
        ///     The event that caused an employee's personal details to be updated 
        /// </summary>
        public virtual string triggered_by_event { get; set;  }

        /// <summary>
        ///     The time that the update event was received by the audit system
        /// </summary>
        public virtual DateTime received_at { get; set; }
    }

}