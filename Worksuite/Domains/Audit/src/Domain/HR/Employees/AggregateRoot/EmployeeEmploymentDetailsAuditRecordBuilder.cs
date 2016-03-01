using WTS.WorkSuite.Audit.Framework.AuditRecords;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.DomainTypes.Primitives.Sanitisation;
using WTS.WorkSuite.Library.DomainTypes.Time.Clocks;

namespace WTS.WorkSuite.Audit.HR.Employees.AggregateRoot
{
    public class EmployeeEmploymentDetailsAuditRecordBuilder<T>
    {
        public EmployeeEmploymentDetailsAuditRecord build
                                                    (NewEmployeeEmploymentDetailsAuditModelRequest the_request)
        {
            return this
                    .set_request(the_request)
                    .sanatise_request()
                    .create_model()
                    ;
        }

        public EmployeeEmploymentDetailsAuditRecordBuilder
                    (SetDefaultAuditRecordFields<T> set_default_audit_record_fields_command)
        {
            set_default_audit_record_fields = Guard.IsNotNull(set_default_audit_record_fields_command, "set_default_audit_record_fields_command");
        }

        private EmployeeEmploymentDetailsAuditRecordBuilder<T> set_request
                                                                (NewEmployeeEmploymentDetailsAuditModelRequest the_request)
        {
            request = Guard.IsNotNull(the_request, "the_request");
            return this;
        }

        private EmployeeEmploymentDetailsAuditRecordBuilder<T> sanatise_request()
        {
            Guard.IsNotNull(request, "request");

            request = new NewEmployeeEmploymentDetailsAuditModelRequest(
                employee_reference: request.employee_reference.normalise_for_persistence(),
                job_title_id: request.job_title_id,
                job_title_description: request.job_title_description,
                location_id: request.location_id,
                location_description: request.location_description,
                received_at: request.received_at
            );
            return this;
        }

        private EmployeeEmploymentDetailsAuditRecord create_model()
        {
            Guard.IsNotNull(request, "request");

            var result = new EmployeeEmploymentDetailsAuditRecord
            {
                employee_reference = request.employee_reference,
                job_title_id = request.job_title_id,
                job_title_description = request.job_title_description,
                location_id = request.location_id,
                location_description = request.location_description
            };

            set_default_audit_record_fields.execute(
                new SetDefaultAuditRecordFieldsRequest(
                    received_at: request.received_at
                ),
                result
            );

            return result;
        }

        private readonly SetDefaultAuditRecordFields<T> set_default_audit_record_fields;

        private NewEmployeeEmploymentDetailsAuditModelRequest request;
    }

    public class NewEmployeeEmploymentDetailsAuditModelRequest
    {
        public string employee_reference { get; private set; }

        public int? job_title_id { get; private set; }

        public string job_title_description { get; private set; }

        public int? location_id { get; private set; }

        public string location_description { get; private set; }

        public UtcTime received_at { get; private set; }

        public NewEmployeeEmploymentDetailsAuditModelRequest(string employee_reference,
                                                             int? job_title_id,
                                                             string job_title_description,
                                                             int? location_id,
                                                             string location_description,
                                                             UtcTime received_at
                                                            )
        {
            Guard.IsNotNull(received_at, "received_at");

            this.employee_reference = employee_reference;
            this.job_title_id = job_title_id;
            this.job_title_description = job_title_description;
            this.location_id = location_id;
            this.location_description = location_description;
            this.received_at = received_at;
        }
    }
}