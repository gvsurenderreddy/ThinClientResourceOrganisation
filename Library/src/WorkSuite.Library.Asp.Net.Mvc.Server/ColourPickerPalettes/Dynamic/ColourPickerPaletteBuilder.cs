using Newtonsoft.Json;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.DomainTypes.Colour;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.ColourPickerPalettes.Dynamic
{
    public class ColourPickerPaletteBuilder
    {

        public ColourPickerPaletteBuilder set_colour_value(RGBColourRequest the_colour_value)
        {
            Guard.IsNotNull(the_colour_value, "the_colour_value");

            current_colour_value = the_colour_value;

            return this;
        }

        public ColourPickerPalette build(string colour_json)
        {
            return set_request(colour_json)
                        .deserialise_json()
                        .apply_colour_value()
                        .build_response();
        }

        private ColourPickerPaletteBuilder set_request(string the_json_data)
        {
            Guard.IsNotNull(the_json_data, "the_json_data");

            json_request = the_json_data;

            return this;
        }

        private ColourPickerPaletteBuilder deserialise_json()
        {
            Guard.IsNotNull(json_request, "json_request");

            view_model = JsonConvert.DeserializeObject<ColourPickerPalette>(json_request);

            return this;
        }

        private ColourPickerPaletteBuilder apply_colour_value()
        {
            Guard.IsNotNull(current_colour_value, "current_colour_value has not been set");

            view_model.current_colour_value = current_colour_value.ToString();

            return this;
        }

        private ColourPickerPalette build_response()
        {
            Guard.IsNotNull(view_model, "view_model");

            return view_model;
        }


        private string json_request;
        private RGBColourRequest current_colour_value;
        private ColourPickerPalette view_model;
    }
}
