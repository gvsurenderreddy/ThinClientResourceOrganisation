﻿using System;
using System.Linq;
using WorkSuite.Library.Service.Specification.Helpers.Persistence;
using WorkSuite.Library.Service.Specification.Helpers.Time.Clocks;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.Audit.Helpers.Domain.HR.Employees;
using WTS.WorkSuite.Audit.HR.Employees;
using WTS.WorkSuite.Core.DomainIdentity;
using WTS.WorkSuite.HR.HR.Employees;
using WTS.WorkSuite.HR.HR.Employees.EmployeeImage.Events;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Audit.Domain.HR.Employees.ImageDetails.Events.Removed
{
    public class EmployeeImageDetailsRemovedEventFixture
    {
        public EmployeeImageDetailsRemovedEvent create_event()
        {
            // create an audit trail for because an audit trail should have
            // been created when the employee was created.
            var audit_trail = new EmployeeAuditTrail
            {
                employee_id = (new Random()).Next(),
                employee_reference = DateTime.Now.ToString(),
                forename = "Pallavi",
                surname = "Rathore"
            };
            _employee_repository.add(audit_trail);

            return new EmployeeImageDetailsRemovedEvent
                            {
                                employee_id = audit_trail.employee_id
                            };
        }

        public Maybe<EmployeeImageDetailsAuditRecord> get_last_image_details_audit_record_for(EmployeeIdentity the_employee)
        {
            return this
                .get_employee_audit_trail_for(new EmployeeIdentity { employee_id = the_employee.employee_id })
                .Match(

                    has_value:
                        audit_trail =>
                        {
                            var audit_record = audit_trail
                                                .image_details_audit
                                                .SingleOrDefault()
                                                ;

                            return audit_record != null
                                        ? new Just<EmployeeImageDetailsAuditRecord>(audit_record) as Maybe<EmployeeImageDetailsAuditRecord>
                                        : new Nothing<EmployeeImageDetailsAuditRecord>()
                                        ;
                        },

                    nothing:
                        () => (new Nothing<EmployeeImageDetailsAuditRecord>() as Maybe<EmployeeImageDetailsAuditRecord>)
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

        public AddImageDetailsAuditRecordWhenImageIsRemoved event_handler { get; private set; }

        public FakeClock clock { get; private set; }

        public EmployeeImageDetailsRemovedEventFixture()
        {
            event_handler = DependencyResolver.resolve<AddImageDetailsAuditRecordWhenImageIsRemoved>();
            clock = DependencyResolver.resolve<FakeClock>();

            _employee_repository = DependencyResolver.resolve<FakeEmployeeRepository>();
            _unit_of_work = DependencyResolver.resolve<FakeUnitOfWork>();
        }

        private readonly FakeEmployeeRepository _employee_repository;
        private readonly FakeUnitOfWork _unit_of_work;
    }
}