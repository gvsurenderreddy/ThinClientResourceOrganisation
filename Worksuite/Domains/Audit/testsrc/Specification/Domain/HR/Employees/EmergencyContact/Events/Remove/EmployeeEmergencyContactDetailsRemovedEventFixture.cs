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

namespace WTS.WorkSuite.Audit.Domain.HR.Employees.EmergencyContact.Events.Remove
{
    public class  EmployeeEmergencyContactDetailsRemovedEventFixture
    {

        public EmployeeEmergencyContactDetailsRemoveEvent create_event()
        {
            var audit_trail = new EmployeeAuditTrail()
            {
                employee_id = (new Random().Next()),
                employee_reference = DateTime.Now.ToString(),
                forename = "Paul",
                surname = "Whittam"
            };

            employee_repository.add(audit_trail);
            return new EmployeeEmergencyContactDetailsRemoveEvent()
            {
                employee_id = audit_trail.employee_id,
                emergency_contact_id = (new Random().Next()),
                name = "fatemeh",
                primary_phone_number = "07922222222",
                other_phone_number = "08888888888",
                priority = 1
            };
        }

        public Maybe<EmergencyContactDetailsAuditRecord> get_last_emergency_contact_details_audit_record_for(EmergencyContactIdentity the_emergency_contact)
        {
            return this
                .get_employee_audit_trail_for(new EmployeeIdentity() {employee_id = the_emergency_contact.employee_id})
                .Match(
                has_value:
                    audit_trail =>
                    {
                        var audit_record = audit_trail
                            .emergency_contact_details_audit
                            .SingleOrDefault(e => e.id == the_emergency_contact.emergency_contact_id);

                        return audit_record != null
                            ? new Just<EmergencyContactDetailsAuditRecord>(audit_record) as Maybe<EmergencyContactDetailsAuditRecord> 
                            : new Nothing<EmergencyContactDetailsAuditRecord>();
                    },

                    nothing:
                    () => (new Nothing<EmergencyContactDetailsAuditRecord>() as Maybe<EmergencyContactDetailsAuditRecord>)

                );
        }

        public Maybe<EmployeeAuditTrail> get_employee_audit_trail_for(EmployeeIdentity the_employee_identity)
        {
            var audit_trail = employee_repository
                             .Entities
                             .SingleOrDefault(e => e.employee_id == the_employee_identity.employee_id);
            return audit_trail != null
                ? new Just<EmployeeAuditTrail>(audit_trail) as Maybe<EmployeeAuditTrail>
                : new Nothing<EmployeeAuditTrail>();
        }

        public bool changes_were_committed()
        {
            return unit_of_work.commit_was_called;
        }

        public void clear_all_audit_trails()
        {
            employee_repository.clear();
        }

        public AddEmergencyContactDetailsAuditRecordWhenEmergencyContactIsRemoved event_handler { get; private set; }
        public FakeClock clock { get; private set; }

        public EmployeeEmergencyContactDetailsRemovedEventFixture()
        {
            clock = DependencyResolver.resolve<FakeClock>();
            unit_of_work = DependencyResolver.resolve<FakeUnitOfWork>();
            employee_repository = DependencyResolver.resolve<FakeEmployeeRepository>();
            event_handler = DependencyResolver.resolve<AddEmergencyContactDetailsAuditRecordWhenEmergencyContactIsRemoved>();
            
        }

        private readonly FakeUnitOfWork unit_of_work;
        private readonly FakeEmployeeRepository employee_repository;
    }
}