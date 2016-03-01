using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.HR.Employees.Events;

namespace WTS.WorkSuite.Audit.Domain.HR.Employees.Events.Created {

    [TestClass]
    public class Creates_an_employee_audit_trail 
                    : EmployeeCreatedEventSpecification {


        // done: employee audit row is added to the repository
        // done: changes are commited

        [TestMethod]
        public void employee_audit_trail_is_added_to_the_repository () {

            fixture.event_handler.handle( new EmployeeCreatedEvent () );

            fixture.all_employee_audit_trails.Count().Should().Be( 1 );
        }

        [TestMethod]
        public void changes_are_committed () {

            fixture.event_handler.handle( new EmployeeCreatedEvent() );

            fixture.changes_were_commited(  ).Should().BeTrue();
        }

    }
}