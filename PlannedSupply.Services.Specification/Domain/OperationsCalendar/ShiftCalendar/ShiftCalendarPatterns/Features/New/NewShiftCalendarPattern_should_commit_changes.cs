using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.New;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.New.Create;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.SpecificationTemplates.Base;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.ShiftCalendarPatterns.Features.New
{
    [TestClass]
    public class NewShiftCalendarPattern_should
                        : PlannedSupplySpecification
    {
        [TestMethod]
        public void create_a_new_shift_calendar_pattern()
        {
            fixture.execute_command(null);

            fixture
                .create_new_response
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

            fixture = DependencyResolver.resolve<NewShiftCalendarPatternFixture>();
        }

        private NewShiftCalendarPatternFixture fixture;
    }

    [TestClass]
    public class ReorderPatternWhenCreated : ReorderShiftCalendarPatternSpecifiction
    {
        [TestMethod]
        public void when_a_pattern_is_added_then_it_should_be_set_to_highest_priority()
        {
            // Act
            var response = add_pattern_command.execute(new NewShiftCalendarPatternRequest
                                                        {
                                                            operations_calendar_id = operational_calendar.id,
                                                            shift_calendar_id = shift_calendar.id,
                                                            pattern_name = "A shift calendar pattern",
                                                            number_of_resources = "1",
                                                        });

            var pattern_seven = shift_calendar.ShiftCalendarPatterns.SingleOrDefault(a => a.id == response.result.shift_calendar_pattern_id);

            // Assert
            pattern_seven.priority.Should().Be(1);
            pattern_one.priority.Should().Be(2);
            pattern_two.priority.Should().Be(3);
            pattern_three.priority.Should().Be(4);
            pattern_four.priority.Should().Be(5);
            pattern_five.priority.Should().Be(6);
            pattern_six.priority.Should().Be(7);
        }

        protected override void test_setup()
        {
            base.test_setup();

            add_pattern_command = DependencyResolver.resolve<INewShiftCalendarPattern>();
        }

        protected INewShiftCalendarPattern add_pattern_command;
    }
}