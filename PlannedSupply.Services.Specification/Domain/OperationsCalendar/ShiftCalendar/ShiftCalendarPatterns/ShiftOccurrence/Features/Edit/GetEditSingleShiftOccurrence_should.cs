using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence.Edit;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.SpecificationTemplates.Base;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.ShiftCalendarPatterns.ShiftOccurrence.Features.Edit
{
    [TestClass]
    public class GetEditSingleShiftOccurrence_should
                                  : PlannedSupplySpecification
    {
        [TestMethod]
        public void return_valid_edit_single_shift_occurrence_request()
        {
            var shift_occurrence_identity = new ShiftOccurrenceIdentity
            {
                operations_calendar_id = fixture.operational_calendar.id,
                shift_calendar_id =  fixture.shift_calendar_A.id,
                shift_calendar_pattern_id = fixture.shift_calendar_pattern_A.id,
                shift_occurrence_id =  fixture.time_allocation_occurrence_first.id
            };

            var request = command.execute(shift_occurrence_identity);
            request.result.operations_calendar_id.Should().Be(fixture.operational_calendar.id);
            request.result.shift_calendar_id.Should().Be(fixture.shift_calendar_A.id);
            request.result.shift_calendar_pattern_id.Should().Be(fixture.shift_calendar_pattern_A.id);
            request.result.shift_occurrence_id.Should().Be(fixture.time_allocation_occurrence_first.id);
        }

        protected override void test_setup()
        {
            base.test_setup();
            fixture = DependencyResolver.resolve<ShiftOccurrencesFixture>();
            command = DependencyResolver.resolve<IGetEditSingleShiftOccurrenceRequest>();
        }

        private ShiftOccurrencesFixture fixture;
        private IGetEditSingleShiftOccurrenceRequest command;
    }
}