﻿using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.Audit.Domain.HR.Employees.AddressDetails.Events.Created;
using WTS.WorkSuite.Audit.Domain.HR.Employees.AddressDetails.Events.Removed;
using WTS.WorkSuite.Audit.Domain.HR.Employees.AddressDetails.Events.Updated;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Audit.Domain.HR.Employees.AddressDetails.Fields.priority
{
    public class Priority_is_audited_in_the_address_details_audit_record
    {
        [TestClass]
        public class On_create_an_address
                        : EmployeeAddressDetailsCreatedEventSpecification
        {
            [TestMethod]
            public void should_write_priority_with_the_input_value_to_the_employee_address_details_audit_record()
            {
                var create_event = fixture.create_event();

                fixture.event_handler.handle(create_event);

                fixture
                    .get_last_address_details_audit_record_for(create_event)
                    .Match(

                        has_value:
                            audit_record => audit_record.priority.Should().Be(create_event.priority),

                        nothing:
                            () => { Assert.Fail(""); }
                    );
            }

            [TestClass]
            public class On_update_address_details
                            : EmployeeAddressDetailsUpdatedEventSpecification
            {
                [TestMethod]
                public void should_write_priority_with_the_un_updated_value_to_the_employee_address_details_audit_record()
                {
                    var update_event = fixture.create_event();

                    fixture.event_handler.handle(update_event);

                    fixture
                        .get_last_address_details_audit_record_for(update_event)
                        .Match(

                            has_value:
                                audit_record => audit_record.priority.Should().Be(update_event.priority),

                            nothing:
                                () => { Assert.Fail("Audit record not found."); }
                        );
                }
            }

            [TestClass]
            public class On_remove_address_details
                            : EmployeeAddressDetailsRemovedEventSpecification
            {
                [TestMethod]
                public void should_write_priority_with_the_value_when_the_address_was_removed_to_the_employee_address_details_audit_record()
                {
                    var remove_event = fixture.create_event();

                    fixture.event_handler.handle(remove_event);

                    fixture
                        .get_last_employee_address_details_audit_record_for(remove_event)
                        .Match(

                            has_value:
                                audit_record => audit_record.priority.Should().Be(remove_event.priority),

                            nothing:
                                () => { Assert.Fail("Audit record not found."); }
                        );
                }
            }
        }
    }
}