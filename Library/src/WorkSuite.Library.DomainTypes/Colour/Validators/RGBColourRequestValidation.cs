using System;
using System.Collections.Generic;
using System.Linq;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Library.DomainTypes.Colour.Validators
{
    public class RGBColourRequestValidation
    {
        public RGBColourValidationResult execute
                                           (RGBColourRequest theRgbColourRequest)
        {
            return this
                .set_request(theRgbColourRequest)
                .validate_colour_componant()
                .create_valid_colour_response();

        }

        private RGBColourRequestValidation set_request
                                           (RGBColourRequest theRgbColourRequest)
        {
            rgb_colour_request = Guard.IsNotNull(theRgbColourRequest, "the_colour_request");
            return this;
        }


        private RGBColourRequestValidation validate_colour_componant()
        {
            Guard.IsNotNull(rgb_colour_request, "rgb_colour_request");
            var errors = new List<ColourValidationError>();

            rgb_colour_is_in_range(errors, rgb_colour_request.R, "colour.R");
            rgb_colour_is_in_range(errors, rgb_colour_request.G, "colour.R");
            rgb_colour_is_in_range(errors, rgb_colour_request.B, "colour.R");

            if (errors.Any())
            {
                result = new RGBColourValidationResult.Error(errors);
            }
            return this;
        }

        private void rgb_colour_is_in_range(List<ColourValidationError> errors, int? rgb_colour, string field_name)
        {
            const int begin_range = 0;
            const int end_range = 255;

            if (!rgb_colour.Value.IsInRange(begin_range, end_range))
            {
                errors.Add(new ColourValidationError.colourIsNotInTheCorrectFormat(field_name));
            }

        }

        private RGBColourValidationResult create_valid_colour_response()
        {
            if (result.has_been_decieded()) return result;
            var errors = new List<ColourValidationError>();

            var actual_rgb_colour = new RgbColour(Convert.ToByte(rgb_colour_request.R), Convert.ToByte(rgb_colour_request.G), Convert.ToByte(rgb_colour_request.B));
            if (!errors.Any())
            {
                return new RGBColourValidationResult.Valid(actual_rgb_colour);
            }
            return new RGBColourValidationResult.Error(errors);
        }

        private RGBColourRequest rgb_colour_request;

        private RGBColourValidationResult result;

    }
}