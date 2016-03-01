using System;
using System.Collections.Generic;
using System.Linq;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.DomainTypes.Primitives.Sanitisation;

namespace WTS.WorkSuite.Library.DomainTypes.Time.Validators.IsWithInATwentyFourHourDay
{
    public class TimeIsWithinATwentyFourHourDay {


        public TimeValidationResult execute
                                            ( TimeRequest the_time_request )
        {

            return this
                .set_request(the_time_request)
                .sanatise_request()
                .validate_has_been_fully_specified()
                .validate_components()
                .calculate_start_time_in_second()
                .validate_time_is_within_twenty_four_hour_period();

        }
        private TimeIsWithinATwentyFourHourDay set_request
                                                ( TimeRequest the_time_request ) {
            
            time_request = Guard.IsNotNull( the_time_request, "the_time_request" );
            return this;
        }

        private TimeIsWithinATwentyFourHourDay sanatise_request()
        {
            if (result != null) { return this; }
            Guard.IsNotNull(time_request, "time_request");
            time_request=new TimeRequest()
            {
                hours = time_request.hours.normalise_for_persistence(),
                minutes = time_request.minutes.normalise_for_persistence()
            };

            return this;
        }

        private TimeIsWithinATwentyFourHourDay validate_has_been_fully_specified() {
            
            if ( result != null ) { return this;}

            
            Guard.IsNotNull( time_request, "request" );

            var errors = new List<TimeValidationError>();
            if (String.IsNullOrWhiteSpace(time_request.hours)) { errors.Add( new TimeValidationError.Time_HoursIsNotspecified("hours")); }
            if (String.IsNullOrWhiteSpace(time_request.minutes)) { errors.Add( new TimeValidationError.Time_MinutesIsNotspecified("minutes")); }

            if (errors.Any()) {
                result = new TimeValidationResult.Error( errors );
            }
            return this;         
        }

        private TimeIsWithinATwentyFourHourDay validate_components() {

            if (result != null) { return this; } 

            Guard.IsNotNull( time_request, "request" );

            var errors = new List<TimeValidationError>();

            time_request
                .hours
                .start_time_hour_is_valid_in_twenty_four_hour(

                    is_valid:
                        clock_hours => hours = clock_hours,

                    is_not_valid:
                        error => errors.Add(new TimeValidationError.Time_HoursIsNotANumber("hours"))

                );

            time_request
                .minutes
                .check_minutes_validation(

                     is_valid:
                         clock_minutes => minutes = clock_minutes,
                     
                     is_not_valid:
                         error => errors.Add(new TimeValidationError.Time_MinutesIsNotANumber("minutes"))
                );

             if (errors.Any()) {
              result = new TimeValidationResult.Error(errors);
             }

            return this;
        }

        private TimeIsWithinATwentyFourHourDay calculate_start_time_in_second() {
            if (result != null) { return this; } 

            Guard.PremiseHolds(hours.HasValue, "hours.HasValue");
            Guard.PremiseHolds(minutes.HasValue, "minutes.HasValue");
            
            start_time_in_second = hours.Value * 60 * 60 + minutes.Value * 60;
            return this;

        }

        private TimeValidationResult validate_time_is_within_twenty_four_hour_period () {

            if (result.has_been_decided()) return result;

            Guard.IsNotNull(start_time_in_second, "start_time_in_second");
            var errors = new List<TimeValidationError>();

            start_time_in_second
                .Value
                .check_time_is_in_twenty_four_hour(
                 
                  is_valid:
                         clock_time_in_seconds_from_midnight => start_time_in_second = clock_time_in_seconds_from_midnight,
                    
                  is_not_valid:
                         error => errors.Add(new TimeValidationError.TimeIsMoreThanTwentyFourHoursError())
                
                );
        
            if (!errors.Any())
            {
                return new TimeValidationResult.Valid(start_time_in_second.Value);
            }

           return new TimeValidationResult.Error(errors);
        }
        
        private TimeRequest time_request;
        private TimeValidationResult result;
        private int? hours;
        private int? minutes;
        private int? start_time_in_second;

    }

   
}