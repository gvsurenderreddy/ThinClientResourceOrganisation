using System.Linq;
using Content.Services.PlannedSupply.Messages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.Library.DomainTypes.Duration;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.SpecificationTemplates.Base;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.ShiftCalendarPatterns.ShiftOccurrence.Features.EditAll
{
    [TestClass]
    public class EditAllShiftOccurrences_should
                        : PlannedSupplySpecification
    {

        [TestMethod]
        public void validate_against_a_clash_between_the_shift_and_its_breaks()
        {
            // Arrange
            var time_allocation_for_request = fixture.get_backing_time_allocation(fixture.request);

            fixture.ensure_a_break_ends_1_minute_before_the_end_of_this_time_allocation(time_allocation_for_request);

            //reduce the duration of the shift request by just a little (2 minutes: 120 seconds) to cause a clash
            fixture.request.duration = (time_allocation_for_request.duration_in_seconds - 120).to_duration_request();

            //Act
            fixture.execute_command();

            //Assert
            Assert.IsTrue(fixture.response.messages.Count() == 3);
            Assert.IsTrue(fixture.response.messages.Select(msg => msg.field_name).Contains("duration.hours"));
            Assert.IsTrue(fixture.response.messages.Select(msg => msg.field_name).Contains("duration.minutes"));
            Assert.IsTrue(fixture.response.messages.Select(msg => msg.message).Contains(WarningMessages.warning_03_0031));

        }


        [TestMethod]
        public void if_updated_time_allocation_is_exist_changed_to_refer_to_an_existing_time_allocaton()
        {
            // Arrange
            var all_shift__occurrences = fixture.get_all_shift_occurrences(fixture.request);

            // Act
            fixture.execute_command();


            var time_allocation_for_response = fixture.get_backing_time_allocation(fixture.response.result);

            //Assert
            foreach (var occurrence in all_shift__occurrences)
            {
                Assert.AreEqual(occurrence.time_allocation, time_allocation_for_response);
            }
        }

        [TestMethod]
        public void id_uodated_time_allocation_is_not_exist_changed_to_refer_to_the_new_time_allocaton()
        {
            // Arrange
            fixture.request.shift_title = "a very very different title";

            // Arrange
            var all_shift__occurrences_time_allocations = fixture.get_all_shift_occurrences(fixture.request).Select(oc=>oc.time_allocation).ToList();

            // Act
            fixture.execute_command();

            var time_allocation_for_response = fixture.get_backing_time_allocation(fixture.response.result);

            //Assert
            foreach (var time_allocations in all_shift__occurrences_time_allocations)
            {
                Assert.AreNotEqual(time_allocations, time_allocation_for_response);
            }
        }



        //// if the requested time allocation exist then it should re-use it.
        //[TestMethod]
        //public void changed_to_refer_to_an_existing_time_allocaton()
        //{
        //    // Arrange
        //    var request = new EditAllShiftOccurrencesRequest
        //                            {
        //                                operations_calendar_id = fixture.request.operations_calendar_id,
        //                                shift_calendar_id = fixture.request.shift_calendar_id,
        //                                shift_calendar_pattern_id = fixture.request.shift_calendar_pattern_id,
        //                                shift_occurrence_id = fixture.request.shift_occurrence_id,
        //                                colour = new RGBColourRequest() { R = 12, G = 13, B = 14 },
        //                                duration = new DurationRequest { hours = "0", minutes = "40" },
        //                                start_time = new TimeRequest { hours = "01", minutes = "00" },
        //                                shift_title = "c time allocation"

        //                            };

        //    var all_shift__occurrences = fixture.get_all_shift_occurrences(request);

        //    // Act
        //    fixture.execute_command();

        //    // Assert           
        //    foreach (var occurrence in all_shift__occurrences)
        //    {
        //        occurrence.time_allocation.title.Should().Be(request.shift_title);

        //        var colour = occurrence.time_allocation.colour.to_rgb_colour_request_from_persistence_format();

        //        colour.R.Should().Be(request.colour.R);
        //        colour.G.Should().Be(request.colour.G);
        //        colour.B.Should().Be(request.colour.B);

        //        var start_time = occurrence.time_allocation.start_time_in_seconds_from_midnight.ToTimeRequestFromSeconds();
        //        start_time.hours.Should().Be(request.start_time.hours);
        //        start_time.minutes.Should().Be(request.start_time.minutes);

        //        var duration = occurrence.time_allocation.duration_in_seconds.to_duration_request();
        //        duration.hours.Should().Be(request.duration.hours);
        //        duration.minutes.Should().Be(request.duration.minutes);
        //    }

        //}

        //// if the requested time allocation does not exist then it should use the newly created one.
        //[TestMethod]
        //public void changed_to_refer_to_the_new_time_allocaton()
        //{
        //    // Arrange
        //    var request = new EditAllShiftOccurrencesRequest
        //    {
        //        operations_calendar_id = fixture.request.operations_calendar_id,
        //        shift_calendar_id = fixture.request.shift_calendar_id,
        //        shift_calendar_pattern_id = fixture.request.shift_calendar_pattern_id,
        //        shift_occurrence_id = fixture.request.shift_occurrence_id,
        //        colour = new RGBColourRequest() { R = 23, G = 41, B = 32 },
        //        duration = new DurationRequest { hours = "1", minutes = "20" },
        //        start_time = new TimeRequest { hours = "00", minutes = "50" },
        //        shift_title = "K time allocation"

        //    };

        //    var all_shift__occurrences = fixture.get_all_shift_occurrences(request);

        //    // Act
        //    fixture.execute_command();

        //    // Assert           
        //    foreach (var occurrence in all_shift__occurrences)
        //    {
        //        occurrence.time_allocation.title.Should().Be(request.shift_title);

        //        var colour = occurrence.time_allocation.colour.to_rgb_colour_request_from_persistence_format();

        //        colour.R.Should().Be(request.colour.R);
        //        colour.G.Should().Be(request.colour.G);
        //        colour.B.Should().Be(request.colour.B);

        //        var start_time = occurrence.time_allocation.start_time_in_seconds_from_midnight.ToTimeRequestFromSeconds();
        //        start_time.hours.Should().Be(request.start_time.hours);
        //        start_time.minutes.Should().Be(request.start_time.minutes);

        //        var duration = occurrence.time_allocation.duration_in_seconds.to_duration_request();
        //        duration.hours.Should().Be(request.duration.hours);
        //        duration.minutes.Should().Be(request.duration.minutes);
        //    }

        //}

        protected override void test_setup()
        {
            base.test_setup();

            fixture = DependencyResolver.resolve<EditAllShiftOccurrencesFixture>();
        }

        private EditAllShiftOccurrencesFixture fixture;
    }
}