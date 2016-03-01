using System;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Audit.Framework.AuditRecords;

namespace WTS.WorkSuite.Audit.HR.Employees
{
    public class EmergencyContactDetailsAuditRecord
                                       :BaseEntity<int>,
                                        DefaultAuditRecordFields
    {
        public virtual string triggered_by_event { get; set; }
        public virtual DateTime received_at { get; set; }

        public virtual string name { get; set; }
        public virtual int? relationship_id { get; set; }
        public virtual string primary_phone_number { get; set; }
        public virtual string other_phone_number { get; set; }
        public virtual int priority { get; set; }
    }
}