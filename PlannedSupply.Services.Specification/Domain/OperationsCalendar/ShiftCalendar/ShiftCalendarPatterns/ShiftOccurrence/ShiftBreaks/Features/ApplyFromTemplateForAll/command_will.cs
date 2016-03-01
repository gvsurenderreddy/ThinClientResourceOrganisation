using System.Linq;
using Content.Services.PlannedSupply.Messages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.Library.DomainTypes.Exceptions;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence.ShiftBreaks.ApplyFromTemplate;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.SpecificationTemplates.Base;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.ShiftCalendarPatterns.ShiftOccurrence.ShiftBreaks.Features.ApplyFromTemplateForAll
{
    public class command_will : PlannedSupplyResponseCommandSpecification<ApplyShiftBreaksFromBreakTemplateRequest, 
                                                                            ApplyShiftBreaksFromBreakTemplateResponse,
                                                                            ApplyShiftBreaksFromBreakTemplateForAllFixture>
    {
        [TestMethod]
        public void validate_against_applying_a_break_template_that_is_longer_than_the_shift()
        {
            fixture.ensure_break_template_has_a_total_duration_longer_than_the_shift();

            fixture.execute_command();

            //Assert
            Assert.IsTrue(fixture.response.messages.Count() == 2);
            Assert.IsTrue(fixture.response.messages.Select(msg => msg.field_name).Contains("break_template_id"));
            Assert.IsTrue(fixture.response.messages.Select(msg => msg.message).Contains(WarningMessages.warning_03_0031));
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
