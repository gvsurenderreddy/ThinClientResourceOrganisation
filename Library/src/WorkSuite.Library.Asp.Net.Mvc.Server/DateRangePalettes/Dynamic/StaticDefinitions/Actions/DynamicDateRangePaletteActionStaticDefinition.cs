using System;
using System.Collections.Generic;
using WorkSuite.Library.Asp.Net.Mvc.Server.Urls;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.DateRangePalettes.Dynamic.StaticDefinitions.Actions
{
    public class DynamicDateRangePaletteActionStaticDefinition<S>
    {
        public Func<S,string> title { get; set; }

        public Func<S, string> name { get; set; }

        public ICollection<Func<S, string>> classes { get; set; }

        public UrlDefinition url { get; set; } 
    }
}
