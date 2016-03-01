﻿using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.HR.Employees.EmployeeQualifications.Events;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Audit.Domain.HR.Employees.Qualifications.Events.Created
{
    [TestClass]
    public class Adding_an_employee_qualification_details
                    : EmployeeQualificationDetailsCreatedEventSpecification
    {
        [TestMethod]
        public void should_add_an_employee_qualification_details_audit_record_to_the_employee_audit_trail()
        {
            fixture.clear_all_audit_trails();

            var create_event = fixture.create_event();

            fixture.event_handler.handle(create_event);

            fixture
                .get_employee_audit_trail_for(create_event)
                .Match(

                    has_value:
                        audit_trail =>
                        {
                            audit_trail.qualification_details_audit.Count.Should().Be(1);
                            audit_trail.qualification_details_audit.Should()
                                .Contain(
                                    ad => ad.triggered_by_event == typeof(EmployeeQualificationCreatedEvent).Name &&
                                          fixture.clock.is_clock_time(ad.received_at)
                                );
                        },

                    nothing:
                        Assert.Fail

                );
        }

        [TestMethod]
        public void should_add_an_employee_qualification_details_created_audit_record_to_the_employee_audit_trail()
        {
            var create_event = fixture.create_event();

            fixture.event_handler.handle(create_event);

            fixture
                .get_last_qualification_details_audit_record_for(create_event)
                .Match(

                    has_value:
                        audit_record =>
                        {
                            audit_record.triggered_by_event.Should().Be(typeof(EmployeeQualificationCreatedEvent).Name);
                            fixture.clock.is_clock_time(audit_record.received_at);
                        },

                    nothing:
                        () => { Assert.Fail("Audit record not created."); }

                );
        }

        [TestMethod]
        public void should_commit_changes()
        {
            var create_event = fixture.create_event();

            fixture.event_handler.handle(create_event);

            fixture.changes_were_committed().Should().BeTrue();
        }
    }
}