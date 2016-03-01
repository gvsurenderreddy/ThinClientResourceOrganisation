using System;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Library.DomainTypes.Colour
{
    public class RgbColour
    {
        public byte R { get; private set; }
        public byte G { get; private set; }
        public byte B { get; private set; }

        public RgbColour(byte r, byte g, byte b)
        {
            R = r;
            G = g;
            B = b;
        }

        public override string ToString()
        {
                return string.Format("{0},{1},{2}", R, G, B);
        }
       
    }

    public static class RgbColourExtension
    {

        public static RgbColour rgb_colour_format
                                  (this string request)
        {
           
            Guard.IsNotNull(request, "request");

            var rgb_colour = request.Split(',');

            byte R_as_number;
            var R_is_number = byte.TryParse(rgb_colour[0], out R_as_number);

            byte G_as_number;
            var G_is_number = byte.TryParse(rgb_colour[1], out G_as_number);

            byte B_as_number;
            var B_is_number = byte.TryParse(rgb_colour[2], out B_as_number);
            return new RgbColour(R_as_number, G_as_number, B_as_number);

        }
    }
}
   
