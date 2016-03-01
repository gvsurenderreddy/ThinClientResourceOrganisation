using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.DomainTypes.Colour;

namespace WTS.WorkSuite.Library.DomainTypes.Colour
{
    public class RGBColourRequest
    {
        public int? R { get; set; } 
        public int? G { get; set; } 
        public int? B { get; set; }

        public override string ToString()
        {
            if (HasValue())
            {
                return string.Format("rgb({0},{1},{2})", R, G, B);
            }
            return string.Empty;
        }

        private bool HasValue()
        {
            return !(!R.HasValue || !G.HasValue || !B.HasValue);
        }
    }
   
}
public static class RgbColourExtension
{

    public static RGBColourRequest to_rgb_colour_request_from_persistence_format
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
        return new RGBColourRequest() { R = R_as_number, G = G_as_number, B = B_as_number };

    }
}