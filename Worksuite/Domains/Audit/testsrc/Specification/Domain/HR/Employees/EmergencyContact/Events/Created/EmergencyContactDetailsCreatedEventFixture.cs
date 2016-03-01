using System;
using System.Linq;
using WorkSuite.Library.Service.Specification.Helpers.Persistence;
using WorkSuite.Library.Service.Specification.Helpers.Time.Clocks;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.Audit.Helpers.Domain.HR.Employees;
using WTS.WorkSuite.Audit.HR.Employees;
using WTS.WorkSuite.Audit.HR.Employees.EmergencyContact;
using WTS.WorkSuite.Core.DomainIdentity;
using WTS.WorkSuite.HR.HR.Employees;
using WTS.WorkSuite.HR.HR.Employees.EmergencyContacts;
using WTS.WorkSuite.HR.HR.Employees.EmergencyContacts.Events;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Audit.Domain.HR.Employees.EmergencyContact.Events.Created
{
    public class EmergencyContactDetailsCreatedEventFixture
    {

        public EmployeeEmergencyContactDetailsCreateEvent create_event()
        {
            var audit_trail = new EmployeeAuditTrail()
                                  {
                                     employee_id = (new Random().Next()),
                                     employee_reference = DateTime.Now.ToString(),
                                     forename = "fatemeh",
                                     surname = "seifipour"
                                     
                                  };
            employee_repository.add(audit_trail);

            return new EmployeeEmergencyContactDetailsCreateEvent()
                                  {
                                    employee_id = audit_trail.employee_id,
                                    emergency_contact_id = (new Random()).Next(),
                                    name = "Fatemeh",
                                    relationship_id = 2,
                                    primary_phone_number = "07955487548",
                                    other_phone_number = "04585789645",
                                    priority = 1
                                  };
        }

        public Maybe<EmergencyContactDetailsAuditRecord> get_last_emergency_contact_details_audit_record_for
                                                                                        ( EmergencyContactIdentity the_emergency_contact_identity )
        {
            return this
                .get_employee_audit_trail_for(new EmployeeIdentity() { employee_id = the_emergency_contact_identity.employee_id })
                .Match(
                       has_value:
                            audit_trail =>
                            {
                                var audit_record =
                                    audit_trail.emergency_contact_details_audit.SingleOrDefault(a => a.id == the_emergency_contact_identity.emergency_contact_id);
                                return audit_record != null
                                    ? new Just<EmergencyContactDetailsAuditRecord>(audit_record) as Maybe<EmergencyContactDetailsAuditRecord>
                                    : new Nothing<EmergencyContactDetailsAuditRecord>();
                            },
                       
                       nothing:
                           () => (new Nothing<EmergencyContactDetailsAuditRecord>() as Maybe<EmergencyContactDetailsAuditRecord>)
                );

        }

        public Maybe<EmployeeAuditTrail> get_employee_audit_trail_for
                                                         (EmployeeIdentity employee_identity)
        {
            var audit_trail = employee_repository
                                      .Entities
                                      .SingleOrDefault(e => e.employee_id == employee_identity.employee_id);

            return audit_trail != null
                            ? new Just<EmployeeAuditTrail>(audit_trail) as Maybe<EmployeeAuditTrail>
                            : new Nothing<EmployeeAuditTrail>();
        }

        public bool changes_were_comited()
        {
            return unite_of_work.commit_was_called;
        }

        public void clear_all_audit_trails()
        {
            employee_repository.clear();
        }

        public EmergencyContactDetailsCreatedEventFixture()

        {
            fake_clock = DependencyResolver.resolve<FakeClock>();
            unite_of_work = DependencyResolver.resolve<FakeUnitOfWork>();
            employee_repository = DependencyResolver.resolve<FakeEmployeeRepository>();
            event_handler = DependencyResolver.resolve<AddEmergencyContactDetailsAuditRecordWhenContactIsCreated>();

        }

        public FakeClock fake_clock;
        private readonly FakeUnitOfWork unite_of_work;
        private readonly FakeEmployeeRepository employee_repository;
        public AddEmergencyContactDetailsAuditRecordWhenContactIsCreated event_handler { get; private set; }

    }
}