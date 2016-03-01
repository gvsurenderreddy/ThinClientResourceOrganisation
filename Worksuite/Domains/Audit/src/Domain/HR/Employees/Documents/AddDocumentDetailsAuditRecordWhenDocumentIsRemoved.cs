using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Audit.HR.Employees.AggregateRoot;
using WTS.WorkSuite.HR.HR.Employees.EmployeeDocuments.Events;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral.Events;
using WTS.WorkSuite.Library.DomainTypes.Time.Clocks;

namespace WTS.WorkSuite.Audit.HR.Employees.Documents
{
    public class AddDocumentDetailsAuditRecordWhenDocumentIsRemoved
                        : IEventSubscriber<EmployeeDocumentRemovedEvent>
    {
        public void handle(EmployeeDocumentRemovedEvent the_event_to_handle)
        {
            this
                .set_event(the_event_to_handle)
                .get_employee_audit_trail()
                .add_employee_audit_record()
                .add_document_details_removed_audit_record()
                .commit()
                ;
        }

        private AddDocumentDetailsAuditRecordWhenDocumentIsRemoved set_event(EmployeeDocumentRemovedEvent the_event_to_handle)
        {
            _event_to_handle = Guard.IsNotNull(the_event_to_handle, "the_event_to_handle");
            _received_at = _clock.now();

            return this;
        }

        private AddDocumentDetailsAuditRecordWhenDocumentIsRemoved get_employee_audit_trail()
        {
            Guard.IsNotNull(_event_to_handle, "_event_to_handle");
            Guard.IsNotNull(_received_at, "_received_at");
            Guard.IsNotNull(_get_or_create_employee_audit_trail, "_get_or_create_employee_audit_trail");

            var request = new GetOrCreateEmployeeAuditTrailRequest(employee_id: _event_to_handle.employee_id,
                                                                    received_at: _received_at
                                                                  );

            _audit_trail = _get_or_create_employee_audit_trail.execute(request);

            return this;
        }

        private AddDocumentDetailsAuditRecordWhenDocumentIsRemoved add_employee_audit_record()
        {
            Guard.IsNotNull(_employee_audit_record_builder, "_employee_audit_record_builder");
            Guard.IsNotNull(_audit_trail, "_audit_trail");
            Guard.IsNotNull(_received_at, "_received_at");

            var audit_record = _employee_audit_record_builder
                                    .build(new NewEmployeeAuditRecordRequest(received_at: _received_at))
                                    ;

            _audit_trail
                    .employee_audit
                    .Add(audit_record)
                    ;

            return this;
        }

        private AddDocumentDetailsAuditRecordWhenDocumentIsRemoved add_document_details_removed_audit_record()
        {
            Guard.IsNotNull(_employee_document_details_audit_record_builder, "_employee_document_details_audit_record_builder");
            Guard.IsNotNull(_event_to_handle, "_event_to_handle");
            Guard.IsNotNull(_audit_trail, "_audit_trail");
            Guard.IsNotNull(_received_at, "_received_at");

            var audit_record = _employee_document_details_audit_record_builder
                                    .build(new NewEmployeeDocumentsDetailsAuditModelRequest(
                                                name: _event_to_handle.name,
                                                description: _event_to_handle.description,
                                                received_at: _received_at)
                                        )
                                    ;

            _audit_trail
                .document_details_audit
                .Add(audit_record)
                ;

            return this;
        }

        private void commit()
        {
            _unit_of_work.Commit();
        }

        public AddDocumentDetailsAuditRecordWhenDocumentIsRemoved(GetOrCreateEmployeeAuditTrail<EmployeeDocumentRemovedEvent> the_get_or_create_employee_audit_trail,
                                                                EmployeeAuditRecordBuilder<EmployeeDocumentRemovedEvent> the_employee_audit_record_builder,
                                                                EmployeeDocumentDetailsAuditRecordBuilder<EmployeeDocumentRemovedEvent> the_employee_document_details_audit_record_builder,
                                                                Clock the_clock,
                                                                IUnitOfWork the_unit_of_work
                                                               )
        {
            _get_or_create_employee_audit_trail = Guard.IsNotNull(the_get_or_create_employee_audit_trail,
                                                                    "the_get_or_create_employee_audit_trail"
                                                                 );
            _employee_audit_record_builder = Guard.IsNotNull(the_employee_audit_record_builder,
                                                            "the_employee_audit_record_builder"
                                                            );
            _employee_document_details_audit_record_builder = Guard.IsNotNull(the_employee_document_details_audit_record_builder,
                                                                            "the_employee_document_details_audit_record_builder"
                                                                            );
            _clock = Guard.IsNotNull(the_clock, "the_clock");
            _unit_of_work = Guard.IsNotNull(the_unit_of_work, "the_unit_of_work");
        }

        private readonly GetOrCreateEmployeeAuditTrail<EmployeeDocumentRemovedEvent> _get_or_create_employee_audit_trail;
        private readonly EmployeeAuditRecordBuilder<EmployeeDocumentRemovedEvent> _employee_audit_record_builder;
        private readonly EmployeeDocumentDetailsAuditRecordBuilder<EmployeeDocumentRemovedEvent> _employee_document_details_audit_record_builder;
        private readonly Clock _clock;
        private readonly IUnitOfWork _unit_of_work;

        private EmployeeDocumentRemovedEvent _event_to_handle;
        private UtcTime _received_at;
        private EmployeeAuditTrail _audit_trail;
    }
}