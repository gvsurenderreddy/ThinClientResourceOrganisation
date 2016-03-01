using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WTS.WorkSuite.Audit.Domain.HR.Employees.Events.Created;
using WTS.WorkSuite.Audit.Domain.HR.Employees.PersonalDetails.Events.Updated;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Audit.Domain.HR.Employees.PersonalDetails.Fields.forename
{
    public class forename_is_audited
    {
        // done: forename is used for identification
        // done: forename is audited in the employee personal details

        public class in_the_employee_record_for_identification_purposes
        {
            [TestClass]
            public class on_employee_created
                            : EmployeeCreatedEventSpecification
            {
                [TestMethod]
                public void the_forename_is_witten_to_the_employee_audit_recdord()
                {
                    var created_event = fixture.create_event();

                    fixture.event_handler.handle(created_event);

                    fixture
                        .get_employee_audit_trail_for(created_event)
                        .Match(

                            has_value:
                                employee_audit => employee_audit.forename.Should().Be(created_event.forename),

                            nothing:
                                () => { Assert.Fail(); } // Could not find audit trail for the event
                        );
                }
            }

            [TestClass]
            public class on_personal_details_updated
                            : EmployeePersonalDetailsUpdatedEventSpecification
            {
                // done: when an personal details updated event is received
                // done: when an employee audit trail is created from an personal details updated event

                [TestMethod]
                public void when_an_personal_details_updated_event_is_received()
                {
                    var update_event = fixture.create_event();
                    update_event.forename = update_event.forename + DateTime.Now.ToLongDateString();

                    fixture.event_handler.handle(update_event);

                    fixture
                        .get_employee_audit_trail_for(update_event)
                        .Match(

                            has_value:
                                audit_trail => { audit_trail.forename.Should().Be(update_event.forename); },

                            nothing:
                                () => { Assert.Fail("Audit trail not found"); }

                        );
                }

                [TestMethod]
                public void when_an_employee_audit_trail_is_created_from_an_personal_details_updated_event()
                {
                    var update_event = fixture.create_event();
                    update_event.forename = update_event.forename + DateTime.Now.ToLongDateString();

                    fixture.clear_all_audit_trails();

                    fixture.event_handler.handle(update_event);

                    fixture
                        .get_employee_audit_trail_for(update_event)
                        .Match(

                            has_value:
                                audit_trail => audit_trail.forename.Should().Be(update_event.forename),

                            nothing:
                                () => { Assert.Fail("Audit trail not found."); }
                        );
                }
            }
        }

        public class in_the_personal_details_audit_record
        {
            [TestClass]
            public class on_create_employee
                            : EmployeeCreatedEventSpecification
            {
                [TestMethod]
                public void the_forename_is_written_to_the_employee_personal_details_audit_record()
                {
                    var create_event = fixture.create_event();

                    fixture.event_handler.handle(create_event);

                    fixture
                        .get_last_personal_details_audit_record_for(create_event)
                        .Match(

                            has_value:
                                audit_record => audit_record.forename.Should().Be(create_event.forename),

                            nothing:
                                () => { Assert.Fail(""); }
                        );
                }
            }

            [TestClass]
            public class on_personal_details_updated
                            : EmployeePersonalDetailsUpdatedEventSpecification
            {
                [TestMethod]
                public void the_forename_is_written_to_the_employee_personal_details_audit_record()
                {
                    var update_event = fixture.create_event();

                    fixture.event_handler.handle(update_event);

                    fixture
                        .get_last_personal_details_audit_record_for(update_event)
                        .Match(

                            has_value:
                                audit_record => { audit_record.forename.Should().Be(update_event.forename); },

                            nothing:
                                () => { Assert.Fail("Audit record not found"); }
                        );
                }
            }
        }
    }
}