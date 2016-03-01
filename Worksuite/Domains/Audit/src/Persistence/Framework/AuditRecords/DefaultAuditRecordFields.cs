using System;

namespace WTS.WorkSuite.Audit.Framework.AuditRecords {


    /// <summary>
    ///     Fields that all audit records should have.
    /// </summary>
    public interface DefaultAuditRecordFields {

        /// <summary>
        ///     Event that caused the audit record to be created.
        /// </summary>
        string triggered_by_event { get; set; }

        /// <summary>
        ///     The time that the audit system recieved the event.
        /// </summary>
        DateTime received_at { get; set; }

    }
}