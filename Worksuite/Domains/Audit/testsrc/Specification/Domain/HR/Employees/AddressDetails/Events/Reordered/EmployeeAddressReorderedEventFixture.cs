using System;
using System.Linq;
using WorkSuite.Library.Service.Specification.Helpers.Persistence;
using WorkSuite.Library.Service.Specification.Helpers.Time.Clocks;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.Audit.Helpers.Domain.HR.Employees;
using WTS.WorkSuite.Audit.HR.Employees;
using WTS.WorkSuite.Audit.HR.Employees.Address;
using WTS.WorkSuite.Core.DomainIdentity;
using WTS.WorkSuite.HR.HR.Employees;
using WTS.WorkSuite.HR.HR.Employees.Addresses.Events;
using WTS.WorkSuite.HR.HR.Employees.Addresses.New;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Audit.Domain.HR.Employees.AddressDetails.Events.Reordered
{
    public class EmployeeAddressReorderedEventFixture
    {
        public EmployeeAddressAutoReorderedEvent create_event()
        {
            // create an audit trail for because an audit trail should have
            // been created when the employee was created.
            var audit_trail = new EmployeeAuditTrail
                                    {
                                        employee_id = (new Random()).Next(),
                                        employee_reference = DateTime.Now.ToString(),
                                        forename = "Manoj",
                                        surname = "John"
                                    };

            _employee_repository.add(audit_trail);

            return new EmployeeAddressAutoReorderedEvent
                            {
                                employee_id = audit_trail.employee_id,
                                address_id = (new Random()).Next(),
                                number_or_name = "number one",
                                line_one = "Street one",
                                line_two = "suburb one",
                                line_three = "district one",
                                county = "county one",
                                country = "country one",
                                postcode = "code1",
                                priority = 2
                            };
        }

        public Maybe<EmployeeAddressDetailsAuditRecord> get_last_address_details_audit_record_for(AddressIdentity the_address)
        {
            return this
                .get_employee_audit_trail_for(new EmployeeIdentity { employee_id = the_address.employee_id })
                .Match(

                    has_value:
                        audit_trail =>
                        {
                            var audit_record = audit_trail
                                                    .address_details_audit
                                                    .SingleOrDefault(a => a.address_id == the_address.address_id)
                                                    ;

                            return audit_record != null
                                        ? new Just<EmployeeAddressDetailsAuditRecord>(audit_record) as Maybe<EmployeeAddressDetailsAuditRecord>
                                        : new Nothing<EmployeeAddressDetailsAuditRecord>()
                                        ;
                        },

                    nothing:
                        () => (new Nothing<EmployeeAddressDetailsAuditRecord>() as Maybe<EmployeeAddressDetailsAuditRecord>)

                );
        }

        public Maybe<EmployeeAuditTrail> get_employee_audit_trail_for(EmployeeIdentity the_employee)
        {
            var audit_trail = _employee_repository
                                    .Entities
                                    .SingleOrDefault(e => e.employee_id == the_employee.employee_id)
                                    ;

            return audit_trail != null
                        ? new Just<EmployeeAuditTrail>(audit_trail) as Maybe<EmployeeAuditTrail>
                        : new Nothing<EmployeeAuditTrail>()
                        ;
        }

        public bool changes_were_committed()
        {
            return _unit_of_work.commit_was_called;
        }

        public void clear_all_audit_trails()
        {
            _employee_repository.clear();
        }

        public AddAddressDetailsAuditRecordWhenAddressIsAutomaticallyReordered event_handler { get; private set; }

        public FakeClock clock { get; private set; }

        public EmployeeAddressReorderedEventFixture()
        {
            event_handler = DependencyResolver.resolve<AddAddressDetailsAuditRecordWhenAddressIsAutomaticallyReordered>();
            clock = DependencyResolver.resolve<FakeClock>();

            _employee_repository = DependencyResolver.resolve<FakeEmployeeRepository>();
            _unit_of_work = DependencyResolver.resolve<FakeUnitOfWork>();
        }

        private readonly FakeEmployeeRepository _employee_repository;
        private readonly FakeUnitOfWork _unit_of_work;
    }
}