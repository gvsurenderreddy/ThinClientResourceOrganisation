using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.Library.DomainTypes.Time;

namespace WTS.WorkSuite.Library.DomainTypes.Tests.Time.TimeRequestEndtimeExtensions
{
    public class calculate_endtime_from_a_start_time_in_seconds_from_midnight_will
    {
        // done: ensure that the end time is valid within a twenty four hour clock when calculated against a duration that do not fall a twenty four hour boundary.
        // to do: ensure that the end time is valid within a twenty four hour clock when calculated against a duration that does fall a twenty four hour boundary.

        [TestClass]
        public class durations_that_do_not_fall_on_the_twenty_four_hour_boundary
        {

            // ensure that the end time is valid within a twenty four hour clock.

            // done: end time is on the same day as the start time is reported correctly
            // done : end time that falls on a day after the start time is reported correctly
            // done :end time that falls two days after the start time is reported correctly

            [TestMethod]
            public void end_time_is_on_the_same_day_as_the_start_time_is_reported_correctly()
            {
                const int start_time_in_seconds_from_midnight = 60;
                const int duration_in_seconds = 60;

                var end_time = start_time_in_seconds_from_midnight.calculate_endtime_from_a_start_time_in_seconds_from_midnight(duration_in_seconds);

                end_time.hours.Should().Be("00");
                end_time.minutes.Should().Be("02");
            }

            [TestMethod]
            public void end_time_that_falls_on_a_day_after_the_start_time_is_reported_correctly()
            {
                const int start_time_in_seconds_from_midnight = 60;
                const int duration_in_seconds = 60 * 60 * 24;

                var end_time = start_time_in_seconds_from_midnight.calculate_endtime_from_a_start_time_in_seconds_from_midnight(duration_in_seconds);

                end_time.hours.Should().Be("00");
                end_time.minutes.Should().Be("01");
            }

            [TestMethod]
            public void end_time_that_falls_two_days_after_the_start_time_is_reported_correctly()
            {
                const int start_time_in_second_from_midnight = 60;
                const int duration_in_seconds = (60 * 60 *24)*2;

                var end_time = start_time_in_second_from_midnight.calculate_endtime_from_a_start_time_in_seconds_from_midnight( duration_in_seconds);
                end_time.hours.Should().Be("00");
                end_time.minutes.Should().Be("01");

            }
        }

        [TestClass]
        public class durations_that_fall_on_the_twenty_four_hour_boundary
        {

            //    a. if the start time is 00 and the duration is 24 hours the end time should
            //       be 24:00

            //    b. if the start time is 24 and the duration is 24 then the end time should
            //       be 00:00

            [TestMethod]
            public void if_start_time_is_zero_and_duration_is_twentyfour_end_time_should_be_twentyfour()
            {
                const int start_time_in_seconds_from_midnight = 0;
                const int duration_in_seconds = 24*60*60;

                var end_time =
                    start_time_in_seconds_from_midnight.calculate_endtime_from_a_start_time_in_seconds_from_midnight(duration_in_seconds);
                end_time.hours.Should().Be("24");
                end_time.minutes.Should().Be("00");

            }

            [TestMethod]
            public void if_start_time_is_twenty_four_and_duration_is_zero_end_time_should_return_twenty_four()
            {
                const int start_time_in_seconds_from_midnight = 24*60*60;
                const int duration_in_seconds = 0;

                var end_time =
                    start_time_in_seconds_from_midnight.calculate_endtime_from_a_start_time_in_seconds_from_midnight(duration_in_seconds);
                end_time.hours.Should().Be("24");
                end_time.minutes.Should().Be("00");
            }

            [TestMethod]
            public void if_start_time_is_twenty_four_and_duration_is_twentyfour_end_time_should_return_zero()
            {
                const int start_time_in_seconds_from_midnight = 24 * 60 * 60;
                const int duration_in_seconds = 24 * 60 * 60;

                var end_time =
                    start_time_in_seconds_from_midnight.calculate_endtime_from_a_start_time_in_seconds_from_midnight(duration_in_seconds);
                end_time.hours.Should().Be("00");
                end_time.minutes.Should().Be("00");
            }


            [TestMethod]
            public void if_start_time_is_eghiteen_and_duration_is_eight_end_time_should_return_correct_value()
            {
                const int start_time_in_seconds_from_midnight = 18 * 60 * 60;
                const int duration_in_seconds = 8 * 60 * 60;

                var end_time =
                    start_time_in_seconds_from_midnight.calculate_endtime_from_a_start_time_in_seconds_from_midnight(duration_in_seconds);
                end_time.hours.Should().Be("02");
                end_time.minutes.Should().Be("00");
            }

            [TestMethod]
            public void if_start_time_is_five_minute_and_duration_in_twentythree_fiftyfive_minute_end_time_should_return_twentyfour()
            {
                const int start_time_in_seconds_from_midnight = 5 * 60;
                const int duration_in_seconds = (60*60*23) + (60*55);

                var end_time =
                    start_time_in_seconds_from_midnight.calculate_endtime_from_a_start_time_in_seconds_from_midnight(duration_in_seconds);
                end_time.hours.Should().Be("24");
                end_time.minutes.Should().Be("00");
            }

        }
    }
}