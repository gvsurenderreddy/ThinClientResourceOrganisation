using System;
using System.Collections.Generic;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Library.DomainTypes.Time.Validators
{

    /// <summary>
    ///     This is intended as a type that we can perform a Discriminated union on. So
    /// when we are validating a time request we could have one of two possible outcomes:
    /// it was valid which will result in valid time, or it was not a valid request which 
    /// will result in an error.
    /// </summary>
    public abstract class TimeValidationResult {

        /// <summary>
        ///     Represents a vaild time
        /// </summary>
        public sealed class Valid
                                : TimeValidationResult {
            public int time_in_seconds_from_midnight { get; set; }
            public Valid(int time_in_seconds_from_midnight)
            {
                this.time_in_seconds_from_midnight = time_in_seconds_from_midnight;
            }
                                }

        public sealed class  Error
                                : TimeValidationResult {


            public IEnumerable<TimeValidationError> errors { get; private set; }
            public Error( IEnumerable<TimeValidationError> errors ) {

                        this.errors = errors;
            }
        }
    }

    public static class TimeValidationResultExtensions {

        public static bool has_been_decided
                      (this TimeValidationResult result)
        {
            return result != null;
        }

        public static T Match<T>
                            ( this TimeValidationResult validation_result 
                            , Func<int,T> is_valid
                            , Func<IEnumerable<TimeValidationError>,T> is_not_valid ){

            if ( validation_result is TimeValidationResult.Valid )
            {
                return is_valid((validation_result as TimeValidationResult.Valid).time_in_seconds_from_midnight);
            }

            if ( validation_result is TimeValidationResult.Error )
            {
                return is_not_valid((validation_result as TimeValidationResult.Error).errors );
            }

            throw new Exception("Unmatched case");
        }

        public static void Match
                            ( this TimeValidationResult validation_result 
                            , Action<int> is_valid
                            , Action<IEnumerable<TimeValidationError>> is_not_valid ){
          Guard.IsNotNull(is_valid, "is_valid");
          Guard.IsNotNull(is_not_valid, "is_not_valid");

            validation_result
                .Match(

                    is_valid:
                        valid_result => { is_valid( valid_result ); return new Unit(); },
 
                    is_not_valid:
                        invalid_result => { is_not_valid( invalid_result ); return new Unit(); }

                );
        }
    }

    public abstract class TimeValidationError {

        public sealed class TimeIsMoreThanTwentyFourHoursError
                                : TimeValidationError { }

        public sealed class Time_MinutesIsNotANumber
                                : TimeValidationError {

            public string field_name { get; private set; }

            public Time_MinutesIsNotANumber
                        ( string field_name ) {

                this.field_name = field_name;
            }
        }

        public sealed class Time_HoursIsNotANumber
                                : TimeValidationError
        {

            public string field_name { get; private set; }

            public Time_HoursIsNotANumber
                        (string field_name)
            {

                this.field_name = field_name;
            }
        }

        public sealed class Time_MinutesIsNotspecified
                                    : TimeValidationError
        {
            public string field_name { get; private set; }

            public Time_MinutesIsNotspecified
                                ( string field_name)
            {
                this.field_name = field_name;
            }
        }

        public sealed class Time_HoursIsNotspecified
                                        : TimeValidationError
        {
            public string field_name { get; private set; }

            public Time_HoursIsNotspecified
                                (string field_name)
            {
                this.field_name = field_name;
            }
        }

    }

    public static class TimeValidationErrorExtension {

        public static void Match 
                            ( this TimeValidationError error
                            , Action<TimeValidationError.TimeIsMoreThanTwentyFourHoursError> more_than_twenty_four_hours
                            , Action<TimeValidationError.Time_HoursIsNotANumber> hours_is_not_a_number
                            , Action<TimeValidationError.Time_MinutesIsNotANumber> minutes_is_not_a_number
                            , Action<TimeValidationError.Time_HoursIsNotspecified> hours_is_not_specified
                            , Action<TimeValidationError.Time_MinutesIsNotspecified> minutes_is_not_specified)
        {
            
            Guard.IsNotNull( more_than_twenty_four_hours, "more_than_twenty_four_hours" );
            Guard.IsNotNull(hours_is_not_a_number, "hours_is_not_a_number");
            Guard.IsNotNull(minutes_is_not_a_number, "minutes_is_not_a_number");
            Guard.IsNotNull(hours_is_not_specified, "hours_is_not_specified");
            Guard.IsNotNull(minutes_is_not_specified, "minutes_is_not_specified");

            if ( error is TimeValidationError.TimeIsMoreThanTwentyFourHoursError ) {
                more_than_twenty_four_hours( (error as TimeValidationError.TimeIsMoreThanTwentyFourHoursError) );
                return;
            }

            if ( error is TimeValidationError.Time_HoursIsNotANumber) {
                hours_is_not_a_number((error as TimeValidationError.Time_HoursIsNotANumber));
                return;                
            }

            if (error is TimeValidationError.Time_MinutesIsNotANumber)
            {
                minutes_is_not_a_number((error as TimeValidationError.Time_MinutesIsNotANumber));
                return;
            }

            if ( error is TimeValidationError.Time_HoursIsNotspecified ) {
                hours_is_not_specified((error as TimeValidationError.Time_HoursIsNotspecified));
                return;
            }

            if (error is TimeValidationError.Time_MinutesIsNotspecified)
            {
                minutes_is_not_specified((error as TimeValidationError.Time_MinutesIsNotspecified));
                return;
            }

            throw new Exception( "Unmatched case." );
        }


    }

}