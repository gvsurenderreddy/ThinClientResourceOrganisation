using System;

namespace WTS.WorkSuite.Library.DomainTypes.Time
{

    // alternative - we have a routine that converst seconds to an hours and minutes class 

    public static class TimeRequestEndTimeExtension
    { 
        private const int twenty_four_hours_in_seconds = 24 * 60 * 60;

        public static TimeRequest return_end_time_in_time_span_format(int end_time_second)
        {
           var time_span = TimeSpan.FromSeconds(end_time_second);
            return new TimeRequest() {hours = time_span.Hours.ToString("00"), minutes = time_span.Minutes.ToString("00")};
        }

        public static TimeRequest calculate_endtime_from_a_start_time_in_seconds_from_midnight
                                                                                     (this int start_time_in_seconds_from_midnight
                                                                                     , int duration_in_seconds)
        {
           
            var end_time_in_seconds_from_midnight = start_time_in_seconds_from_midnight + duration_in_seconds;
            var end_time = return_end_time_in_time_span_format(end_time_in_seconds_from_midnight);

            // if the shift starts at the beginning of the day (00:00) we want to show a 24 hour shift as 00:00 - 24:00
            if ( start_time_in_seconds_from_midnight  == 0  ) {

                return duration_in_seconds == twenty_four_hours_in_seconds
                        ? new TimeRequest(){ hours = "24", minutes = "00"}
                        :  end_time;                
            }

            // if the shifts starts at then end of the day (24:00) we want to show a 24 hour shift as 24:00 - 00:00

            if ( start_time_in_seconds_from_midnight.when_duration_is_greater_than_zero(duration_in_seconds) ) {

                return duration_in_seconds == twenty_four_hours_in_seconds
                        ? new TimeRequest() { hours = "00", minutes = "00" }
                        : end_time;
            }

            // if the start time is 24 and duration is 0 end time  should be 24 .
            if (start_time_in_seconds_from_midnight .when_duratin_is_equal_zero(duration_in_seconds))
            {
                return new TimeRequest() {hours = "24", minutes = "00"};
            }


            // if the shift ends at midnight we want to show a 24 hour shift as 00:05 - 24:00
            if (Convert.ToInt32(end_time.hours) == 0 && Convert.ToInt32(end_time.minutes) == 0) {

                return new TimeRequest() { hours = "24", minutes = "00" };                
            }

            return new TimeRequest() { hours = end_time.hours , minutes = end_time.minutes};
            }

            public static bool when_duration_is_greater_than_zero
                                                        (this int start_time_in_seconds
                                                        , int duration)
            {
               return start_time_in_seconds == twenty_four_hours_in_seconds && duration > 0;
            }
            
            public static bool when_duratin_is_equal_zero
                                                        (this int start_time_in_seconds
                                                        , int duration)
            { 
               return start_time_in_seconds == twenty_four_hours_in_seconds && duration == 0;
            } 
    }
}

