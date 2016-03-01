using System.Collections.Generic;
using System.Linq;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.DomainTypes.Primitives.Sanitisation;

namespace WTS.WorkSuite.Library.DomainTypes.Duration.Validators.IsSpeciftyAndIsANumber
{
    public class DurationIsSpecifyAndIsANumber
    {
        public DurationValidationResult execute ( DurationRequest duration_request)
        {
            return 
                set_request(duration_request)
               .sanatise_request()
               .validate_has_been_fully_specified()
               .validate_componants()
               .calculate_duration_in_secoonds()
               .duration_result();
        }

        private DurationIsSpecifyAndIsANumber set_request(DurationRequest duration_request)
        {
            request = Guard.IsNotNull(duration_request, "duration_request");
            return this;
        }

        private DurationIsSpecifyAndIsANumber sanatise_request()
        {
            if (result.has_been_decided()) return this;
            Guard.IsNotNull(request, "request");

            request.hours.normalise_for_persistence();
            request.minutes.normalise_for_persistence();
            return this;
        }

        private DurationIsSpecifyAndIsANumber validate_has_been_fully_specified()
        {
            if (result.has_been_decided()) return this;
            Guard.IsNotNull(request, "request");

            var errors = new List<DurationValidationError>();
            if (string.IsNullOrWhiteSpace(request.hours)) { errors.Add(new DurationValidationError.Duration_HoursIsNotSpecified("hours"));
                                                            errors.Add(new DurationValidationError.Duration_MinutesIsNotSpecified("minutes"));}
            if (string.IsNullOrWhiteSpace(request.minutes)) { errors.Add(new DurationValidationError.Duration_HoursIsNotSpecified("hours")); 
                                                              errors.Add(new DurationValidationError.Duration_MinutesIsNotSpecified("minutes"));}

            if (errors.Any())
            {
                result=new DurationValidationResult.Error(errors);
            }
            return this;
        }

        private DurationIsSpecifyAndIsANumber validate_componants()
        {
            if (result.has_been_decided()) return this;
            Guard.IsNotNull(request, "request");

            var errors = new List<DurationValidationError>();

            request
                .hours
                .duration_hour_is_valid(
                       is_valid:
                            duration_hour => hours=duration_hour,

                       is_not_valid:
                           error => { errors.Add(new DurationValidationError.Duration_HoursIsNotANumber("hours"));
                                      errors.Add(new DurationValidationError.Duration_MinutesIsNotANumber("minutes"));}
                );

            request
                .minutes
                .duration_minutes_is_valid(
                       is_valid:
                            duration_minutes => minutes=duration_minutes,
                       
                       is_not_valid:
                            error =>
                            {
                                errors.Add(new DurationValidationError.Duration_HoursIsNotANumber("hours"));
                                errors.Add(new DurationValidationError.Duration_MinutesIsNotANumber("minutes"));
                            }
                );

            if (errors.Any())
            {
                result=new DurationValidationResult.Error(errors);
            }
            return this;
        }

        private DurationIsSpecifyAndIsANumber calculate_duration_in_secoonds()
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

        private DurationValidationResult duration_result()
        {
            if (result.has_been_decided()) return result;
            Guard.IsNotNull(duration_in_seconds, "duration_in_seconds");
            var errors = new List<DurationValidationError>();

            if (!errors.Any())
            {
                return new DurationValidationResult.Valid(duration_in_seconds.Value);
            }
            return new DurationValidationResult.Error(errors);
        }

        private DurationRequest request;
        private DurationValidationResult result;
        private int? hours;
        private int? minutes;
        private int? duration_in_seconds;
    }
}