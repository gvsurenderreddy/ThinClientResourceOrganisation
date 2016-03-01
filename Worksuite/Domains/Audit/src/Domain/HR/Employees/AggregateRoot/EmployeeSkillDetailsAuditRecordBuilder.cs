using WTS.WorkSuite.Audit.Framework.AuditRecords;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.DomainTypes.Time.Clocks;

namespace WTS.WorkSuite.Audit.HR.Employees.AggregateRoot
{
    public class EmployeeSkillDetailsAuditRecordBuilder<T>
    {
        public EmployeeSkillDetailsAuditRecord build(NewEmployeeSkillDetailsAuditModelRequest the_request)
        {
            return this
                .set_request(the_request)
                .create_model()
                ;
        }

        private EmployeeSkillDetailsAuditRecordBuilder<T> set_request(NewEmployeeSkillDetailsAuditModelRequest the_request)
        {
            _request = Guard.IsNotNull(the_request, "the_request");

            return this;
        }

        private EmployeeSkillDetailsAuditRecord create_model()
        {
            Guard.IsNotNull(_request, "_request");

            var result = new EmployeeSkillDetailsAuditRecord
            {
                skill_id = _request.skill_id,
                skill_description = _request.skill_description,
                priority = _request.priority
            };

            _set_default_audit_record_fields
                    .execute(new SetDefaultAuditRecordFieldsRequest(received_at: _request.received_at), result)
                    ;

            return result;
        }

        public EmployeeSkillDetailsAuditRecordBuilder(SetDefaultAuditRecordFields<T> the_set_default_audit_record_fields)
        {
            _set_default_audit_record_fields = Guard.IsNotNull(the_set_default_audit_record_fields,
                                                                "the_set_default_audit_record_fields"
                                                              );
        }

        private readonly SetDefaultAuditRecordFields<T> _set_default_audit_record_fields;
        private NewEmployeeSkillDetailsAuditModelRequest _request;
    }

    public class NewEmployeeSkillDetailsAuditModelRequest
    {
        public int skill_id { get; private set; }

        public string skill_description { get; private set; }

        public int priority { get; private set; }

        public UtcTime received_at { get; private set; }

        public NewEmployeeSkillDetailsAuditModelRequest(int skill_id,
                                                        string skill_description,
                                                        int priority,
                                                        UtcTime received_at
                                                       )
        {
            Guard.IsNotNull(received_at, "received_at");

            this.skill_id = skill_id;
            this.skill_description = skill_description;
            this.priority = priority;
            this.received_at = received_at;
        }
    }
}