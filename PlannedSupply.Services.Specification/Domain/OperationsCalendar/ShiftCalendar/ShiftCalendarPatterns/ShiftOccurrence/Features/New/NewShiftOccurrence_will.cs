using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence.New;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.SpecificationTemplates.Base;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.ShiftCalendarPatterns.ShiftOccurrence.Features.New
{
    [TestClass]
    public class NewShiftOccurrence_will : PlannedSupplyResponseCommandSpecification<NewShiftOccurrenceRequest, NewShiftOccurrenceResponse, NewShiftOccurrenceFixture>
    {
        [TestMethod]
        public void reuse_time_allocations_for_shift_occurrences_with_the_same_signatures()
        {
            //Arrange
            var pre_existing_shift = fixture.seed_pre_existing_shift_for(fixture.request);

            // act
            fixture.execute_command();

            //Assert
            pre_existing_shift.time_allocation.id.Should().Be(fixture.entity.time_allocation.id);
            pre_existing_shift.time_allocation.ShouldBeEquivalentTo(fixture.entity.time_allocation);

        }

        [TestMethod]
        public void not_reuse_time_allocations_for_shift_occurrences_with_different_signatures()
        {
            //Arrange
            var pre_existing_shift = fixture.seed_pre_existing_shift_for(fixture.request);
            fixture.request.shift_title = "a totally different shift title";
            
            // act
            fixture.execute_command();

            //Assert
            pre_existing_shift.time_allocation.id.Should().NotBe(fixture.entity.time_allocation.id);

        }
    }
}