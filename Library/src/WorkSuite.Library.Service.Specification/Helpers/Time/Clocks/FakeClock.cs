using System;
using WTS.WorkSuite.Library.DomainTypes.Time.Clocks;

namespace WorkSuite.Library.Service.Specification.Helpers.Time.Clocks {

    public class FakeClock 
                    : Clock {

        public override UtcTime now () {

            return time_provided_by_the_clock;
        }

        public UtcTime time_provided_by_the_clock { get; set; }

        public FakeClock () {

            var time = DateTime.UtcNow;

            time_provided_by_the_clock = new UtcTime( 
                year: time.Year,
                month: time.Month,
                day: time.Day,

                hours: time.Hour,
                minutes: time.Minute,
                seconds: time.Second,
                milliseconds: time.Millisecond
            );
        }

        public bool is_clock_time ( DateTime time_to_validate ) {

            return time_provided_by_the_clock.year == time_to_validate.Year
                && time_provided_by_the_clock.month == time_to_validate.Month
                && time_provided_by_the_clock.day == time_to_validate.Day

                && time_provided_by_the_clock.hours == time_to_validate.Hour
                && time_provided_by_the_clock.minutes == time_to_validate.Minute
                && time_provided_by_the_clock.seconds == time_to_validate.Second
                && time_provided_by_the_clock.milliseconds == time_to_validate.Millisecond
                ;
        }
    }
}