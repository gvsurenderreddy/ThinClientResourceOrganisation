using System.Linq;
using Content.Services.PlannedSupply.Messages;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.Library.DomainTypes.Duration;
using WTS.WorkSuite.Library.DomainTypes.Exceptions;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence.ShiftBreaks.New;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.SpecificationTemplates.Base;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.ShiftCalendarPatterns.ShiftOccurrence.ShiftBreaks.Features.NewShiftBreak
{
    [TestClass]
    public class command_Will : PlannedSupplyResponseCommandSpecification<NewShiftBreakRequest,
                                                                                    NewShiftBreakResponse,
                                                                                    NewShiftBreakFixture>
    {
        [TestMethod]
        public void validate_against_adding_a_break_that_extends_beyond_the_shift()
        {
            var time_allocation = fixture.get_backing_time_allocation_for_request();

            fixture.clear_any_existing_breaks_on(time_allocation);

            fixture.request.off_set = 0.to_duration_request();
            //extend the request to exceed the end of the shift by a minute (60 seconds)
            fixture.request.duration = (time_allocation.duration_in_seconds + 60).to_duration_request();

            fixture.execute_command();

            //Assert
            Assert.IsTrue(fixture.response.messages.Select(msg => msg.field_name).Contains("off_set.hours"));
            Assert.IsTrue(fixture.response.messages.Select(msg => msg.field_name).Contains("off_set.minutes"));
            Assert.IsTrue(fixture.response.messages.Select(msg => msg.field_name).Contains("duration.hours"));
            Assert.IsTrue(fixture.response.messages.Select(msg => msg.field_name).Contains("duration.hours"));
            Assert.IsTrue(fixture.response.messages.Select(msg => msg.message).Contains(WarningMessages.warning_03_0043));
        }


        [TestMethod]
        public void report_a_validation_error_when_a_break_with_a_size_of_0_or_less_is_entered()
        {
            //Arrange
            fixture.request.duration = new Library.DomainTypes.Duration.DurationRequest()
            {
                hours = "0",
                minutes = "0"
            };

            fixture.execute_command();

            fixture.response.has_errors.Should().BeTrue();
            fixture.response.messages.Should().Contain(e => e.message == WarningMessages.warning_03_0043);
        }

        [TestMethod]
        [ExpectedException(typeof(InternalCorruptDataException))]
        public void throw_internal_server_error_on_corrupt_shift_data()
        {
            //Arrange
            fixture.contaminate_internal_shift_details();

            // act
            fixture.execute_command();
        }
    }
}
