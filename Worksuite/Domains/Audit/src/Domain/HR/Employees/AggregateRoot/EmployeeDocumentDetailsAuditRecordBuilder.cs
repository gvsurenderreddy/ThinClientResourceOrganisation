using WTS.WorkSuite.Audit.Framework.AuditRecords;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.DomainTypes.Time.Clocks;

namespace WTS.WorkSuite.Audit.HR.Employees.AggregateRoot
{
    public class EmployeeDocumentDetailsAuditRecordBuilder<T>
    {
        public EmployeeDocumentDetailsAuditRecord build(NewEmployeeDocumentsDetailsAuditModelRequest the_request)
        {
            return this
                .set_request(the_request)
                .create_model()
                ;
        }

        private EmployeeDocumentDetailsAuditRecordBuilder<T> set_request(NewEmployeeDocumentsDetailsAuditModelRequest the_request)
        {
            _request = Guard.IsNotNull(the_request, "the_request");

            return this;
        }

        private EmployeeDocumentDetailsAuditRecord create_model()
        {
            Guard.IsNotNull(_request, "_request");

            var result = new EmployeeDocumentDetailsAuditRecord
            {
                name = _request.name,
                description = _request.description
            };

            _set_default_audit_record_fields
                    .execute(new SetDefaultAuditRecordFieldsRequest(received_at: _request.received_at), result)
                    ;

            return result;
        }

        public EmployeeDocumentDetailsAuditRecordBuilder(SetDefaultAuditRecordFields<T> the_set_default_audit_record_fields)
        {
            _set_default_audit_record_fields = Guard.IsNotNull(the_set_default_audit_record_fields,
                                                                "the_set_default_audit_record_fields"
                                                              );
        }

        private readonly SetDefaultAuditRecordFields<T> _set_default_audit_record_fields;
        private NewEmployeeDocumentsDetailsAuditModelRequest _request;
    }

    public class NewEmployeeDocumentsDetailsAuditModelRequest
    {
        public string name { get; private set; }

        public string description { get; private set; }

        public UtcTime received_at { get; private set; }

        public NewEmployeeDocumentsDetailsAuditModelRequest(string name,
                                                            string description,
                                                            UtcTime received_at
                                                           )
        {
            Guard.IsNotNull(received_at, "received_at");

            this.name = name;
            this.description = description;
            this.received_at = received_at;
        }
    }
}