using System;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Audit.HR.Employees.AggregateRoot;
using WTS.WorkSuite.HR.HR.Employees.Events;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral.Events;
using WTS.WorkSuite.Library.DomainTypes.Time.Clocks;

namespace WTS.WorkSuite.Audit.HR.Employees
{
    /// <summary>
    ///     Starts an employee audit trail when a new employee
    /// is created
    /// </summary>
    public class CreateEmployeeAuditTrailWhenEmployeeCreated
                    : IEventSubscriber<EmployeeCreatedEvent>
    {
        /// <summary>
        ///     Create new employee audit trail, attach an employee personal details
        /// audit record (the forename and surname are set in a new request)
        /// and an employee employment details audit record (the employee ref is set in a new request) to
        /// the new employee audit trail.
        /// </summary>
        /// <param name="the_event_to_handle">
        ///     Event that the audit information is taken from.
        /// </param>
        public void handle
                        (EmployeeCreatedEvent the_event_to_handle)
        {
            this
                .set_event(the_event_to_handle)
                .create_employee_audit_trail()
                .create_employee_personal_details_audit_record()
                .create_employee_employment_details_audit_record()
                .create_employee_contact_details_audit_record()
                .commit()
                ;
        }

        public CreateEmployeeAuditTrailWhenEmployeeCreated
                (IEntityRepository<EmployeeAuditTrail> the_employee_repository
                , EmployeeAuditTrailBuilder<EmployeeCreatedEvent> the_audit_trail_builder
                , EmployeePersonalDetailsAuditRecordBuilder<EmployeeCreatedEvent> the_personal_details_audit_record_builder
                , EmployeeEmploymentDetailsAuditRecordBuilder<EmployeeCreatedEvent> the_employment_details_audit_redord_builder
                , EmployeeContactDetailsAuditRecordBuilder<EmployeeCreatedEvent> the_contact_details_audit_record_builder
                , Clock the_clock
                , IUnitOfWork the_unit_of_work)
        {
            employee_repository = Guard.IsNotNull(the_employee_repository, "the_employee_repository ");
            audit_trail_builder = Guard.IsNotNull(the_audit_trail_builder, "the_audit_trail_builder");
            personal_details_audit_record_builder = Guard.IsNotNull(the_personal_details_audit_record_builder, "the_personal_details_audit_record_builder");
            employment_details_audit_redord_builder = Guard.IsNotNull(the_employment_details_audit_redord_builder, "the_employment_details_audit_redord_builder");
            _contact_details_audit_record_builder = Guard.IsNotNull(the_contact_details_audit_record_builder, "the_contact_details_audit_record_builder");
            clock = Guard.IsNotNull(the_clock, "the_clock");
            unit_of_work = Guard.IsNotNull(the_unit_of_work, "the_unit_of_work");
        }

        private CreateEmployeeAuditTrailWhenEmployeeCreated set_event
                                                                (EmployeeCreatedEvent the_event_to_handle)
        {
            event_to_handle = Guard.IsNotNull(the_event_to_handle, "the_event_to_handle");
            received_at = clock.now();
            return this;
        }

        private CreateEmployeeAuditTrailWhenEmployeeCreated create_employee_audit_trail()
        {
            Guard.IsNotNull(event_to_handle, "event_to_handle");

            audit_trail = audit_trail_builder.build(new NewEmployeeAuditTrailRequest(
                employee_id: event_to_handle.employee_id,
                employee_reference: event_to_handle.employee_reference,
                forename: event_to_handle.forename,
                surname: event_to_handle.surname,
                received_at: received_at
            ));
            return this;
        }

        private CreateEmployeeAuditTrailWhenEmployeeCreated create_employee_personal_details_audit_record()
        {
            Guard.IsNotNull(event_to_handle, "event_to_handle");
            Guard.IsNotNull(audit_trail, "employee");
            Guard.IsNotNull(received_at, "received_at");

            var audit_record = personal_details_audit_record_builder.build(new NewEmployeePersonalDetailsAuditModelRequest(
                forename: event_to_handle.forename,
                surname: event_to_handle.surname,
                othername: Not_specified_string_value,
                place_of_birth: Not_specified_string_value,
                date_of_birth: Not_specified_date_time_value,
                title_id: Not_specified_integer_value,
                title_description: Not_specified_string_value,
                gender_id: Not_specified_integer_value,
                gender_description: Not_specified_string_value,
                marital_status_id: Not_specified_integer_value,
                marital_status_description: Not_specified_string_value,
                nationality_id: Not_specified_integer_value,
                nationality_description: Not_specified_string_value,
                ethnic_origin_id: Not_specified_integer_value,
                ethnic_origin_description: Not_specified_string_value,
                received_at: received_at
            ));

            audit_trail
                .personal_details_audit
                .Add(audit_record)
                ;
            return this;
        }

        public CreateEmployeeAuditTrailWhenEmployeeCreated create_employee_contact_details_audit_record()
        {
            Guard.IsNotNull(event_to_handle, "event_to_handle");
            Guard.IsNotNull(audit_trail, "audit_trail");
            Guard.IsNotNull(received_at, "received_at");

            var audit_record = _contact_details_audit_record_builder
                                    .build(new NewEmployeeContactDetailsAuditModelRequest
                                                (phone_number: Not_specified_string_value,
                                                email: Not_specified_string_value,
                                                mobile: Not_specified_string_value,
                                                other: Not_specified_string_value,
                                                 received_at: received_at
                                                )
                                          )
                                    ;

            audit_trail
                .contact_details_audit
                .Add(audit_record)
                ;

            return this;
        }

        private CreateEmployeeAuditTrailWhenEmployeeCreated create_employee_employment_details_audit_record()
        {
            Guard.IsNotNull(event_to_handle, "event_to_handle");
            Guard.IsNotNull(audit_trail, "employee");
            Guard.IsNotNull(received_at, "received_at");

            var audit_record = employment_details_audit_redord_builder.build(new NewEmployeeEmploymentDetailsAuditModelRequest(
                employee_reference: event_to_handle.employee_reference,
                job_title_id: Not_specified_integer_value,
                job_title_description: Not_specified_string_value,
                location_id: Not_specified_integer_value,
                location_description: Not_specified_string_value,
                received_at: received_at
            ));

            audit_trail
                .employment_details_audit
                .Add(audit_record)
                ;
            return this;
        }

        private void commit()
        {
            Guard.IsNotNull(audit_trail, "employee");

            employee_repository.add(audit_trail);
            unit_of_work.Commit();
        }

        private readonly IEntityRepository<EmployeeAuditTrail> employee_repository;
        private readonly EmployeeAuditTrailBuilder<EmployeeCreatedEvent> audit_trail_builder;
        private readonly EmployeePersonalDetailsAuditRecordBuilder<EmployeeCreatedEvent> personal_details_audit_record_builder;
        private readonly EmployeeContactDetailsAuditRecordBuilder<EmployeeCreatedEvent> _contact_details_audit_record_builder;
        private readonly EmployeeEmploymentDetailsAuditRecordBuilder<EmployeeCreatedEvent> employment_details_audit_redord_builder;
        private readonly Clock clock;
        private readonly IUnitOfWork unit_of_work;

        private EmployeeCreatedEvent event_to_handle;
        private UtcTime received_at;
        private EmployeeAuditTrail audit_trail;
        private const string Not_specified_string_value = null;
        private readonly int? Not_specified_integer_value = new int?();
        private readonly DateTime? Not_specified_date_time_value = new DateTime?();
    }
}