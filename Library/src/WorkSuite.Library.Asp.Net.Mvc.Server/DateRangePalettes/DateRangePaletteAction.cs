using System.Collections.Generic;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.DateRangePalettes {

    public class DateRangePaletteAction 
    {
        public string title { get; set; }
        
        public string name { get; set; }
        
        public ICollection<string> classes { get; set; }
    }
}