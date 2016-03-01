using System;
using System.Collections.Generic;
using System.Linq;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Library.DomainTypes.Duration.Validators
{
    public static class DurationValidationExtension
    {
        public static void duration_hour_is_valid
                                            (this string duration_hour_request
                                            , Action<int?> is_valid
                                            , Action<IEnumerable<DurationValidationError.Duration_HoursIsNotANumber>> is_not_valid)
        {
            Guard.IsNotNull(duration_hour_request, "duration_hour_request");

            int hours_as_number;
            var is_hour__a_number = (int.TryParse(duration_hour_request, out hours_as_number));

            bool hour_is_not_a_number = !is_hour__a_number;

            if (hour_is_not_a_number || (hours_as_number < 0))
            {
                is_not_valid(new List<DurationValidationError.Duration_HoursIsNotANumber>());
            }
            else
            {
                is_valid((new DurationValidationResult.Valid(hours_as_number)).duration_in_seconds);
            }
        }

        public static void duration_minutes_is_valid
                                            (this string duration_minutes_request
                                            , Action<int?> is_valid
                                            , Action<IEnumerable<DurationValidationError.Duration_MinutesIsNotANumber>> is_not_valid)
        {
            Guard.IsNotNull(duration_minutes_request, "duration_minutes_request");

            int minute_as_number;
            var minutes_is_a_number = (int.TryParse(duration_minutes_request, out minute_as_number));

            bool minutes_is_not_a_number = !minutes_is_a_number;
            bool minutes_is_not_within_0_to_59_range = !Enumerable.Range(0, 60).Contains(minute_as_number);

            if (minutes_is_not_within_0_to_59_range || minutes_is_not_a_number)
            {
                is_not_valid(new List<DurationValidationError.Duration_MinutesIsNotANumber>());
            }
            else
            {
                is_valid((new DurationValidationResult.Valid(minute_as_number)).duration_in_seconds);
            }
        }


       public static List<DurationValidationError.DurationIsNotIn24hour> check_duration_is_between_one_minute_and_twenty_four_hour
                                                                      (this int duration_request
                                                                      , Action<int?> is_valid
                                                                      , Action<IEnumerable<DurationValidationError.DurationIsNotIn24hour>> is_not_valid)
       {
           Guard.IsNotNull(duration_request, "duration_request");
           var errors = new List<DurationValidationError.DurationIsNotIn24hour>();

           const int twenty_four_hour_in_seconds = 24 * (60 * 60);

           if (!Enumerable.Range(1, twenty_four_hour_in_seconds + 1).Contains(duration_request))
           {
               is_not_valid(errors);
           }
           else
           {
               is_valid((new DurationValidationResult.Valid(duration_request)).duration_in_seconds);
           }
           return errors;
       }

       public static List<DurationValidationError.DurationIsNotIn24hour> check_duration_is_between_zero_and_twenty_four_hour
                                                                       (this int duration_request
                                                                       , Action<int?> is_valid
                                                                       , Action<IEnumerable<DurationValidationError.DurationIsNotIn24hour>> is_not_valid)
       {
           Guard.IsNotNull(duration_request, "duration_request");
           var errors = new List<DurationValidationError.DurationIsNotIn24hour>();

           const int twenty_four_hour_in_seconds = 24 * (60 * 60);

           if (!Enumerable.Range(0, twenty_four_hour_in_seconds + 1).Contains(duration_request))
           {
               is_not_valid(errors);
           }
           else
           {
               is_valid((new DurationValidationResult.Valid(duration_request)).duration_in_seconds);
           }
           return errors;
       }  
    }
}