using System;
using System.Collections.Generic;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Library.DomainTypes.Time.Validators
{
    public abstract class TimeValidationResponse
    {
        public sealed class Valid
                                : TimeValidationResponse
        {
            public int time_in_seconds { get; private set; }

            public Valid
                    (int the_time_in_seconds)
            {
                this.time_in_seconds = the_time_in_seconds;
            }
        }

        public sealed class Errors
                                : TimeValidationResponse
        {
            public IEnumerable<ResponseMessage> errors { get; private set; }

            public Errors
                    (IEnumerable<ResponseMessage> errors)
            {
                this.errors = errors;
            }
        }
    }

    public static class TimeValidationResponseExtensions
    {
        public static void Match
                            (this TimeValidationResponse response
                            , Action<int> is_valid
                            , Action<IEnumerable<ResponseMessage>> is_not_valid)
        {
            Guard.IsNotNull(is_valid, "is_valid");
            Guard.IsNotNull(is_not_valid, "is_not_valis");

            if (response is TimeValidationResponse.Valid)
            {
                is_valid((response as TimeValidationResponse.Valid).time_in_seconds);
                return;
            }

            if (response is TimeValidationResponse.Errors)
            {
                is_not_valid((response as TimeValidationResponse.Errors).errors);
                return;
            }

            throw new Exception("Unmatched case");
        }
    }
}