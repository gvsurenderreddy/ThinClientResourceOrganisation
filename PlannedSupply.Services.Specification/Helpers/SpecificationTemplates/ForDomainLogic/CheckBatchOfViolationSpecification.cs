using System;
using System.Linq;
using Content.Services.PlannedSupply.Messages;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Service.Specification.Helpers.Specifications.ForResponseCommands;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.DomainTypes.Duration;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.SpecificationTemplates.Base;

namespace WTS.WorkSuite.PlannedSupply.Services.Helpers.SpecificationTemplates.ForDomainLogic
{
        public class CheckBatchOfViolationSpecification<P, Q, F> : PlannedSupplyResponseCommandSpecification<P, Q, F>
            where Q : Response
            where F : IsAResponseCommandFixture<P, Q>
        {
            protected CheckBatchOfViolationSpecification(Action<P, DurationRequest, DurationRequest> set_field_by)
                : this(set_field_by, null) { }

            private CheckBatchOfViolationSpecification(Action<P, DurationRequest, DurationRequest> set_field_by, string the_expected_message)
            {
                set_field = set_field_by;
                expected_message = the_expected_message;
            }

            private Action<P, DurationRequest, DurationRequest> set_field { get; set; }
            private string expected_message { get; set; }

            [TestMethod]
            public void report_error_message_if_new_break_end_time_overlapped_with_old_break_start_time()
            {

                var off_set = new DurationRequest { hours = "0", minutes = "30" };
                var duration = new DurationRequest { hours = "1", minutes = "0" };

                set_field(fixture.request, off_set, duration);
                fixture.execute_command();
                var response = fixture.response;
                response.has_errors.Should().BeTrue();
                response.messages.Count().Should().Be(4);
                response.messages.Should().Contain(m => m.message == ValidationMessages.error_00_0086);
                response.messages.Should().Contain(m => m.field_name.Equals("duration.hours"));
                response.messages.Should().Contain(m => m.field_name.Equals("duration.minutes"));
            }

            [TestMethod]
            public void report_error_message_if_new_break_start_after_overlapped_with_old_break_end_time()
            {

                var off_set = new DurationRequest { hours = "2", minutes = "35" };
                var duration = new DurationRequest { hours = "1", minutes = "0" };

                set_field(fixture.request, off_set, duration);
                fixture.execute_command();

                var response = fixture.response;
                response.has_errors.Should().BeTrue();
                response.messages.Count().Should().Be(4);
                response.messages.Should().Contain(m => m.message == ValidationMessages.error_00_0085);
                response.messages.Should().Contain(m => m.field_name.Equals("off_set.hours"));
                response.messages.Should().Contain(m => m.field_name.Equals("off_set.minutes"));
            }

            [TestMethod]
            public void report_error_message_if_new_break_overlapped_with_tow_old_break_()
            {

                var off_set = new DurationRequest { hours = "2", minutes = "30" };
                var duration = new DurationRequest { hours = "4", minutes = "0" };

                set_field(fixture.request, off_set, duration);
                fixture.execute_command();

                var response = fixture.response;
                response.has_errors.Should().BeTrue();
                response.messages.Count().Should().Be(7);
                response.messages.Should().Contain(m => m.message == ValidationMessages.error_00_0085);
                response.messages.Should().Contain(m => m.field_name.Equals("off_set.hours"));
                response.messages.Should().Contain(m => m.field_name.Equals("off_set.minutes"));
                response.messages.Should().Contain(m => m.message == ValidationMessages.error_00_0086);
                response.messages.Should().Contain(m => m.field_name.Equals("duration.hours"));
                response.messages.Should().Contain(m => m.field_name.Equals("duration.minutes"));
            }

            /// <summary>
            /// single enveloped
            /// </summary>
            [TestMethod]
            public void report_error_message_if_new_break_enveloped_by_one_old_break_()
            {

                var off_set = new DurationRequest { hours = "1", minutes = "05" };
                var duration = new DurationRequest { hours = "1", minutes = "05" };

                set_field(fixture.request, off_set, duration);
                fixture.execute_command();

                var response = fixture.response;
                response.has_errors.Should().BeTrue();
                response.messages.Count().Should().Be(7);
                response.messages.Should().Contain(m => m.message == ValidationMessages.error_00_0089);
                response.messages.Should().Contain(m => m.field_name.Equals("off_set.hours"));
                response.messages.Should().Contain(m => m.field_name.Equals("off_set.minutes"));
                response.messages.Should().Contain(m => m.message == ValidationMessages.error_00_0090);
                response.messages.Should().Contain(m => m.field_name.Equals("duration.hours"));
                response.messages.Should().Contain(m => m.field_name.Equals("duration.minutes"));
            }

            [TestMethod]
            public void report_error_message_if_new_break_enveloped_by_one_old_break_and_both_have_a_same_end_time()
            {

                var off_set = new DurationRequest { hours = "1", minutes = "30" };
                var duration = new DurationRequest { hours = "1", minutes = "30" };
                set_field(fixture.request, off_set, duration);
                fixture.execute_command();

                var response = fixture.response;
                response.has_errors.Should().BeTrue();
                response.messages.Count().Should().Be(7);
                response.messages.Should().Contain(m => m.message == ValidationMessages.error_00_0089);
                response.messages.Should().Contain(m => m.field_name.Equals("off_set.hours"));
                response.messages.Should().Contain(m => m.field_name.Equals("off_set.minutes"));
                response.messages.Should().Contain(m => m.message == ValidationMessages.error_00_0090);
                response.messages.Should().Contain(m => m.field_name.Equals("duration.hours"));
                response.messages.Should().Contain(m => m.field_name.Equals("duration.minutes"));
            }

            [TestMethod]
            public void report_error_message_if_new_break_enveloped_by_one_old_break_and_both_have_a_same_start_time()
            {

                var off_set = new DurationRequest { hours = "1", minutes = "0" };
                var duration = new DurationRequest { hours = "1", minutes = "0" };
                set_field(fixture.request, off_set, duration);
                fixture.execute_command();

                var response = fixture.response;
                response.has_errors.Should().BeTrue();
                response.messages.Count().Should().Be(7);
                response.messages.Should().Contain(m => m.message == ValidationMessages.error_00_0089);
                response.messages.Should().Contain(m => m.field_name.Equals("off_set.hours"));
                response.messages.Should().Contain(m => m.field_name.Equals("off_set.minutes"));
                response.messages.Should().Contain(m => m.message == ValidationMessages.error_00_0090);
                response.messages.Should().Contain(m => m.field_name.Equals("duration.hours"));
                response.messages.Should().Contain(m => m.field_name.Equals("duration.minutes"));
            }

            [TestMethod]
            public void report_error_message_if_new_break_enveloped_by_one_old_break_and_both_have_a_same_start_and_end_time()
            {

                var off_set = new DurationRequest { hours = "1", minutes = "0" };
                var duration = new DurationRequest { hours = "2", minutes = "0" };
                set_field(fixture.request, off_set, duration);
                fixture.execute_command();

                var response = fixture.response;
                response.has_errors.Should().BeTrue();
                response.messages.Count().Should().Be(7);
                response.messages.Should().Contain(m => m.message == ValidationMessages.error_00_0089);
                response.messages.Should().Contain(m => m.field_name.Equals("off_set.hours"));
                response.messages.Should().Contain(m => m.field_name.Equals("off_set.minutes"));
                response.messages.Should().Contain(m => m.message == ValidationMessages.error_00_0090);
                response.messages.Should().Contain(m => m.field_name.Equals("duration.hours"));
                response.messages.Should().Contain(m => m.field_name.Equals("duration.minutes"));
            }

            /// single envelop
            /// </summary>

            [TestMethod]
            public void report_error_message_if_new_break_envelops_one_old_break()
            {

                var off_set = new DurationRequest { hours = "0", minutes = "30" };
                var duration = new DurationRequest { hours = "3", minutes = "0" };

                set_field(fixture.request, off_set, duration);
                fixture.execute_command();

                var response = fixture.response;
                response.has_errors.Should().BeTrue();
                response.messages.Count().Should().Be(7);
                response.messages.Should().Contain(m => m.message == ValidationMessages.error_00_0089);
                response.messages.Should().Contain(m => m.field_name.Equals("off_set.hours"));
                response.messages.Should().Contain(m => m.field_name.Equals("off_set.minutes"));
                response.messages.Should().Contain(m => m.message == ValidationMessages.error_00_0090);
                response.messages.Should().Contain(m => m.field_name.Equals("duration.hours"));
                response.messages.Should().Contain(m => m.field_name.Equals("duration.minutes"));
            }

            [TestMethod]
            public void report_error_message_if_new_break_envelops_one_old_break_and_have_a_same_end_time()
            {

                var off_set = new DurationRequest { hours = "0", minutes = "30" };
                var duration = new DurationRequest { hours = "2", minutes = "30" };
                set_field(fixture.request, off_set, duration);
                fixture.execute_command();

                var response = fixture.response;
                response.has_errors.Should().BeTrue();
                response.messages.Count().Should().Be(4);
                response.messages.Should().Contain(m => m.message == ValidationMessages.error_00_0090);
                response.messages.Should().Contain(m => m.field_name.Equals("duration.hours"));
                response.messages.Should().Contain(m => m.field_name.Equals("duration.minutes"));
            }

            [TestMethod]
            public void report_error_message_if_new_break_envelops_one_old_break_and_have_a_same_start_after()
            {

                var off_set = new DurationRequest { hours = "1", minutes = "0" };
                var duration = new DurationRequest { hours = "2", minutes = "30" };
                set_field(fixture.request, off_set, duration);
                fixture.execute_command();

                var response = fixture.response;
                response.has_errors.Should().BeTrue();
                response.messages.Count().Should().Be(4);
                response.messages.Should().Contain(m => m.message == ValidationMessages.error_00_0089);
                response.messages.Should().Contain(m => m.field_name.Equals("off_set.hours"));
                response.messages.Should().Contain(m => m.field_name.Equals("off_set.minutes"));
            }

            /// <summary>
            /// Multiple envelop validation 
            /// </summary>

            [TestMethod]
            public void report_error_message_if_new_break_envelops_more_than_one_old_break()
            {

                var off_set = new DurationRequest { hours = "0", minutes = "30" };
                var duration = new DurationRequest { hours = "11", minutes = "0" };
                set_field(fixture.request, off_set, duration);
                fixture.execute_command();

                var response = fixture.response;
                response.has_errors.Should().BeTrue();
                response.messages.Count().Should().Be(7);
                response.messages.Should().Contain(m => m.message == ValidationMessages.error_00_0093);
                response.messages.Should().Contain(m => m.field_name.Equals("duration.hours"));
                response.messages.Should().Contain(m => m.field_name.Equals("duration.minutes"));
                response.messages.Should().Contain(m => m.message == ValidationMessages.error_00_0092);
                response.messages.Should().Contain(m => m.field_name.Equals("off_set.hours"));
                response.messages.Should().Contain(m => m.field_name.Equals("off_set.minutes"));
            }

            [TestMethod]
            public void report_error_message_if_new_break_envelops_more_than_one_old_break_and_have_a_same_start_and_end_time()
            {

                var off_set = new DurationRequest { hours = "1", minutes = "0" };
                var duration = new DurationRequest { hours = "10", minutes = "0" };
                set_field(fixture.request, off_set, duration);
                fixture.execute_command();

                var response = fixture.response;
                response.has_errors.Should().BeTrue();
                response.messages.Count().Should().Be(7);
                response.messages.Should().Contain(m => m.message == ValidationMessages.error_00_0093);
                response.messages.Should().Contain(m => m.field_name.Equals("duration.hours"));
                response.messages.Should().Contain(m => m.field_name.Equals("duration.minutes"));
                response.messages.Should().Contain(m => m.message == ValidationMessages.error_00_0092);
                response.messages.Should().Contain(m => m.field_name.Equals("off_set.hours"));
                response.messages.Should().Contain(m => m.field_name.Equals("off_set.minutes"));
            }

            [TestMethod]
            public void report_error_message_if_new_break_envelops_more_than_one_old_break_and_have_a_same_end_time()
            {

                var off_set = new DurationRequest { hours = "0", minutes = "30" };
                var duraion = new DurationRequest { hours = "10", minutes = "30" };
                set_field(fixture.request, off_set, duraion);
                fixture.execute_command();

                var response = fixture.response;
                response.has_errors.Should().BeTrue();
                response.messages.Count().Should().Be(4);
                response.messages.Should().Contain(m => m.message == ValidationMessages.error_00_0093);
                response.messages.Should().Contain(m => m.field_name.Equals("duration.hours"));
                response.messages.Should().Contain(m => m.field_name.Equals("duration.minutes"));
            }

            [TestMethod]
            public void report_error_message_if_new_break_envelops_more_than_one_old_break_and_have_a_same_start_time()
            {

                var off_set = new DurationRequest { hours = "1", minutes = "0" };
                var duration = new DurationRequest { hours = "10", minutes = "30" };
                set_field(fixture.request, off_set, duration);
                fixture.execute_command();

                var response = fixture.response;
                response.has_errors.Should().BeTrue();
                response.messages.Count().Should().Be(4);
                response.messages.Should().Contain(m => m.message == ValidationMessages.error_00_0092);
                response.messages.Should().Contain(m => m.field_name.Equals("off_set.hours"));
                response.messages.Should().Contain(m => m.field_name.Equals("off_set.minutes"));
            }

            [TestMethod]
            public void report_error_message_if_new_break_end_time_enveloped_and_overlapped()
            {

                var off_set = new DurationRequest { hours = "0", minutes = "30" };
                var duration = new DurationRequest { hours = "10", minutes = "0" };
                set_field(fixture.request, off_set, duration);
                fixture.execute_command();

                var response = fixture.response;
                response.has_errors.Should().BeTrue();
                response.messages.Count().Should().Be(4);
                response.messages.Should().Contain(m => m.message == ValidationMessages.error_00_0093);
                response.messages.Should().Contain(m => m.field_name.Equals("duration.hours"));
                response.messages.Should().Contain(m => m.field_name.Equals("duration.minutes"));
            }

            [TestMethod]
            public void report_error_message_if_new_break_start_time_enveloped_and_overlapped()
            {

                var off_set = new DurationRequest { hours = "2", minutes = "30" };
                var duration = new DurationRequest { hours = "9", minutes = "30" };
                set_field(fixture.request, off_set, duration);
                fixture.execute_command();

                var response = fixture.response;
                response.has_errors.Should().BeTrue();
                response.messages.Count().Should().Be(4);
                response.messages.Should().Contain(m => m.message == ValidationMessages.error_00_0092);
                response.messages.Should().Contain(m => m.field_name.Equals("off_set.hours"));
                response.messages.Should().Contain(m => m.field_name.Equals("off_set.minutes"));
            }

            [TestMethod]
            public void report_error_message_if_new_break_start_time_enveloped_and_have_same_time_and_end_time_overlapped()
            {

                var off_set = new DurationRequest { hours = "1", minutes = "0" };
                var duration = new DurationRequest { hours = "9", minutes = "30" };
                set_field(fixture.request, off_set, duration);
                fixture.execute_command();

                var response = fixture.response;
                response.has_errors.Should().BeTrue();
                response.messages.Count().Should().Be(7);
                response.messages.Should().Contain(m => m.message == ValidationMessages.error_00_0092);
                response.messages.Should().Contain(m => m.field_name.Equals("off_set.hours"));
                response.messages.Should().Contain(m => m.field_name.Equals("off_set.minutes"));
                response.messages.Should().Contain(m => m.message == ValidationMessages.error_00_0086);
                response.messages.Should().Contain(m => m.field_name.Equals("duration.hours"));
                response.messages.Should().Contain(m => m.field_name.Equals("duration.minutes"));
            }

            [TestMethod]
            public void report_error_message_if_new_break_start_time_overlapped_while_its_end_time_enveloped_old_breaks_and_have_same_end_time()
            {

                var off_set = new DurationRequest { hours = "2", minutes = "30" };
                var duration = new DurationRequest { hours = "8", minutes = "30" };
                set_field(fixture.request, off_set, duration);
                fixture.execute_command();

                var response = fixture.response;
                response.has_errors.Should().BeTrue();
                response.messages.Count().Should().Be(7);
                response.messages.Should().Contain(m => m.message == ValidationMessages.error_00_0086);
                response.messages.Should().Contain(m => m.field_name.Equals("off_set.hours"));
                response.messages.Should().Contain(m => m.field_name.Equals("off_set.minutes"));
                response.messages.Should().Contain(m => m.message == ValidationMessages.error_00_0092);
                response.messages.Should().Contain(m => m.field_name.Equals("duration.hours"));
                response.messages.Should().Contain(m => m.field_name.Equals("duration.minutes"));
            }

            [TestMethod]
            public void report_error_message_if_new_break_start_time_and_end_time_overlapped_and_in_middle_enveloped_old_break()
            {

                var off_set = new DurationRequest { hours = "2", minutes = "30" };
                var duration = new DurationRequest { hours = "8", minutes = "0" };
                set_field(fixture.request, off_set, duration);
                fixture.execute_command();

                var response = fixture.response;
                response.has_errors.Should().BeTrue();
                response.messages.Count().Should().Be(7);
                response.messages.Should().Contain(m => m.message == ValidationMessages.error_00_0086);
                response.messages.Should().Contain(m => m.field_name.Equals("off_set.hours"));
                response.messages.Should().Contain(m => m.field_name.Equals("off_set.minutes"));
                response.messages.Should().Contain(m => m.message == ValidationMessages.error_00_0086);
                response.messages.Should().Contain(m => m.field_name.Equals("duration.hours"));
                response.messages.Should().Contain(m => m.field_name.Equals("duration.minutes"));
            }
        }
    }
