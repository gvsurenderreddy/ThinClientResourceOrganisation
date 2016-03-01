using WTS.WorkSuite.Audit.Framework.AuditRecords;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.DomainTypes.Time.Clocks;

namespace WTS.WorkSuite.Audit.HR.Employees.AggregateRoot
{
    public class EmployeeNoteDetailsAuditRecordBuilder<T>
    {
        public EmployeeNoteDetailsAuditRecord build(NewEmployeeNoteDetailsAuditModelRequest the_request)
        {
            return this
                .set_request(the_request)
                .create_model()
                ;
        }

        private EmployeeNoteDetailsAuditRecordBuilder<T> set_request(NewEmployeeNoteDetailsAuditModelRequest the_request)
        {
            _request = Guard.IsNotNull(the_request, "the_request");

            return this;
        }

        private EmployeeNoteDetailsAuditRecord create_model()
        {
            Guard.IsNotNull(_request, "_request");

            var result = new EmployeeNoteDetailsAuditRecord
                                {
                                    note_id = _request.note_id,
                                    notes = _request.note
                                };

            _set_default_audit_record_fields
                    .execute(new SetDefaultAuditRecordFieldsRequest(received_at: _request.received_at), result)
                    ;

            return result;
        }

        public EmployeeNoteDetailsAuditRecordBuilder(SetDefaultAuditRecordFields<T> the_set_default_audit_record_fields)
        {
            _set_default_audit_record_fields = Guard.IsNotNull(the_set_default_audit_record_fields,
                                                                "the_set_default_audit_record_fields"
                                                              );
        }

        private readonly SetDefaultAuditRecordFields<T> _set_default_audit_record_fields;
        private NewEmployeeNoteDetailsAuditModelRequest _request;
    }

    public class NewEmployeeNoteDetailsAuditModelRequest
    {
        public int note_id { get; private set; }

        public string note { get; private set; }

        public UtcTime received_at { get; private set; }

        public NewEmployeeNoteDetailsAuditModelRequest(int note_id,
                                                       string note,
                                                       UtcTime received_at
                                                      )
        {
            Guard.IsNotNull(received_at, "received_at");

            this.note_id = note_id;
            this.note = note;
            this.received_at = received_at;
        }
    }
}