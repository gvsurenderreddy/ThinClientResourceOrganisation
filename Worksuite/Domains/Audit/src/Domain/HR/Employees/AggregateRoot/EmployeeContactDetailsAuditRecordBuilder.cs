using WTS.WorkSuite.Audit.Framework.AuditRecords;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.DomainTypes.Time.Clocks;

namespace WTS.WorkSuite.Audit.HR.Employees.AggregateRoot
{
    public class EmployeeContactDetailsAuditRecordBuilder<T>
    {
        public EmployeeContactDetailsAuditRecord build(NewEmployeeContactDetailsAuditModelRequest the_request)
        {
            return this
                .set_request(the_request)
                .create_model()
                ;
        }

        private EmployeeContactDetailsAuditRecordBuilder<T> set_request(NewEmployeeContactDetailsAuditModelRequest the_request)
        {
            _request = Guard.IsNotNull(the_request, "the_request");
            return this;
        }

        private EmployeeContactDetailsAuditRecord create_model()
        {
            Guard.IsNotNull(_request, "_request");

            var result = new EmployeeContactDetailsAuditRecord
                                {
                                    phone_number = _request.phone_number,
                                    email = _request.email,
                                    mobile = _request.mobile,
                                    other = _request.other
                                };

            _set_default_audit_record_fields_command
                    .execute(new SetDefaultAuditRecordFieldsRequest(received_at: _request.received_at),
                            result
                            )
                    ;

            return result;
        }

        public EmployeeContactDetailsAuditRecordBuilder(SetDefaultAuditRecordFields<T> the_set_default_audit_record_fields_command)
        {
            _set_default_audit_record_fields_command = Guard.IsNotNull(the_set_default_audit_record_fields_command,
                                                                        "the_set_default_audit_record_fields_command"
                                                                      );
        }

        private readonly SetDefaultAuditRecordFields<T> _set_default_audit_record_fields_command;
        private NewEmployeeContactDetailsAuditModelRequest _request;
    }

    public class NewEmployeeContactDetailsAuditModelRequest
    {
        public string phone_number { get; private set; }

        public string email { get; private set; }

        public string mobile { get; private set; }

        public string other { get; private set; }

        public UtcTime received_at { get; private set; }

        public NewEmployeeContactDetailsAuditModelRequest(string phone_number,
                                                            string email,
                                                            string mobile,
                                                            string other,
                                                            UtcTime received_at
                                                         )
        {
            Guard.IsNotNull(received_at, "the_received_at");

            this.phone_number = phone_number;
            this.email = email;
            this.mobile = mobile;
            this.other = other;
            this.received_at = received_at;
        }
    }
}