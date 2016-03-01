using WTS.WorkSuite.Audit.Framework.AuditRecords;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.DomainTypes.Time.Clocks;

namespace WTS.WorkSuite.Audit.HR.Employees.AggregateRoot
{
    public class EmployeeAddressDetailsAuditRecordBuilder<T>
    {
        public EmployeeAddressDetailsAuditRecord build(NewEmployeeAddressDetailsAuditModelRequest the_request)
        {
            return this
                .set_request(the_request)
                .create_model()
                ;
        }

        private EmployeeAddressDetailsAuditRecordBuilder<T> set_request(NewEmployeeAddressDetailsAuditModelRequest the_request)
        {
            _request = Guard.IsNotNull(the_request, "the_request");

            return this;
        }

        private EmployeeAddressDetailsAuditRecord create_model()
        {
            Guard.IsNotNull(_request, "_request");

            var result = new EmployeeAddressDetailsAuditRecord
                                    {
                                        address_id = _request.address_id,
                                        number_or_name = _request.number_or_name,
                                        line_one = _request.line_one,
                                        line_two = _request.line_two,
                                        line_three = _request.line_three,
                                        county = _request.county,
                                        country = _request.country,
                                        postcode = _request.postcode,
                                        priority = _request.priority
                                    };

            _set_default_audit_record_fields
                    .execute(new SetDefaultAuditRecordFieldsRequest(received_at: _request.received_at), result)
                    ;

            return result;
        }

        public EmployeeAddressDetailsAuditRecordBuilder(SetDefaultAuditRecordFields<T> the_set_default_audit_record_fields)
        {
            _set_default_audit_record_fields = Guard.IsNotNull(the_set_default_audit_record_fields,
                                                                "the_set_default_audit_record_fields"
                                                              );
        }

        private readonly SetDefaultAuditRecordFields<T> _set_default_audit_record_fields;
        private NewEmployeeAddressDetailsAuditModelRequest _request;
    }

    public class NewEmployeeAddressDetailsAuditModelRequest
    {
        public int address_id { get; private set; }

        public string number_or_name { get; private set; }

        public string line_one { get; private set; }

        public string line_two { get; private set; }

        public string line_three { get; private set; }

        public string county { get; private set; }

        public string country { get; private set; }

        public string postcode { get; set; }

        public int priority { get; private set; }

        public UtcTime received_at { get; private set; }

        public NewEmployeeAddressDetailsAuditModelRequest(int address_id,
                                                            string number_or_name,
                                                            string line_one,
                                                            string line_two,
                                                            string line_three,
                                                            string county,
                                                            string country,
                                                            string postcode,
                                                            int priority,
                                                            UtcTime received_at
                                                         )
        {
            Guard.IsNotNull(received_at, "received_at");

            this.address_id = address_id;
            this.number_or_name = number_or_name;
            this.line_one = line_one;
            this.line_two = line_two;
            this.line_three = line_three;
            this.county = county;
            this.country = country;
            this.postcode = postcode;
            this.priority = priority;
            this.received_at = received_at;
        }
    }
}