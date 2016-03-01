using System;
using WTS.WorkSuite.Audit.Framework.AuditRecords;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.DomainTypes.Time.Clocks;

namespace WTS.WorkSuite.Audit.HR.Employees.AggregateRoot
{
    public class EmployeePersonalDetailsAuditRecordBuilder<T>
    {
        public EmployeePersonalDetailsAuditRecord build
                                                    (NewEmployeePersonalDetailsAuditModelRequest the_request)
        {
            return this
                    .set_request(the_request)
                    .create_model()
                    ;
        }

        public EmployeePersonalDetailsAuditRecordBuilder
                    (SetDefaultAuditRecordFields<T> set_default_audit_record_fields_command)
        {
            set_default_audit_record_fields = Guard.IsNotNull(set_default_audit_record_fields_command, "set_default_audit_record_fields_command");
        }

        public EmployeePersonalDetailsAuditRecordBuilder<T> set_request
                                                                (NewEmployeePersonalDetailsAuditModelRequest the_request)
        {
            request = Guard.IsNotNull(the_request, "the_request");
            return this;
        }

        public EmployeePersonalDetailsAuditRecord create_model()
        {
            Guard.IsNotNull(request, "request");

            var result = new EmployeePersonalDetailsAuditRecord
            {
                forename = request.forename,
                surname = request.surname,
                othername = request.othername,
                place_of_birth = request.place_of_birth,
                date_of_birth = request.date_of_birth,
                title_id = request.title_id,
                title_description = request.title_description,
                gender_id = request.gender_id,
                gender_description = request.gender_description,
                marital_status_id = request.marital_status_id,
                marital_status_description = request.marital_status_description,
                nationality_id = request.nationality_id,
                nationality_description = request.nationality_description,
                ethnic_origin_id = request.ethnic_origin_id,
                ethnic_origin_description = request.ethnic_origin_description
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

        private NewEmployeePersonalDetailsAuditModelRequest request;
    }

    public class NewEmployeePersonalDetailsAuditModelRequest
    {
        public string forename { get; private set; }

        public string surname { get; private set; }

        public string othername { get; private set; }

        public string place_of_birth { get; private set; }

        public DateTime? date_of_birth { get; private set; }

        public int? title_id { get; private set; }

        public string title_description { get; private set; }

        public int? gender_id { get; private set; }

        public string gender_description { get; private set; }

        public int? marital_status_id { get; private set; }

        public string marital_status_description { get; private set; }

        public int? nationality_id { get; private set; }

        public string nationality_description { get; private set; }

        public int? ethnic_origin_id { get; private set; }

        public string ethnic_origin_description { get; private set; }

        public UtcTime received_at { get; private set; }

        public NewEmployeePersonalDetailsAuditModelRequest
                (string forename
                , string surname
                , string othername
                , string place_of_birth
                , DateTime? date_of_birth
                , int? title_id
                , string title_description
                , int? gender_id
                , string gender_description
                , int? marital_status_id
                , string marital_status_description
                , int? nationality_id
                , string nationality_description
                , int? ethnic_origin_id
                , string ethnic_origin_description
                , UtcTime received_at)
        {
            Guard.IsNotNull(received_at, "recieved_at");

            this.forename = forename;
            this.surname = surname;
            this.othername = othername;
            this.place_of_birth = place_of_birth;
            this.date_of_birth = date_of_birth;
            this.title_id = title_id;
            this.title_description = title_description;
            this.gender_id = gender_id;
            this.gender_description = gender_description;
            this.marital_status_id = marital_status_id;
            this.marital_status_description = marital_status_description;
            this.nationality_id = nationality_id;
            this.nationality_description = nationality_description;
            this.ethnic_origin_id = ethnic_origin_id;
            this.ethnic_origin_description = ethnic_origin_description;
            this.received_at = received_at;
        }
    }
}