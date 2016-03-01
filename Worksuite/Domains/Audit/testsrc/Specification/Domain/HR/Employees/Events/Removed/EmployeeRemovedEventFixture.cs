using System;
using System.Linq;
using System.Threading;
using WorkSuite.Library.Service.Specification.Helpers.Persistence;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.Audit.Helpers.Domain.HR.Employees;
using WTS.WorkSuite.Audit.HR.Employees;
using WTS.WorkSuite.Core.DomainIdentity;
using WTS.WorkSuite.HR.HR.Employees;
using WTS.WorkSuite.HR.HR.Employees.Events;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Audit.Domain.HR.Employees.Events.Removed {

    public class EmployeeRemovedEventFixture {

        public EmployeeAuditTrail oreiginal_audit_trail {

            get {

                if (audit_trail_ == null) {

                    audit_trail_ = new EmployeeAuditTrail() {
                        employee_id = (new Random()).Next(),
                        employee_reference = DateTime.Now.ToString(),
                        forename = "Fred",
                        surname = "Smith",
                    };
                    employee_repository.add( oreiginal_audit_trail );

                }
                return audit_trail_;
            }
        }

        public EmployeeRemovedEvent create_event () {

            return new EmployeeRemovedEvent {
                employee_id = oreiginal_audit_trail.employee_id, 
            };
        }

        public WipeEmployeesAuditTrailWhenRemoved event_handler { get; private set; }


        public Maybe<EmployeeAuditTrail> get_employee_audit_trail_for
                                            ( EmployeeIdentity for_employee ) {
            
            var audit_trail = employee_repository
                .Entities
                .SingleOrDefault( at => at.employee_id == for_employee.employee_id )
                ;

            return audit_trail != null
                ? new Just<EmployeeAuditTrail>( audit_trail ) as Maybe<EmployeeAuditTrail>
                : new Nothing<EmployeeAuditTrail>()
                ;
        }


        public bool changes_were_committed () {
            return unit_of_work.commit_was_called;
        }

        public void clear_all_audit_trails () {
            employee_repository.clear();
        }


        public EmployeeRemovedEventFixture ( ) {
            event_handler = DependencyResolver.resolve<WipeEmployeesAuditTrailWhenRemoved>();

            employee_repository = DependencyResolver.resolve<FakeEmployeeRepository>();
            unit_of_work = DependencyResolver.resolve<FakeUnitOfWork>(  );            
        }


        private readonly FakeEmployeeRepository employee_repository;
        private readonly FakeUnitOfWork unit_of_work;

        private EmployeeAuditTrail audit_trail_;
    }
}