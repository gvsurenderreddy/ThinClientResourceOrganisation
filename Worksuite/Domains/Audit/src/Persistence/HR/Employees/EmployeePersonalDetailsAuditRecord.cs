using System;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Audit.Framework.AuditRecords;

namespace WTS.WorkSuite.Audit.HR.Employees
{
    /// <summary>
    ///     Record that is created whenever an employees personal details are modified
    /// </summary>
    public class EmployeePersonalDetailsAuditRecord
                    : BaseEntity<int>
                    , DefaultAuditRecordFields
    {
        /// <summary>
        ///     The event that caused an employee's personal details to be updated
        /// </summary>
        public virtual string triggered_by_event { get; set; }

        /// <summary>
        ///     The time that the update event was received by the audit system
        /// </summary>
        public virtual DateTime received_at { get; set; }

        /// <summary>
        ///     The employees forename
        /// </summary>
        public virtual string forename { get; set; }

        /// <summary>
        ///     The employees surname
        /// </summary>
        public virtual string surname { get; set; }

        /// <summary>
        ///     The employee's othername
        /// </summary>
        public virtual string othername { get; set; }

        /// <summary>
        ///     The employee's place of birth
        /// </summary>
        public virtual string place_of_birth { get; set; }

        /// <summary>
        ///     The employee's date of birth
        /// </summary>
        public virtual DateTime? date_of_birth { get; set; }

        /// <summary>
        ///     The employee's title - title reference id & description
        /// </summary>
        public virtual int? title_id { get; set; }

        public virtual string title_description { get; set; }

        /// <summary>
        ///     The employee's gender - gender reference id & description
        /// </summary>
        public virtual int? gender_id { get; set; }

        public virtual string gender_description { get; set; }

        /// <summary>
        ///     The employee's marital status - marital status reference id & description
        /// </summary>
        public virtual int? marital_status_id { get; set; }

        public virtual string marital_status_description { get; set; }

        /// <summary>
        ///     The employee's nationality - nationality reference id & description
        /// </summary>
        public virtual int? nationality_id { get; set; }

        public virtual string nationality_description { get; set; }

        /// <summary>
        ///     The employee's ethnic origin - ethnic origin reference id & description
        /// </summary>
        public virtual int? ethnic_origin_id { get; set; }

        public virtual string ethnic_origin_description { get; set; }
    }
}