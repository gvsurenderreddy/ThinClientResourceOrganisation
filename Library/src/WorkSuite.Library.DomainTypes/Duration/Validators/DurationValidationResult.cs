using System;
using System.Collections.Generic;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Library.DomainTypes.Duration.Validators
{
    public abstract class DurationValidationResult {

        public sealed class Valid
                                : DurationValidationResult {

            public int duration_in_seconds { get; private set; }

            public Valid( int duration_in_seconds ) {
                this.duration_in_seconds = duration_in_seconds;
            }
        }

        public sealed class Error
                                : DurationValidationResult {


            public IEnumerable<DurationValidationError> errors { get; private set; }

            public Error ( IEnumerable<DurationValidationError> errors ) {
                this.errors = errors;
            }
        }
    }

    public abstract class DurationValidationError {

       public sealed class Duration_HoursIsNotSpecified
                                : DurationValidationError {

            public string field_name { get; private set; }

            public Duration_HoursIsNotSpecified
                        ( string field_name ) {

                this.field_name = field_name;
            }            
       }

      public sealed class Duration_MinutesIsNotSpecified
                               : DurationValidationError
       {

           public string field_name { get; private set; }

           public Duration_MinutesIsNotSpecified
                       (string field_name)
           {

               this.field_name = field_name;
           }
       }

        
        public sealed class Duration_HoursIsNotANumber
                                : DurationValidationError
        {

            public string field_name { get; private set; }

            public Duration_HoursIsNotANumber
                        (string fieldName)
            {

                this.field_name = fieldName;
            }

        }

        public sealed class Duration_MinutesIsNotANumber
                                        : DurationValidationError
        {

            public string field_name { get; private set; }

            public Duration_MinutesIsNotANumber
                        (string fieldName)
            {

                this.field_name = fieldName;
            }

        }
       
        
        
        public sealed class DurationIsNotIn24hour
                                : DurationValidationError{ }
    }

    public static class DurationValidationResultExtension {

        public static bool has_been_decided
                        ( this DurationValidationResult result ) {

            return result != null;
        }


        public static T Match<T>
                         ( this DurationValidationResult validation_result
                         , Func<int, T> is_valid
                         , Func<IEnumerable<DurationValidationError>, T> is_not_valid ) {


            Guard.IsNotNull( is_valid, "is_valid");
            Guard.IsNotNull( is_not_valid, "is_valid");


            if ( validation_result is DurationValidationResult.Valid ) {
                return is_valid(  ( validation_result as DurationValidationResult.Valid ).duration_in_seconds  );
            }

            if (validation_result is DurationValidationResult.Error) {
                return is_not_valid( ( validation_result as DurationValidationResult.Error).errors);
            }

            throw new Exception("Unmatched case");
        }


        public static void Match
                            ( this DurationValidationResult validation_result
                            , Action<int> is_valid
                            , Action<IEnumerable<DurationValidationError>> is_not_valid ) {

            Guard.IsNotNull(is_valid, "is_valid" );
            Guard.IsNotNull(is_not_valid, "is_not_valid" );

            validation_result
                .Match(

                is_valid:
                    duration_in_seconds => { is_valid(duration_in_seconds); return new Unit(); },


                is_not_valid:
                    errors => { is_not_valid(errors); return new Unit(); }

                );
        }
    }

    public static class DurationValidationErrorExtention{

        public static void Match
            (this DurationValidationError error
                , Action<DurationValidationError.Duration_HoursIsNotSpecified> hours_not_specified
                , Action<DurationValidationError.Duration_MinutesIsNotSpecified> minutes_not_specified
                , Action<DurationValidationError.Duration_HoursIsNotANumber> hours_not_a_number
                , Action<DurationValidationError.Duration_MinutesIsNotANumber> minutes_not_a_number
                , Action<DurationValidationError.DurationIsNotIn24hour> is_not_in_24_hour)
        {

            Guard.IsNotNull(hours_not_specified, "hours_not_specified");
            Guard.IsNotNull(minutes_not_specified, "minutes_not_specified");
            Guard.IsNotNull(hours_not_a_number, "hours_not_a_number");
            Guard.IsNotNull(minutes_not_a_number, "minutes_not_a_number");
            Guard.IsNotNull(is_not_in_24_hour, "is_not_in_24_hour");
            if (error is DurationValidationError.Duration_HoursIsNotSpecified)
            {
                hours_not_specified((error as DurationValidationError.Duration_HoursIsNotSpecified));
                return;
            }

            if (error is DurationValidationError.Duration_MinutesIsNotSpecified)
            {
                minutes_not_specified((error as DurationValidationError.Duration_MinutesIsNotSpecified));
                return;
            }

            if ( error is DurationValidationError.Duration_HoursIsNotANumber )
            {
                hours_not_a_number((error as DurationValidationError.Duration_HoursIsNotANumber));
                return;
            }

            if (error is DurationValidationError.Duration_MinutesIsNotANumber)
            {
                minutes_not_a_number((error as DurationValidationError.Duration_MinutesIsNotANumber));
                return;
            }

            if (error is DurationValidationError.DurationIsNotIn24hour)
            {
                is_not_in_24_hour( (error as DurationValidationError.DurationIsNotIn24hour) );
                return;
            }
            throw new Exception("Unmatched case.");
        }
    }
}