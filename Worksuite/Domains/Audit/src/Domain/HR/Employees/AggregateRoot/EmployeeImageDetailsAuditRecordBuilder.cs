using WTS.WorkSuite.Audit.Framework.AuditRecords;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.DomainTypes.Time.Clocks;

namespace WTS.WorkSuite.Audit.HR.Employees.AggregateRoot
{
    public class EmployeeImageDetailsAuditRecordBuilder<T>
    {
        public EmployeeImageDetailsAuditRecord build(NewEmployeeImageDetailsAuditModelRequest the_request)
        {
            return this
                .set_request(the_request)
                .create_model()
                ;
        }

        private EmployeeImageDetailsAuditRecord create_model()
        {
            Guard.IsNotNull(_request, "_request");

            var result = new EmployeeImageDetailsAuditRecord();

            _set_default_audit_record_fields.execute(new SetDefaultAuditRecordFieldsRequest(received_at: _request.received_at), result);

            return result;
        }

        private EmployeeImageDetailsAuditRecordBuilder<T> set_request(NewEmployeeImageDetailsAuditModelRequest the_request)
        {
            _request = Guard.IsNotNull(the_request, "the_request");

            return this;
        }

        public EmployeeImageDetailsAuditRecordBuilder(SetDefaultAuditRecordFields<T> the_set_default_audit_record_fields)
        {
            _set_default_audit_record_fields = Guard.IsNotNull(the_set_default_audit_record_fields,
                                                                "the_set_default_audit_record_fields"
                                                              );
        }

        private readonly SetDefaultAuditRecordFields<T> _set_default_audit_record_fields;
        private NewEmployeeImageDetailsAuditModelRequest _request;
    }

    public class NewEmployeeImageDetailsAuditModelRequest
    {
        public UtcTime received_at { get; private set; }

        public NewEmployeeImageDetailsAuditModelRequest(UtcTime received_at)
        {
            Guard.IsNotNull(received_at, "received_at");

            this.received_at = received_at;
        }
    }
}