namespace WTS.WorkSuite.Library.DomainTypes.Colour.Sanatisation
{
    public static class ColourSanitiser
    {

        /// <summary>
        ///     Returns a copy of the colour if one has been specified (is not null and R,G,B have been supplied)
        /// otherwise it returns a new colour set to the rgb defined in the default parameter
        /// </summary>
        /// <remarks>
        ///     We are trying to follow a functional pattern here so we do not just return the value or default
        /// colour we create a new colour that has it's value set from either the value or the default.
        /// </remarks>
        /// <param name="value">
        ///     The <see cref="RGBColourRequest"/> that is checked.
        /// </param>
        /// <param name="default_colour">
        ///     An <see cref="RGBColourRequest"/> that specified the default colour if value is not specified.
        /// </param>
        /// <returns></returns>

        public static RGBColourRequest default_if_not_specifed
                                             ( this RGBColourRequest value
                                             , RGBColourRequest default_colour ){

            if (value == null)
            {
                return new RGBColourRequest() { R = default_colour.R, G = default_colour.G , B = default_colour.B };
            }
            if (value.R == null && value.G == null && value.B == null)
            {
                return new RGBColourRequest() { R = default_colour.R, G = default_colour.G , B = default_colour.B };
            }

            return new RGBColourRequest() { R = value.R, G = value.G, B = value.B };
        }
    }
}