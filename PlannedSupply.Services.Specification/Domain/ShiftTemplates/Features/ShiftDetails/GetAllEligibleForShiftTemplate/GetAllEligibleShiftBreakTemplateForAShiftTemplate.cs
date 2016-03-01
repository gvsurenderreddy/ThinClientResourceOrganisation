using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.DomainTypes.Duration;
using WTS.WorkSuite.Library.DomainTypes.Time;
using WTS.WorkSuite.PlannedSupply.Services.Domain.BreakTemplates.Features.Queries.GetAllEligibleForShiftTemplate;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.SpecificationTemplates.Base;
using WTS.WorkSuite.PlannedSupply.BreakTemplates;
using WTS.WorkSuite.PlannedSupply.BreakTemplates.Remove;
using WTS.WorkSuite.PlannedSupply.ShiftTemplates.Edit;
using WTS.WorkSuite.PlannedSupply.ShiftTemplates.Edit.Update;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.ShiftTemplates.Features.ShiftDetails.GetAllEligibleForShiftTemplate
{
    [TestClass]
    public class GetAllEligibleBreakTemplateForAShiftTemplate
                        : PlannedSupplySpecification
    {
        [TestMethod]
        public void should_return_all_eligible_break_templates_when_none_of_them_is_set_to_hidden()
        {
            // Arrange
            string template_name_for_from_06_to_18 = "Break template for the shift, 06:00 - 18:00";
            BreakTemplate break_template_from_06_to_18 = _break_template_fixture
                                                                        .add_break_template()
                                                                        .template_name(template_name_for_from_06_to_18)
                                                                        .entity
                                                                        ;

            string template_name_for_from_18_to_06 = "Break template for the shift, 18:00 - 06:00";
            BreakTemplate break_template_from_18_to_06 = _break_template_fixture
                                                                        .add_break_template()
                                                                        .template_name(template_name_for_from_18_to_06)
                                                                        .entity
                                                                        ;

            string template_name_for_from_09_to_17 = "Break template for the shift, 09:00 - 17:00";
            BreakTemplate break_template_from_09_to_17 = _break_template_fixture
                                                                        .add_break_template()
                                                                        .template_name(template_name_for_from_09_to_17)
                                                                        .entity
                                                                        ;

            // Act
            _fixture
                .execute_command()
                ;

            // Assert
            _fixture
                .response
                .Match(

                    has_value:
                        response =>
                        {
                            response.Count().Should().Be(4); // including the 'unspecified' option
                        },

                    nothing:
                        () => Assert.Fail()

                );
        }

        [TestMethod]
        public void should_return_all_eligible_break_templates_including_the_one_that_was_assigned_to_a_template_but_set_to_hidden_latter ()
        {
            // Arrange
            string template_name_for_from_06_to_18 = "Break template for the shift, 06:00 - 18:00";
            BreakTemplate break_template_from_06_to_18 = _break_template_fixture
                                                                        .add_break_template()
                                                                        .template_name(template_name_for_from_06_to_18)
                                                                        .entity
                                                                        ;

            string template_name_for_from_18_to_06 = "Break template for the shift, 18:00 - 06:00";
            BreakTemplate break_template_from_18_to_06 = _break_template_fixture
                                                                        .add_break_template()
                                                                        .template_name(template_name_for_from_18_to_06)
                                                                        .entity
                                                                        ;

            string template_name_for_from_09_to_17 = "Break template for the shift, 09:00 - 17:00";
            BreakTemplate break_template_from_09_to_17 = _break_template_fixture
                                                                        .add_break_template()
                                                                        .template_name(template_name_for_from_09_to_17)
                                                                        .entity
                                                                        ;

            // Update the shift template by associating a shift breakk template
            var _update_shift_template_command = DependencyResolver.resolve<IUpdateShiftTemplate>();
            _update_shift_template_command.execute(new UpdateShiftTemplateRequest
            {
                shift_template_id = _fixture._shift_template.id,
                shift_title = _fixture._shift_template.shift_title,
                start_time = _fixture._shift_template.start_time_in_seconds_from_midnight.ToTimeRequestFromSeconds(),
                duration = _fixture._shift_template.duration_in_seconds.to_duration_request(),
                colour = _fixture._shift_template.colour.to_rgb_colour_request_from_persistence_format(),
                break_template_id = break_template_from_06_to_18.id
            });

            // Now remove the assigned shift breakk template - that will be eventually set to hidden.
            var remove_break_template_command = DependencyResolver.resolve<IRemoveBreakTemplate>();
            remove_break_template_command.execute(new BreakTemplateIdentity
            {
                template_id = break_template_from_06_to_18.id
            });


            // Act
            _fixture
                .execute_command()
                ;

            var result = _fixture.response;

            // Assert
            _fixture
                .response
                .Match(

                    has_value:
                        response =>
                        {
                            response.Count().Should().Be(4);// including the 'unspecified' option and the hidden breakk template that associated to the shift template.
                        },

                    nothing:
                        () => Assert.Fail()

                );
        }

        [TestMethod]
        public void should_return_all_eligible_break_templates_excluding_any_templates_that_are_set_to_hidden()
        {
            // Arrange
            string template_name_for_from_06_to_18 = "Break template for the shift, 06:00 - 18:00";
            BreakTemplate break_template_from_06_to_18 = _break_template_fixture
                                                                        .add_break_template()
                                                                        .template_name(template_name_for_from_06_to_18)
                                                                        .entity
                                                                        ;

            string template_name_for_from_18_to_06 = "Break template for the shift, 18:00 - 06:00";
            BreakTemplate break_template_from_18_to_06 = _break_template_fixture
                                                                        .add_break_template()
                                                                        .template_name(template_name_for_from_18_to_06)
                                                                        .is_hidden(true)
                                                                        .entity
                                                                        ;

            string template_name_for_from_09_to_17 = "Break template for the shift, 09:00 - 17:00";
            BreakTemplate break_template_from_09_to_17 = _break_template_fixture
                                                                        .add_break_template()
                                                                        .template_name(template_name_for_from_09_to_17)
                                                                        .is_hidden(true)
                                                                        .entity
                                                                        ;

            // Act
            _fixture
                .execute_command()
                ;

            // Assert
            _fixture
                .response
                .Match(

                    has_value:
                        response =>
                        {
                            response.Count().Should().Be(2); // including the 'unspecified' option
                        },

                    nothing:
                        () => Assert.Fail()

                );
        }

        protected override void test_setup()
        {
            base.test_setup();

            _fixture = DependencyResolver.resolve<GetAllEligibleBreakTemplatesForAShiftTemplateFixture>();
            _break_template_fixture = DependencyResolver.resolve<GetAllBreakTemplatesForShiftTemplateFixture>();
        }

        private GetAllEligibleBreakTemplatesForAShiftTemplateFixture _fixture;
        private GetAllBreakTemplatesForShiftTemplateFixture _break_template_fixture;
    }
}