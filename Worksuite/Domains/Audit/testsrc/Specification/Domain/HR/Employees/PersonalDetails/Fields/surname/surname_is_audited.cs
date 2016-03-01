using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WTS.WorkSuite.Audit.Domain.HR.Employees.Events.Created;
using WTS.WorkSuite.Audit.Domain.HR.Employees.PersonalDetails.Events.Updated;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Audit.Domain.HR.Employees.PersonalDetails.Fields.surname
{
    public class surname_is_audited
    {
        // done: surname is used from identification
        // done: surname is audited in the employee personal details

        public class in_the_employee_record_for_identification_purposes
        {
            [TestClass]
            public class on_employee_created
                            : EmployeeCreatedEventSpecification
            {
                [TestMethod]
                public void the_surname_is_written_to_the_employee_audit_record()
                {
                    var create_event = fixture.create_event();

                    fixture.event_handler.handle(create_event);

                    fixture
                        .get_employee_audit_trail_for(create_event)
                        .Match(

                            has_value:
                                audit_trail => audit_trail.surname.Should().Be(create_event.surname),

                            nothing:
                                () => { Assert.Fail("Audit trail not found."); }

                        );
                }
            }

            [TestClass]
            public class on_update_personal_detials
                            : EmployeePersonalDetailsUpdatedEventSpecification
            {
                [TestMethod]
                public void the_surname_is_updated_of_the_employee_audit_record_exists()
                {
                    var update_event = fixture.create_event();
                    update_event.surname = update_event.surname + DateTime.Now.ToLongDateString();

                    fixture.event_handler.handle(update_event);

                    fixture
                        .get_employee_audit_trail_for(update_event)
                        .Match(

                            has_value:
                                audit_trail => { audit_trail.surname.Should().Be(update_event.surname); },

                            nothing:
                                () => { Assert.Fail("Audit trail not found."); }
                        );
                }

                [TestMethod]
                public void the_surname_is_writen_to_the_employee_audit_record_if_it_is_created_from_an_updated()
                {
                    var update_event = fixture.create_event();
                    update_event.surname = update_event.surname + DateTime.Now.ToLongDateString();

                    fixture.clear_all_audit_trails();

                    fixture.event_handler.handle(update_event);

                    fixture
                        .get_employee_audit_trail_for(update_event)
                        .Match(

                            has_value:
                                audit_trail => { audit_trail.surname.Should().Be(update_event.surname); },

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
                public void the_surname_is_written_to_the_employee_personal_details_audit_record()
                {
                    var create_event = fixture.create_event();

                    fixture.event_handler.handle(create_event);

                    fixture
                        .get_last_personal_details_audit_record_for(create_event)
                        .Match(

                            has_value:
                                audit_record => audit_record.surname.Should().Be(create_event.surname),

                            nothing:
                                () => { Assert.Fail(""); }
                        );
                }
            }

            [TestClass]
            public class on_update_personal_detials
                            : EmployeePersonalDetailsUpdatedEventSpecification
            {
                [TestMethod]
                public void the_surname_is_written_to_the_employee_personal_details_audit_record()
                {
                    var update_event = fixture.create_event();

                    fixture.event_handler.handle(update_event);

                    fixture
                        .get_last_personal_details_audit_record_for(update_event)
                        .Match(

                            has_value:
                                audit_record => { audit_record.surname.Should().Be(update_event.surname); },

                            nothing:
                                () => { Assert.Fail("Audit record not found"); }
                        );
                }
            }
        }
    }
}