using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using WTS.WorkSuite.Audit.Domain.HR.Employees.EmploymentDetails.Events.Updated;
using WTS.WorkSuite.Audit.Domain.HR.Employees.Events.Created;
using WTS.WorkSuite.HR.HR.Employees.Events;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Audit.Domain.HR.Employees.EmploymentDetails.Fields.employee_reference
{
    public class employee_reference_is_audited
    {
        // in the employee record for identification purpose
        //    done: on create
        //    on update

        public class in_the_employee_record_for_identification_purposes
        {
            [TestClass]
            public class on_employee_created
                            : EmployeeCreatedEventSpecification
            {
                [TestMethod]
                public void the_employee_reference_is_witten_to_the_employee_audit_recdord()
                {
                    var created_event = fixture.create_event();

                    fixture.event_handler.handle(created_event);

                    fixture
                        .get_employee_audit_trail_for(created_event)
                        .Match(

                            has_value:
                                employee_audit => employee_audit.employee_reference.Should().Be(created_event.employee_reference),

                            nothing:
                                () => { Assert.Fail(); } // Could not find audit trail for the event
                        );
                }
            }

            [TestClass]
            public class on_employment_details_updated
                            : EmployeeEmploymentDetailsUpdatedEventSpecification
            {
                // done: when an employment details updated event is received
                // done: when an employee audit trail is created from an employment details updated event

                [TestMethod]
                public void the_employee_reference_used_for_adudit_trail_identification_is_updated()
                {
                    var update_event = fixture.create_event();
                    update_event.employee_reference += DateTime.Now.ToLongDateString();

                    fixture.event_handler.handle(update_event);

                    fixture
                        .get_employee_audit_trail_for(update_event)
                        .Match(

                            has_value:
                                audit_trail => audit_trail.employee_reference.Should().Be(update_event.employee_reference),

                            nothing:
                                () => { Assert.Fail("Audit trail not found."); }
                        );
                }

                [TestMethod]
                public void the_employee_reference_used_for_adudit_trail_identification_is_set_if_created()
                {
                    var update_event = fixture.create_event();

                    fixture.clear_all_audit_trails();

                    fixture.event_handler.handle(update_event);

                    fixture
                        .get_employee_audit_trail_for(update_event)
                        .Match(

                            has_value:
                                audit_trail => audit_trail.employee_reference.Should().Be(update_event.employee_reference),

                            nothing:
                                () => { Assert.Fail("Audit trail not found"); }
                        );
                }
            }
        }

        public class in_the_employment_details_audit_record
        {
            [TestClass]
            public class on_employee_created
                            : EmployeeCreatedEventSpecification
            {
                [TestMethod]
                public void the_employee_reference_is_recorded_an_employment_details_audit_record()
                {
                    var created_event = fixture.create_event();

                    fixture.event_handler.handle(created_event);

                    // Improve: when the personal details event is introduced there will be a method that gives us

                    fixture
                        .get_employee_audit_trail_for(created_event)
                        .Match(

                            has_value:
                                employee_audit => employee_audit
                                                    .employment_details_audit
                                                    .Single(eda => eda.triggered_by_event == typeof(EmployeeCreatedEvent).Name)
                                                    .employee_reference.Should().Be(created_event.employee_reference),

                            nothing:
                                () => { Assert.Fail(); }
                        );
                }
            }

            [TestClass]
            public class on_employment_details_updated
                            : EmployeeEmploymentDetailsUpdatedEventSpecification
            {
                [TestMethod]
                public void the_employee_reference_state_change_is_recorded_in_the_emplopyees_audit_trail()
                {
                    var update_event = fixture.create_event();

                    fixture.event_handler.handle(update_event);

                    fixture
                        .get_last_employment_details_audit_record_for(update_event)
                        .Match(

                            has_value:
                                audit_record => audit_record.employee_reference.Should().Be(update_event.employee_reference),

                            nothing:
                                () => { Assert.Fail("Audit record not found."); }
                        );
                }
            }
        }
    }
}