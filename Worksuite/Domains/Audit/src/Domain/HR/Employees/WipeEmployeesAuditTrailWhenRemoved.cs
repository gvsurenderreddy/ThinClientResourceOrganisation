using System.Linq;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Audit.HR.Employees.AggregateRoot;
using WTS.WorkSuite.HR.HR.Employees.Events;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral.Events;
using WTS.WorkSuite.Library.DomainTypes.Time.Clocks;

namespace WTS.WorkSuite.Audit.HR.Employees
{
    public class WipeEmployeesAuditTrailWhenRemoved
                    : IEventSubscriber<EmployeeRemovedEvent>
    {
        public void handle
                        (EmployeeRemovedEvent the_event_to_handle)
        {
            // We have to wipe the employees existing audit trail but we will leave a record to show that
            // the employee was in the system at one point in time
            var received_at = clock.now();

            var audit_trail = get_or_create_audit_trail.execute(new GetOrCreateEmployeeAuditTrailRequest(
                employee_id: the_event_to_handle.employee_id,
                received_at: received_at
            ));

            var wiped_audit_trail = employee_audit_trail_builder.build(new NewEmployeeAuditTrailRequest(
                employee_id: audit_trail.employee_id,
                forename: audit_trail.forename,
                surname: audit_trail.surname,
                employee_reference: audit_trail.employee_reference,
                received_at: received_at
            ));

            employee_repository.remove(audit_trail);
            employee_repository.add(wiped_audit_trail);

            unit_of_work.Commit();
        }

        public WipeEmployeesAuditTrailWhenRemoved
                    (IEntityRepository<EmployeeAuditTrail> the_employee_repository
                    , GetOrCreateEmployeeAuditTrail<EmployeeRemovedEvent> get_or_create_audit_trail_command
                    , EmployeeAuditTrailBuilder<EmployeeRemovedEvent> the_employee_audit_trail_builder
                    , Clock the_clock
                    , IUnitOfWork the_unit_of_work)
        {
            employee_repository = Guard.IsNotNull(the_employee_repository, "the_employee_repository");
            get_or_create_audit_trail = Guard.IsNotNull(get_or_create_audit_trail_command, "get_or_create_audit_trail_command");
            employee_audit_trail_builder = Guard.IsNotNull(the_employee_audit_trail_builder, "the_employee_audit_trail_builder");
            clock = Guard.IsNotNull(the_clock, "the_clock");
            unit_of_work = Guard.IsNotNull(the_unit_of_work, "the_unit_of_work");
        }

        private readonly IEntityRepository<EmployeeAuditTrail> employee_repository;
        private readonly GetOrCreateEmployeeAuditTrail<EmployeeRemovedEvent> get_or_create_audit_trail;
        private readonly EmployeeAuditTrailBuilder<EmployeeRemovedEvent> employee_audit_trail_builder;
        private readonly Clock clock;
        private readonly IUnitOfWork unit_of_work;
    }
}