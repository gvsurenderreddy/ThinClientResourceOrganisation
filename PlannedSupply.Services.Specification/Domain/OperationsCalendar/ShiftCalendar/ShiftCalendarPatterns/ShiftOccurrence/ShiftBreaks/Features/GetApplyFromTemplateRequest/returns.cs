using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence.ShiftBreaks.ApplyFromTemplate;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.SpecificationTemplates.Base;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.ShiftCalendarPatterns.ShiftOccurrence.ShiftBreaks.Features.GetApplyFromTemplateRequest
{
    [TestClass]
    public class GetApplyShiftBreaksFromBreakTemplate_returns : 
                    PlannedSupplyResponseCommandSpecification<ShiftOccurrenceIdentity, 
                                                                Response<ApplyShiftBreaksFromBreakTemplateRequest>, 
                                                                GetApplyShiftBreaksFromBreakTemplateRequestFixture>
    {
        [TestMethod]
        public void the_apply_shift_breaks_from_template_request()
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
