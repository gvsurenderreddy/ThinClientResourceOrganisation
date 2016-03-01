using Content.Services.PlannedSupply.Messages;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.Library.DomainTypes.Duration;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.BreakTemplates;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.BreakTemplates.Breaks;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.SpecificationTemplates.Base;
using WTS.WorkSuite.PlannedSupply.BreakTemplates;
using WTS.WorkSuite.PlannedSupply.BreakTemplates.Break.Edit;
using WTS.WorkSuite.PlannedSupply.BreakTemplates.Break.Edit.Update;
using WTS.WorkSuite.PlannedSupply.BreakTemplates.Break.New;
using WTS.WorkSuite.PlannedSupply.BreakTemplates.Break.New.Create;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.BreakTemplates.Break.Fields.off_set_in_seconds
{
    public class Off_set_should_be_valid_when_hours_must_be_between_zero_and_twenty_four
    {
        [TestClass]
        public class OnCreate
                            : PlannedSupplySpecification
        {
            [TestMethod]
            public void hour_less_than_zero_should_report_error()
            {
                confirm_hour_is_not_acceptable_as_it_is_not_a_number("-1");
            }

            [TestMethod]
            public void hour_in_text_format_should_report_error()
            {
                confirm_hour_is_not_acceptable_as_it_is_not_a_number("test");
            }

            [TestMethod]
            public void hour_greater_than_24_should_report_error()
            {
                confirm_hour_is_not_acceptable_as_it_is_greater_than_24("25");
            }

            private void confirm_hour_is_not_acceptable_as_it_is_not_a_number(string the_value)
            {
                var response = execute_create_new_break_command(the_value);

                response.has_errors.Should().BeTrue();
                response.messages.Should().Contain(m => m.field_name == "off_set" && m.message == ValidationMessages.error_00_0065);
                response.messages.Should().Contain(m => m.message == WarningMessages.warning_03_0025);
            }

            private void confirm_hour_is_not_acceptable_as_it_is_greater_than_24(string the_value)
            {
                var response = execute_create_new_break_command(the_value);

                response.has_errors.Should().BeTrue();
                response.messages.Should().Contain(m => m.field_name == "off_set" && m.message == ValidationMessages.error_00_0066);
                response.messages.Should().Contain(m => m.message == WarningMessages.warning_03_0025);
            }

            private NewBreakResponse execute_create_new_break_command(string the_value)
            {
                BreakTemplate break_template = break_template_helper
                                                .add()
                                                .entity
                                                ;

                var request = new NewBreakRequest
                {
                    template_id = break_template.id,
                    off_set = new DurationRequest
                    {
                        hours = the_value,
                        minutes = "1"
                    },
                    duration = new DurationRequest()
                };

                var response = new_break
                                    .execute(request)
                                    ;

                return response;
            }

            protected override void test_setup()
            {
                base.test_setup();
                break_template_helper = DependencyResolver.resolve<BreakTemplateHelper>();
                new_break = DependencyResolver.resolve<INewBreak>();
            }

            private INewBreak new_break;
            private BreakTemplateHelper break_template_helper;
        }

        [TestClass]
        public class OnUpdate
                            : PlannedSupplySpecification
        {
            [TestMethod]
            public void hour_less_than_zero_should_report_error()
            {
                confirm_hour_is_not_acceptable_as_it_is_not_a_number("-1");
            }

            [TestMethod]
            public void hour_in_text_format_should_report_error()
            {
                confirm_hour_is_not_acceptable_as_it_is_not_a_number("test");
            }

            [TestMethod]
            public void hour_greater_than_24_should_report_error()
            {
                confirm_hour_is_not_acceptable_as_it_is_greater_than_24("25");
            }

            private void confirm_hour_is_not_acceptable_as_it_is_not_a_number(string the_value)
            {
                var response = execute_create_new_break_command(the_value);

                response.has_errors.Should().BeTrue();
                response.messages.Should().Contain(m => m.field_name == "off_set" && m.message == ValidationMessages.error_00_0065);
                response.messages.Should().Contain(m => m.message == WarningMessages.warning_03_0026);
            }

            private void confirm_hour_is_not_acceptable_as_it_is_greater_than_24(string the_value)
            {
                var response = execute_create_new_break_command(the_value);

                response.has_errors.Should().BeTrue();
                response.messages.Should().Contain(m => m.field_name == "off_set" && m.message == ValidationMessages.error_00_0066);
                response.messages.Should().Contain(m => m.message == WarningMessages.warning_03_0026);
            }

            private UpdateBreakResponse execute_create_new_break_command(string the_value)
            {
                var breakk = break_helper
                                            .add()
                                            .entity
                                            ;

                var break_template = break_template_helper
                                                .add()
                                                .entity
                                                ;

                break_template.all_breaks.Add(breakk);

                var request = new UpdateBreakRequest
                {
                    template_id = break_template.id,
                    break_id = breakk.id,
                    off_set = new DurationRequest
                    {
                        hours = the_value,
                        minutes = "1"
                    },
                    duration = new DurationRequest
                    {
                        hours = "0",
                        minutes = "15"
                    },
                    current_priority = "1"
                };

                var response = update_break
                                    .execute(request)
                                    ;

                return response;
            }

            protected override void test_setup()
            {
                base.test_setup();
                break_template_helper = DependencyResolver.resolve<BreakTemplateHelper>();
                break_helper = DependencyResolver.resolve<BreakHelper>();
                update_break = DependencyResolver.resolve<IUpdateBreak>();
            }

            private IUpdateBreak update_break;
            private BreakTemplateHelper break_template_helper;
            private BreakHelper break_helper;
        }
    }
}