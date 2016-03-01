using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.Audit.HR.Employees;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Audit.Domain.HR.Employees.Events.Removed {

    [TestClass]
    public class Employees_audit_trail_is_wiped_when_removed 
                    : EmployeeRemovedEventSpecification {

        // done: personal details are wiped
        // done: employment details are wiped
        // done: identification details are maintained

        [TestMethod]
        public void personal_details_are_wiped () {
            // arrange
            var remove_event = fixture.create_event(  );

            fixture
                .get_employee_audit_trail_for( remove_event )
                .Match( 

                    has_value:
                        audit_trail => audit_trail.personal_details_audit.Add( new EmployeePersonalDetailsAuditRecord() ),

                    nothing:
                        () => Assert.Fail( "Audit trail not found." )                
                );

            // act
            fixture.event_handler.handle( remove_event );

            // assert 
            fixture
                .get_employee_audit_trail_for( remove_event )
                .Match(
                
                    has_value:
                        audit_trail => {

                            audit_trail.personal_details_audit.Should(  ).BeEmpty(  );
                            
                        },

                    nothing:
                        () => { Assert.Fail( "Audit trail not found"); }
                
                );
        }

        [TestMethod]
        public void employment_details_are_wiped () {
            // arrange
            var remove_event = fixture.create_event(  );

            fixture
                .get_employee_audit_trail_for( remove_event )
                .Match( 

                    has_value:
                        audit_trail => audit_trail.employment_details_audit.Add( new EmployeeEmploymentDetailsAuditRecord() ),

                    nothing:
                        () => Assert.Fail( "Audit trail not found." )                
                );

            // act
            fixture.event_handler.handle( remove_event );

            // assert 
            fixture
                .get_employee_audit_trail_for( remove_event )
                .Match(
                
                    has_value:
                        audit_trail => {

                            audit_trail.employment_details_audit.Should(  ).BeEmpty(  );
                            
                        },

                    nothing:
                        () => { Assert.Fail( "Audit trail not found"); }
                
                );
        }

        [TestMethod]
        public void forename_is_maintained () {
            // arrange
            var remove_event = fixture.create_event();

            // act
            fixture.event_handler.handle( remove_event );

            // assert
            fixture
                .get_employee_audit_trail_for( remove_event )
                .Match(

                    has_value:
                        audit_trail => audit_trail.forename.Should().Be( fixture.oreiginal_audit_trail.forename ),

                    nothing:
                        () => Assert.Fail( "Audit trail not found." )
                );
        }

        [TestMethod]
        public void surname_is_maintained () {
            var remove_event = fixture.create_event();
            
            fixture.event_handler.handle( remove_event );

            fixture
                .get_employee_audit_trail_for( remove_event )
                .Match(

                    has_value:
                        audit_trail => audit_trail.surname.Should().Be(  fixture.oreiginal_audit_trail.surname  ),

                    nothing:
                        () => Assert.Fail( "Audit trail not found.")
                );
        }

        [TestMethod]
        public void employee_reference_is_maintained () {

            var remove_event = fixture.create_event();

            fixture.event_handler.handle( remove_event );
           
            fixture
                .get_employee_audit_trail_for( remove_event )
                .Match(

                    has_value:
                        audit_trail => audit_trail.employee_reference.Should( ).Be( fixture.oreiginal_audit_trail.employee_reference ),

                    nothing:
                        () => Assert.Fail("Audit trail not found.")

                );
        }

        [TestMethod]
        public void changes_are_commited () {
            
            fixture.event_handler.handle( fixture.create_event() );

            fixture.changes_were_committed(  ).Should().BeTrue();

        }
    }

}