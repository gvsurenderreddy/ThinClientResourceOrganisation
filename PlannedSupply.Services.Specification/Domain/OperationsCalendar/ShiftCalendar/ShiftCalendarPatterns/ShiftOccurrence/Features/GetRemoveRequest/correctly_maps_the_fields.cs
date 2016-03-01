using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.DomainTypes.Duration;
using WTS.WorkSuite.Library.DomainTypes.Time;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence.Remove;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence.RemoveAll;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.SpecificationTemplates.Base;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.ShiftCalendarPatterns.ShiftOccurrence.Features.GetRemoveRequest
{
    [TestClass]
    public class correctly_maps_the_fields : PlannedSupplyResponseCommandSpecification<ShiftOccurrenceIdentity, Response<RemoveShiftOccurrenceRequest>, GetRemoveRequestFixture>
    {
        [TestMethod]
        public void the_shift_occurrence_identity()
        {
            fixture.execute_command();

            var response = fixture.response;

            response.result.operations_calendar_id.Should().Be(fixture.request.operations_calendar_id);
            response.result.shift_calendar_id.Should().Be(fixture.request.shift_calendar_id);
            response.result.shift_calendar_pattern_id.Should().Be(fixture.request.shift_calendar_pattern_id);
            response.result.shift_occurrence_id.Should().Be(fixture.request.shift_occurrence_id);
        }

        [TestMethod]
        public void check_correctly_map_title_field()
        {
            fixture.execute_command();

            var response = fixture.response;

            Assert.AreEqual(response.result.title, fixture.time_allocation().title);
        }

        [TestMethod]
        public void check_correctly_map_colour_field()
        {
            fixture.execute_command();

            var response = fixture.response;

            Assert.AreEqual(response.result.colour.R, fixture.time_allocation().colour.to_rgb_colour_request_from_persistence_format().R);
            Assert.AreEqual(response.result.colour.G, fixture.time_allocation().colour.to_rgb_colour_request_from_persistence_format().G);
            Assert.AreEqual(response.result.colour.B, fixture.time_allocation().colour.to_rgb_colour_request_from_persistence_format().B);
        }

        [TestMethod]
        public void check_correctly_map_start_time_field()
        {
            fixture.execute_command();

            var response = fixture.response;

            Assert.AreEqual(response.result.start_time, fixture.time_allocation().start_time_in_seconds_from_midnight.ToTimeRequestFromSeconds().to_domain_string());
        }

        [TestMethod]
        public void check_correctly_map_duration_field()
        {
            fixture.execute_command();

            var response = fixture.response;

            Assert.AreEqual(response.result.duration, fixture.time_allocation().duration_in_seconds.to_duration_request().to_domain_format_string());
        }

        [TestMethod]
        public void check_correctly_map_shift_calendars_name_and_number_of_occurrences()
        {
            //expected
            var shift_calendar_affected = fixture.get_number_of_occurrences_and_shiftcalendar_name();

            //act
            var actual_respons = command.execute(fixture.request).result;

            //assert
            Assert.AreEqual(actual_respons.shift_calendar_affected.Count(), shift_calendar_affected.Count());

        }


        protected override void test_setup()
        {
            base.test_setup();
            command = DependencyResolver.resolve<IGetRemoveAllShiftOccurrencesRequest>();
        }

        private IGetRemoveAllShiftOccurrencesRequest command;
    }

}
