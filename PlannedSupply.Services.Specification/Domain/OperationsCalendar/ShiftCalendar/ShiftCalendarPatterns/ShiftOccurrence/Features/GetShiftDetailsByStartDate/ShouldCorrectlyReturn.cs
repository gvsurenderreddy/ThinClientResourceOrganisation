using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.Library.DomainTypes.Time;
using WTS.WorkSuite.Library.DomainTypes.Time.Clocks;
using WTS.WorkSuite.Library.DomainTypes.Time.Periods;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence.GetShiftDetailsByStartDate;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.TimeAllocationOccurrence;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.SpecificationTemplates.Base;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.ShiftCalendarPatterns.ShiftOccurrence.Features.GetShiftDetailsByStartDate
{
    [TestClass]
    public class ShouldCorrectlyReturn : PlannedSupplySpecification
    {
        [TestMethod]
        public void the_correct_time_block_identity_request_should_be_return()
        {
            var time_block_identity_request = time_block_identity();
            var expected_time_block_identity = query.execute(time_block_identity_request).result;

            Assert.AreEqual(expected_time_block_identity.operations_calendar_id, fixture.operational_calendar.id);
            Assert.AreEqual(expected_time_block_identity.shift_calendar_id, fixture.shift_calendar_A.id);
            Assert.AreEqual(expected_time_block_identity.shift_calendar_pattern_id, fixture.shift_calendar_pattern_A.id);
        }
        [TestMethod]
        public void the_correct_shift_occurrence_id_should_be_return()
        {
            var time_block_identity_request = time_block_identity();
            var expected_shift_occurrence_id = query.execute(time_block_identity_request).result.shift_occurrence_id;

            Assert.AreEqual(expected_shift_occurrence_id, fixture.time_allocation_occurrence_first.id);
        }

        [TestMethod]
        public void the_correct_shift_occurrence_title_should_be_return()
        {
            var time_block_identity_request = time_block_identity();
            var expected_shift_occurrence_title = query.execute(time_block_identity_request).result.shift_title;

            Assert.AreEqual(expected_shift_occurrence_title, fixture.time_allocation_occurrence_first.time_allocation.title);
        }

        [TestMethod]
        public void the_correct_time_period_start_at_and_duration_should_be_return()
        {
            var time_block_identity_request = time_block_identity();
            var expected_time_period = query.execute(time_block_identity_request).result.time_period;

            var actual_time_period = new TimePeriod( 
                new UtcTime( fixture.time_allocation_occurrence_first.start_date.Year
                                      , fixture.time_allocation_occurrence_first.start_date.Month
                                      , fixture.time_allocation_occurrence_first.start_date.Day
                                      , fixture.time_allocation_occurrence_first.time_allocation.start_time_in_seconds_from_midnight.seconds_to_hours()
                                      , fixture.time_allocation_occurrence_first.time_allocation.start_time_in_seconds_from_midnight.seconds_to_minutes()
                                      , fixture.time_allocation_occurrence_first.start_date.Second
                                      , fixture.time_allocation_occurrence_first.start_date.Millisecond)
               , fixture.time_allocation_occurrence_first.time_allocation.duration_in_seconds);
         

            Assert.AreEqual(expected_time_period.start_at.hours, actual_time_period.start_at.hours);
            Assert.AreEqual(expected_time_period.start_at.minutes, actual_time_period.start_at.minutes);
            Assert.AreEqual(expected_time_period.duration, actual_time_period.duration);
        }

        private TimeBlockIdentity time_block_identity()
        {
            var time_block_identity_request = new TimeBlockIdentity
            {
                operations_calendar_id = fixture.operational_calendar.id,
                shift_calendar_id = fixture.shift_calendar_A.id,
                shift_calendar_pattern_id = fixture.shift_calendar_pattern_A.id,
                start_date = fixture.time_allocation_occurrence_first.start_date
            };
            return time_block_identity_request;
        }

        protected override void test_setup()
        {
            base.test_setup();
            fixture = DependencyResolver.resolve<ShiftOccurrencesFixture>();
            query = DependencyResolver.resolve<IGetShiftOccurrenceByStartDate>();

        }

        private ShiftOccurrencesFixture fixture;
        private IGetShiftOccurrenceByStartDate query;
    }
}