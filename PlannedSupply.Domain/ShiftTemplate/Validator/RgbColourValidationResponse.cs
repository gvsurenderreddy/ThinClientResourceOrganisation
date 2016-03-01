using System;
using System.Collections.Generic;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.DomainTypes.Colour;

namespace WTS.WorkSuite.PlannedSupply.ShiftTemplate.Validator
{
    public abstract class RgbColourValidationResponse
    {
        public sealed class valid
                                : RgbColourValidationResponse
        {
            public RgbColour colour_in_rgb_format { get; set; }

            public valid
                    ( RgbColour colour_in_second )
            {
                this.colour_in_rgb_format = colour_in_second;
            }
        }

        public sealed class Error
                                : RgbColourValidationResponse
        {
            public IEnumerable<ResponseMessage> errors { get; set; }

            public Error
                    ( IEnumerable<ResponseMessage> errors )
            {
                this.errors = errors;
            }
        }
    }


    public static class RgbColourValidationResponseExtention
    {
        public static void Match
                            ( this RgbColourValidationResponse response
                            , Action<RgbColour> is_valid
                            , Action<IEnumerable<ResponseMessage>> is_not_valid ) {

            Guard.IsNotNull(is_valid, "is_valid");
            Guard.IsNotNull(is_not_valid, "is_not_valid");

            if (response is RgbColourValidationResponse.valid)
            {
                is_valid((response as RgbColourValidationResponse.valid).colour_in_rgb_format);
                return;
            }

            if (response is RgbColourValidationResponse.Error)
            {
                is_not_valid((response as RgbColourValidationResponse.Error).errors);
                return;
            }

            throw new Exception("unmatched case");
        }
    }

}