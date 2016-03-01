using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence.Remove;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.SpecificationTemplates.Base;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.ShiftCalendarPatterns.ShiftOccurrence.Features.GetRemoveRequest
{
    [TestClass]
    public class Returns : PlannedSupplyResponseCommandSpecification<ShiftOccurrenceIdentity, Response<RemoveShiftOccurrenceRequest>, GetRemoveRequestFixture>
    {
        [TestMethod]
        public void the_remove_request()
        {
            fixture.execute_command();

            var response = fixture.response;

            response.result.Should().NotBeNull();
            response.has_errors.Should().BeFalse();
        }
    }
}
