using System;
using System.Collections.Generic;
using System.Linq;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.DomainTypes.Primitives.Sanitisation;

namespace WTS.WorkSuite.Library.DomainTypes.Duration.Validators.IsBetweenOneMinuteAndTwentyFourHours
{
    public class DurationIsBetweenOneMinuteAndTwentyFourHours
    {
        public DurationValidationResult execute
                                        (DurationRequest durationRequest)
        {
            return this
                .set_request(durationRequest)
                .sanatise_request()
                .validate_has_been_fully_specified()
                .validate_components()
                .calculate_duration_in_second()
                .validate_duration_is_within_one_minuts_and_twenty_four_hour_period()
                ;
        }

        private DurationIsBetweenOneMinuteAndTwentyFourHours set_request
                                                                    (DurationRequest the_duration_request)
        {
            duration_request = Guard.IsNotNull(the_duration_request, "the_duration_request");

            return this;
        }

        private DurationIsBetweenOneMinuteAndTwentyFourHours sanatise_request()
        {
            if (result.has_been_decided()) return this;
            Guard.IsNotNull(duration_request, "duration_request");

            duration_request = new DurationRequest
            {
                hours = duration_request.hours.normalise_for_persistence()
            ,
                minutes = duration_request.minutes.normalise_for_persistence()
            };
            return this;
        }

        private DurationIsBetweenOneMinuteAndTwentyFourHours validate_has_been_fully_specified()
        {
            if (result.has_been_decided()) return this;

            Guard.IsNotNull(duration_request, "duration_request");

            var errors = new List<DurationValidationError>();

            if (String.IsNullOrWhiteSpace(duration_request.hours)) { errors.Add(new DurationValidationError.Duration_HoursIsNotSpecified("hours")); }

            if (String.IsNullOrWhiteSpace(duration_request.minutes)) { errors.Add(new DurationValidationError.Duration_MinutesIsNotSpecified("minutes")); }

            if (errors.Any())
            {
                result = new DurationValidationResult.Error(errors);
            }
            return this;
        }

        private DurationIsBetweenOneMinuteAndTwentyFourHours validate_components()
        {
            if (result.has_been_decided()) return this;
            Guard.IsNotNull(duration_request, "duration_request");

            var errors = new List<DurationValidationError>();

            duration_request
                  .hours
                  .duration_hour_is_valid(
                       is_valid:
                          duration_hour => hours = duration_hour,

                       is_not_valid:
                           error => errors.Add(new DurationValidationError.Duration_HoursIsNotANumber("hours"))
                );

            duration_request
                  .minutes
                  .duration_minutes_is_valid(
                       is_valid:
                           duration_minutes => minutes = duration_minutes,

                       is_not_valid:
                           error => errors.Add(new DurationValidationError.Duration_MinutesIsNotANumber("minutes"))
                );

            if (errors.Any())
            {
                result = new DurationValidationResult.Error(errors);
            }
            return this;
        }

        private DurationIsBetweenOneMinuteAndTwentyFourHours calculate_duration_in_second()
        {
            if (result.has_been_decided()) return this;
            Guard.PremiseHolds(hours.HasValue, "hours.HasValue");
            Guard.PremiseHolds(minutes.HasValue, "minutes.HasValue");

            const int sixty_seconds = 60;
            var hours_in_seconds = hours.Value * (sixty_seconds * sixty_seconds);
            var minutes_in_seconds = minutes.Value * sixty_seconds;

            duration_in_seconds = hours_in_seconds + minutes_in_seconds;
            return this;
        }

        private DurationValidationResult validate_duration_is_within_one_minuts_and_twenty_four_hour_period()
        {
            if (result.has_been_decided()) return result;
            Guard.IsNotNull(duration_in_seconds, "duration_in_seconds");
            var errors = new List<DurationValidationError>();

            duration_in_seconds
                .Value.check_duration_is_between_one_minute_and_twenty_four_hour(
                
                  is_valid:
                        duration_in_second_from_midnight => duration_in_seconds = duration_in_second_from_midnight, is_not_valid:
                        error => errors.Add(new DurationValidationError.DurationIsNotIn24hour()));

            if (!errors.Any())
            {
                return new DurationValidationResult.Valid(duration_in_seconds.Value);
            }
            return new DurationValidationResult.Error(errors);
        }

        private DurationRequest duration_request;
        private DurationValidationResult result;
        private int? hours;
        private int? minutes;
        private int? duration_in_seconds;
    }
}