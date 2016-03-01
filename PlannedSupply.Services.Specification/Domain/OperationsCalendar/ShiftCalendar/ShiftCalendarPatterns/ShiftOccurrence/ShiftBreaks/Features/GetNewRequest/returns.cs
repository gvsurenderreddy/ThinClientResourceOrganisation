using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence.ShiftBreaks.New;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.SpecificationTemplates.Base;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.ShiftCalendarPatterns.ShiftOccurrence.ShiftBreaks.Features.GetNewRequest
{
    [TestClass]
    public class GetNewShiftBreakRequest_returns : PlannedSupplyResponseCommandSpecification<ShiftOccurrenceIdentity,
                                                                                                            Response<NewShiftBreakRequest>, 
                                                                                                            GetNewShiftBreakRequestFixture>
    {
        [TestMethod]
        public void the_new_shift_break_request()
        {
            fixture.execute_command();

            var response = fixture.response;

            response.result.Should().NotBeNull();
            response.has_errors.Should().BeFalse();
        }

        [TestMethod]
        public void the_correct_shift_occurrence_identity()
        {
            fixture.execute_command();

            var response = fixture.response;

            response.result.operations_calendar_id.Should().Be(fixture.request.operations_calendar_id);
            response.result.shift_calendar_id.Should().Be(fixture.request.shift_calendar_id);
            response.result.shift_calendar_pattern_id.Should().Be(fixture.request.shift_calendar_pattern_id);
            response.result.shift_occurrence_id.Should().Be(fixture.request.shift_occurrence_id);
        }

    }
}
