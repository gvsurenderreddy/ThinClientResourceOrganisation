using WTS.WorkSuite.Audit.Framework.AuditRecords;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.DomainTypes.Time.Clocks;

namespace WTS.WorkSuite.Audit.HR.Employees.AggregateRoot
{
    public class EmergencyContactDetailsAuditRecordBuilder<T>
    {
        public EmergencyContactDetailsAuditRecord build(NewEmergencyContactAtailsAuditModelRequest the_request)
        {
            return this
                .set_request(the_request)
                .create_model();
        }

        private EmergencyContactDetailsAuditRecordBuilder<T> set_request(NewEmergencyContactAtailsAuditModelRequest the_request)
        {
            request = Guard.IsNotNull(the_request, "the_request");
            return this;
        }

        private EmergencyContactDetailsAuditRecord create_model()
        {
            Guard.IsNotNull(request, "request");
            var result = new EmergencyContactDetailsAuditRecord()
                             {
                                 id = request.emergency_contact_id,
                                 name = request.name,
                                 relationship_id = request.relationship_id,
                                 primary_phone_number = request.primary_phone_number,
                                 other_phone_number = request.other_phone_number,
                                 priority = request.priority
                             };
                            
            set_default_audit_record_fields
                .execute(new SetDefaultAuditRecordFieldsRequest(received_at: request.received_at ), result);

            return result;
        }

        public EmergencyContactDetailsAuditRecordBuilder (SetDefaultAuditRecordFields<T> the_set_default_audit_record_fields )
        {
            set_default_audit_record_fields = Guard.IsNotNull(the_set_default_audit_record_fields, "the_set_default_audit_record_fields");
        }

        private readonly SetDefaultAuditRecordFields<T> set_default_audit_record_fields;
        private NewEmergencyContactAtailsAuditModelRequest request;
    }

    public class NewEmergencyContactAtailsAuditModelRequest
    {
        public int emergency_contact_id { get; private set; }
        public string name { get; private set; }
        public int? relationship_id { get; private set; }
        public string primary_phone_number { get; private set; }
        public string other_phone_number { get; private set; }
        public int priority { get; private set; }
        public UtcTime received_at { get; private set; }

        public NewEmergencyContactAtailsAuditModelRequest(int emergency_contact_id,
                                                          string name,
                                                          int? relationship_id,
                                                          string primary_phone_number,
                                                          string other_phone_number,
                                                          int priority,
                                                          UtcTime received_at)
        {
            Guard.IsNotNull(received_at, "received_at");
            this.emergency_contact_id = emergency_contact_id;
            this.name = name;
            this.relationship_id = relationship_id;
            this.primary_phone_number = primary_phone_number;
            this.other_phone_number = other_phone_number;
            this.priority = priority;
            this.received_at = received_at;
        }
    }
}