using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.Core.DomainIdentity;
using WTS.WorkSuite.HR.HR.Employees;
using WTS.WorkSuite.HR.HR.Employees.Remove;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.Employees;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.Base;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.ForDomainLogic;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.Remove {


    public class remove_employee_will {
        
        [TestClass]
        public class RemoveEmployee_will_commit_changes 
                        : CommandCommitedChangesSpecification<EmployeeIdentity, RemoveResponse, RemoveEmployeeFixture> {

            [TestMethod]
            public void remove_the_employee()
            {
                fixture.execute_command();

                employee_repository.Entities.Select(e => e.id == fixture.request.employee_id).Should().BeEmpty();

            }

            [TestMethod]
            public void return_no_errors_if_the_entity_does_not_exist()
            {
                employee_repository.clear();

                fixture.execute_command();

                fixture.response.has_errors.Should().BeFalse();

            }


            protected override void test_setup() {
                base.test_setup();
                employee_repository = DependencyResolver.resolve<FakeEmployeeRepository>();
            }

            private FakeEmployeeRepository employee_repository;

        }


        [TestClass]
        public class RemoveEmployee_will_publish_an_employee_created_event
                        : HRResponseCommandSpecification<EmployeeIdentity, RemoveResponse, RemoveEmployeeFixture> {


            // done: publish an employee removed event if the employee was removed
            // done: not publish an employee remmoved event if the employee was not removed

            [TestMethod]
            public void publish_an_employee_removed_event_if_the_employee_was_removed () {

                var request = fixture.request;

                fixture.execute_command();

                fixture.published_events.Should().Contain( e => e.employee_id == request.employee_id );
            }


            [TestMethod]
            public void not_publish_an_employee_remmoved_event_if_the_employee_had_already_been_removed () {
                var request = fixture.request;

                fixture.clear_all_employees();
                fixture.execute_command();

                fixture.published_events.Should().NotContain( e => e.employee_id == request.employee_id );
            }

        }

    }

}
