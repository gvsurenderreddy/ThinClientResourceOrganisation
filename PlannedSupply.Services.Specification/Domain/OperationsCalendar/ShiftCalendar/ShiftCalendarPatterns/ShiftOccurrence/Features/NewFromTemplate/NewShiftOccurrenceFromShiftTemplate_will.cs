using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.Library.DomainTypes.Exceptions;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence.NewFromTemplate;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.SpecificationTemplates.Base;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.ShiftCalendarPatterns.ShiftOccurrence.Features.NewFromTemplate
{
    [TestClass]
    public class NewShiftOccurrenceFromShiftTemplate_will : PlannedSupplyResponseCommandSpecification<NewShiftOccurrenceFromShiftTemplateRequest, NewShiftOccurrenceFromShiftTemplateResponse, NewShiftOccurrenceFromShiftTemplateFixture>
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
            var pre_existing_shift = fixture.seed_pre_existing_shift_that_is_different_from(fixture.request);
            
            // act
            fixture.execute_command();

            //Assert
            pre_existing_shift.time_allocation.id.Should().NotBe(fixture.entity.time_allocation.id);

        }

        [TestMethod]
        public void not_reuse_time_allocations_for_shift_occurrences_with_same_signature_but_different_break_signatures()
        {
            //Arrange
            var pre_existing_shift = fixture.seed_pre_existing_shift_that_has_same_details_but_different_break_signature(fixture.request);

            // act
            fixture.execute_command();

            //Assert
            pre_existing_shift.time_allocation.id.Should().NotBe(fixture.entity.time_allocation.id);

        }

        [TestMethod]
        [ExpectedException(typeof(InternalCorruptDataException))]
        public void throw_internal_server_error_on_corrupt_shift_template_data()
        {
            //Arrange
            fixture.contaminate_internal_shift_template();

            // act
            fixture.execute_command();
        }


    }
}