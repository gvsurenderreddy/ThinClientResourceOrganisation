using System;
using System.Collections.Generic;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.PlannedSupply.ShiftTemplate.Validator
{
    public abstract class DurationValidationResponse
    {
        public sealed class valid
                                : DurationValidationResponse
        {
            public int duration_in_second { get; private set; }

            public valid
                    ( int duration_in_second )
            {
                this.duration_in_second = duration_in_second;
            }
        }

        public sealed class Errors
                                : DurationValidationResponse
        {
            public IEnumerable<ResponseMessage> errors { get; private set; }

            public Errors 
                    ( IEnumerable<ResponseMessage> errors )
            {
                this.errors = errors;
            }
        }   
    }


    public static class DurationValidationResponseExtention
    {
        public static void Match
                            ( this DurationValidationResponse response
                            , Action<int> is_valid
                            , Action<IEnumerable<ResponseMessage>> is_not_valid )
        {
            Guard.IsNotNull(is_valid, "is_valid");
            Guard.IsNotNull(is_not_valid, "is_not_valid");

            if (response is DurationValidationResponse.valid)
            {
                is_valid((response as DurationValidationResponse.valid).duration_in_second);
                return;
            }

            if (response is DurationValidationResponse.Errors)
            {
                is_not_valid((response as DurationValidationResponse.Errors).errors);
                return;
            }

            throw new Exception("unmatched case");
        }
    }

}