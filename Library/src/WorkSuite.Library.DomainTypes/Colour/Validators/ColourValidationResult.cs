using System;
using System.Collections.Generic;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using Unit = System.Web.UI.WebControls.Unit;

namespace WTS.WorkSuite.Library.DomainTypes.Colour.Validators
{
    public abstract class RGBColourValidationResult
    {
        public sealed class Valid
                              : RGBColourValidationResult{
            public RgbColour colour { get; set; }

            public Valid(RgbColour colour)
            {
                this.colour = colour;
            }
        }

        public sealed class Error
                              : RGBColourValidationResult {
            public IEnumerable<ColourValidationError> errors { get; private set; }
            public Error(IEnumerable<ColourValidationError> errors)
            {

                this.errors = errors;
            }
        }
    }

    public abstract class ColourValidationError
    {
        public sealed class colourIsNotInTheCorrectFormat
                                       : ColourValidationError
        {
             public string field_name { get; private set; }

             public colourIsNotInTheCorrectFormat
                        ( string field_name ) {

                this.field_name = field_name;
            }        
        }
    }

    public static class ColourValidationResultExtention {
        public static bool has_been_decieded
                               (this RGBColourValidationResult result)
        {
            return result != null;
        }

        public static T Match<T>
                               (this RGBColourValidationResult result
                               , Func<RgbColour, T> is_valid 
                               ,Func<IEnumerable<ColourValidationError>,T> is_not_valid )
        {
            if (result is RGBColourValidationResult.Valid)
            {
                return is_valid((result as RGBColourValidationResult.Valid).colour);
            }

            if (result is RGBColourValidationResult.Error)
            {
                return is_not_valid((result as RGBColourValidationResult.Error).errors);
            }

            throw new Exception("Unmatched case");
        }

        public static void Match
                               (this RGBColourValidationResult result
                               , Action<RgbColour> is_valid
                               ,Action<IEnumerable<ColourValidationError>> is_not_valid )
        {
            Guard.IsNotNull(is_valid, "is_valid");
            Guard.IsNotNull(is_not_valid, "is_not_valid");

            result
                .Match(

                    is_valid:
                        valid_result => { is_valid(valid_result); return new Unit();},

                    is_not_valid:
                        invalid_result => {is_not_valid(invalid_result); return new Unit();}
                );
        }

    }

    public static class colourValidationErrorExtention
    {
        public static void Match
                               (this ColourValidationError error
                               ,Action<ColourValidationError.colourIsNotInTheCorrectFormat> colour_is_not_in_the_correct_format )
        {
            Guard.IsNotNull(colour_is_not_in_the_correct_format, "colour_is_not_in_the_correct_format");

            if (error is ColourValidationError.colourIsNotInTheCorrectFormat)
            {
                colour_is_not_in_the_correct_format((error as ColourValidationError.colourIsNotInTheCorrectFormat));
                return;
            }

            throw new Exception("Unmached case");
        }
    }

}