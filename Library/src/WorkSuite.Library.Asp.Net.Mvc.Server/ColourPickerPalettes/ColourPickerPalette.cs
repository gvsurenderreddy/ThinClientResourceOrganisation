using System.Collections.Generic;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.ColourPickerPalettes
{
    public class ColourPickerPalette : IsAViewElement
    {
        public string close_button_title { get; set; }
        public string current_colour_value { get; set; }
        public IEnumerable<string> accellerator_colour_values { get; set; }
        public IEnumerable<ColourPickerPaletteEntry> palette_entries { get; set; }
    }

    public class ColourPickerPaletteEntry
    {
        public string title { get; set; }
        public IEnumerable<string> colour_values { get; set; }
    }
}
