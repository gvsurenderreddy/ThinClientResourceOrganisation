using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.Library.DomainTypes.Colour;
using WTS.WorkSuite.Library.DomainTypes.Duration;
using WTS.WorkSuite.Library.DomainTypes.Time;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.ShiftTemplates.Features.ShiftDetails.GetAll
{
    [TestClass]
    public class Correctly_maps_the_fields
                              : GetAllFixture
    {
        [TestMethod]
        public void maps_the_shift_template_title()
        {
            var shift_template = add_shift_template()
                .shift_title("6:00-16:00")
                .entity;

            Assert.AreEqual(query.execute().result.First().shift_title, shift_template.shift_title);

        }

        [TestMethod]
        public void maps_the_shift_template_start_time()
        {
            var shift_template = add_shift_template()
               .start_time(new TimeRequest()
               {
                   hours = "02",
                   minutes = "30"
               })
               .entity;

            var hour_in_entity = query.execute().result.First().start_time.hours;
            var minute_in_entity = query.execute().result.First().start_time.minutes;

            Assert.AreEqual(hour_in_entity, shift_template.start_time_in_seconds_from_midnight.ToTimeRequestFromSeconds().hours);
            Assert.AreEqual(minute_in_entity, shift_template.start_time_in_seconds_from_midnight.ToTimeRequestFromSeconds().minutes);
        }

        [TestMethod]
        public void maps_the_shift_template_duration()
        {
            var shift_template = add_shift_template()
               .duration(new DurationRequest()
               {
                   hours = "02",
                   minutes = "30"
               })
               .entity;

            var hour_in_entity = query.execute().result.First().duration.hours;
            var minute_in_entity = query.execute().result.First().duration.minutes;

            Assert.AreEqual(hour_in_entity, shift_template.duration_in_seconds.to_duration_request().hours);
            Assert.AreEqual(minute_in_entity, shift_template.duration_in_seconds.to_duration_request().minutes);
        }

        [TestMethod]
        public void maps_the_shift_template_colour()
        {
            var shift_template = add_shift_template()
                .colour(new RgbColour(12, 58, 96))
                .entity;
            var R_colour_in_entity = query.execute().result.First().colour.R;
            var G_colour_in_entity = query.execute().result.First().colour.G;
            var B_colour_in_entity = query.execute().result.First().colour.B;

            Assert.AreEqual(R_colour_in_entity, shift_template.colour.rgb_colour_format().R);
            Assert.AreEqual(G_colour_in_entity, shift_template.colour.rgb_colour_format().G);
            Assert.AreEqual(B_colour_in_entity, shift_template.colour.rgb_colour_format().B);
        }

        [TestMethod]
        public void end_time_should_be_correct_if_total_of_start_time_and_duration_is_greater_than_twenty_four()
        {
            add_shift_template()
              .start_time(new TimeRequest() { hours = "18", minutes = "00" })
              .duration(new DurationRequest() { hours = "8", minutes = "30" })
              ;

            var expected_end_time = new TimeRequest
            {
                hours = "02",
                minutes = "30"
            };


            var details = query.execute().result.First();

            Assert.AreEqual(expected_end_time.hours, details.end_time.hours);
            Assert.AreEqual(expected_end_time.minutes, details.end_time.minutes);

        }

        [TestMethod]
        public void end_time_should_be_correct_if_total_of_start_time_and_duration_is_less_than_twenty_four()
        {
            // arrange
            add_shift_template()
                     .start_time(new TimeRequest() { hours = "14", minutes = "00" })
                     .duration(new DurationRequest() { hours = "8", minutes = "30" })
                     ;

            var expected_end_time = new TimeRequest
            {
                hours = "22",
                minutes = "30"
            };

            // act
            var details = query.execute().result.First();

            // assert
            Assert.AreEqual(expected_end_time.hours, details.end_time.hours);
            Assert.AreEqual(expected_end_time.minutes, details.end_time.minutes);

        }

        [TestMethod]
        public void end_time_should_zero_if__start_time_and_duration_is_twenty_four()
        {
            add_shift_template()
             .start_time(new TimeRequest() { hours = "24", minutes = "00" })
             .duration(new DurationRequest() { hours = "24", minutes = "00" })
             ;

            var expected_end_time = new TimeRequest
            {
                hours = "00",
                minutes = "00"
            };
            var details = query.execute().result.First();

            Assert.AreEqual(expected_end_time.hours, details.end_time.hours);
            Assert.AreEqual(expected_end_time.minutes, details.end_time.minutes);

        }

        [TestMethod]
        public void end_time_should_24_if__start_time_is_zero_and_duration_is_twenty_four()
        {
             add_shift_template()
              .start_time(new TimeRequest() { hours = "00", minutes = "00" })
              .duration(new DurationRequest() { hours = "24", minutes = "00" })
              ;

            var expected_end_time = new TimeRequest
            {
                hours = "24",
                minutes = "00"
            };

            var details = query.execute().result.First();

            Assert.AreEqual(expected_end_time.hours, details.end_time.hours);
            Assert.AreEqual(expected_end_time.minutes, details.end_time.minutes);

        }


    }
}