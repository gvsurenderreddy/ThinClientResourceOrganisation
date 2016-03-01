using System;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Audit.Framework.AuditRecords;

namespace WTS.WorkSuite.Audit.HR.Employees
{
    /// <summary>
    ///     Record that is created whenever an employees address details are changed.
    /// </summary>
    public class EmployeeAddressDetailsAuditRecord
                        : BaseEntity<int>,
                            DefaultAuditRecordFields
    {
        /// <summary>
        ///     The event that caused an employee's address details are changed.
        /// </summary>
        public virtual string triggered_by_event { get; set; }

        /// <summary>
        ///     The time that the employee's address details change event was received by the audit system.
        /// </summary>
        public virtual DateTime received_at { get; set; }

        /// <summary>
        ///     The id of the address details are changed.
        /// </summary>
        public virtual int address_id { get; set; }

        /// <summary>
        ///     The house name or number of an employeee address.
        /// </summary>
        public virtual string number_or_name { get; set; }

        /// <summary>
        ///     The line one of an employee address.
        /// </summary>
        public virtual string line_one { get; set; }

        /// <summary>
        ///     The line two of an employee address.
        /// </summary>
        public virtual string line_two { get; set; }

        /// <summary>
        ///     The line three of an employee address.
        /// </summary>
        public virtual string line_three { get; set; }

        /// <summary>
        ///     The county of an employee address.
        /// </summary>
        public virtual string county { get; set; }

        /// <summary>
        ///     The country of an employee address.
        /// </summary>
        public virtual string country { get; set; }

        /// <summary>
        ///     The postcode of an employee address.
        /// </summary>
        public virtual string postcode { get; set; }

        /// <summary>
        ///     Priority of an employee address.
        /// </summary>
        public virtual int priority { get; set; }
    }
}