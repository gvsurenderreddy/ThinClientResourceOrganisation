using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.Remove;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.SpecificationTemplates.Base;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.ShiftCalendarPatterns.Features.Remove
{
    [TestClass]
    public class Remove_shift_calendar_pattern_should
                        : PlannedSupplySpecification
    {
        [TestMethod]
        public void remove_the_shift_calendar_pattern()
        {
            fixture.execute_command(null);

            fixture
                .response
                .Match(

                    has_value:
                        response => response.has_errors.Should().Be(false),

                    nothing:
                        () => Assert.Fail()

                );
        }

        protected override void test_setup()
        {
            base.test_setup();

            fixture = new RemoveShiftCalendarPatternFixture();
        }

        private RemoveShiftCalendarPatternFixture fixture;
    }

    [TestClass]
    public class ReorderPatternsWhenOneIsRemoved : ReorderShiftCalendarPatternSpecifiction
    {
        [TestMethod]
        public void when_a_pattern_is_removed_then_its_priority_gap_should_be_closed_by_moving_others_below_it_up()
        {
            // Act
            var response = remove_pattern_command.execute(new RemoveShiftCalendarPatternRequest
            {
                operations_calendar_id = operational_calendar.id,
                shift_calendar_id = shift_calendar.id,
                shift_calendar_pattern_id = pattern_three.id
            });

            // Assert
            pattern_one.priority.Should().Be(1);
            pattern_two.priority.Should().Be(2);
            pattern_four.priority.Should().Be(3);
            pattern_five.priority.Should().Be(4);
            pattern_six.priority.Should().Be(5);
        }

        protected override void test_setup()
        {
            base.test_setup();

            remove_pattern_command = DependencyResolver.resolve<IRemoveShiftCalendarPattern>();
        }

        protected IRemoveShiftCalendarPattern remove_pattern_command;
    }
}