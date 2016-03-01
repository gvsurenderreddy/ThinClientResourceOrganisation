using WTS.WorkSuite.Audit.Framework.AuditRecords;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.DomainTypes.Time.Clocks;

namespace WTS.WorkSuite.Audit.HR.Employees.AggregateRoot
{
    public class EmployeeQualificationDetailsAuditRecordBuilder<T>
    {
        public EmployeeQualificationDetailsAuditRecord build(NewEmployeeQualificationDetailsAuditModelRequest the_request)
        {
            return this
                .set_request(the_request)
                .create_model()
                ;
        }

        private EmployeeQualificationDetailsAuditRecordBuilder<T> set_request(NewEmployeeQualificationDetailsAuditModelRequest the_request)
        {
            _request = Guard.IsNotNull(the_request, "the_request");

            return this;
        }

        private EmployeeQualificationDetailsAuditRecord create_model()
        {
            Guard.IsNotNull(_request, "_request");

            var result = new EmployeeQualificationDetailsAuditRecord
            {
                qualification_id = _request.qualification_id,
                qualification_description = _request.qualification_description
            };

            _set_default_audit_record_fields
                    .execute(new SetDefaultAuditRecordFieldsRequest(received_at: _request.received_at), result)
                    ;

            return result;
        }

        public EmployeeQualificationDetailsAuditRecordBuilder(SetDefaultAuditRecordFields<T> the_set_default_audit_record_fields)
        {
            _set_default_audit_record_fields = Guard.IsNotNull(the_set_default_audit_record_fields,
                                                                "the_set_default_audit_record_fields"
                                                              );
        }

        private readonly SetDefaultAuditRecordFields<T> _set_default_audit_record_fields;
        private NewEmployeeQualificationDetailsAuditModelRequest _request;
    }

    public class NewEmployeeQualificationDetailsAuditModelRequest
    {
        public int qualification_id { get; private set; }

        public string qualification_description { get; private set; }
        public UtcTime received_at { get; private set; }

        public NewEmployeeQualificationDetailsAuditModelRequest(int qualification_id,
                                                                string qualification_description,
                                                                UtcTime received_at
                                                       )
        {
            Guard.IsNotNull(received_at, "received_at");

            this.qualification_id = qualification_id;
            this.qualification_description = qualification_description;
            this.received_at = received_at;
        }
    }
}