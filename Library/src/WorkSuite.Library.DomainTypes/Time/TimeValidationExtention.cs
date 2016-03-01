using System;
using System.Collections.Generic;
using System.Linq;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.DomainTypes.Time.Validators;

namespace WTS.WorkSuite.Library.DomainTypes.Time
{
    public static class TimeValidationExtention
    {

        public static List<TimeValidationError.TimeIsMoreThanTwentyFourHoursError> check_time_is_in_twenty_four_hour
                                                                             (this int start_time_request
                                                                                 , Action<int?> is_valid
                                                                                 , Action<IEnumerable<TimeValidationError.TimeIsMoreThanTwentyFourHoursError>> is_not_valid){                                                                                                  
            Guard.IsNotNull(start_time_request, "request");
            var errors = new List<TimeValidationError.TimeIsMoreThanTwentyFourHoursError>();
            const int twenty_four_hours_in_second = 24* (60*60);

            if (!Enumerable.Range(0,twenty_four_hours_in_second + 1).Contains(start_time_request))
            {
                is_not_valid(errors);
            }

            else
            {
                is_valid((new TimeValidationResult.Valid(start_time_request).time_in_seconds_from_midnight));

            }

            return errors;
        }
                                                                            
        public static List<TimeValidationError.Time_HoursIsNotANumber> start_time_hour_is_valid_in_twenty_four_hour
                                                                             (this string hours_request
                                                                             , Action<int?> is_valid
                                                                             , Action<IEnumerable<TimeValidationError.Time_HoursIsNotANumber>> is_not_valid)
        {
            Guard.IsNotNull(hours_request, "request");
            var errors = new List<TimeValidationError.Time_HoursIsNotANumber>();
            int hours_as_number;
            var hour_is_a_number = (int.TryParse(hours_request, out hours_as_number));

            if (!Enumerable.Range(0,25).Contains(hours_as_number) || !hour_is_a_number)
            {
                is_not_valid(errors);
            }

            else
            {
                is_valid((new TimeValidationResult.Valid(hours_as_number)).time_in_seconds_from_midnight);

            }

            return errors;
        }

        public static List<TimeValidationError.Time_MinutesIsNotANumber> check_minutes_validation
                                                                            (this string minutes_request
                                                                                , Action<int?> is_valid
                                                                                , Action<IEnumerable<TimeValidationError.Time_MinutesIsNotANumber>> is_not_valid)
        {
            Guard.IsNotNull(minutes_request, "request");
            var errors = new List<TimeValidationError.Time_MinutesIsNotANumber>();
            int minute_as_number;
            var minutes_is_a_number = (int.TryParse(minutes_request, out minute_as_number));

            if (!Enumerable.Range(0,60).Contains(minute_as_number) || !minutes_is_a_number)
            {
                is_not_valid(errors);
            }
            else
            {
                is_valid((new TimeValidationResult.Valid(minute_as_number)).time_in_seconds_from_midnight);

            }

            return errors;
        }
    }                                                                      
}