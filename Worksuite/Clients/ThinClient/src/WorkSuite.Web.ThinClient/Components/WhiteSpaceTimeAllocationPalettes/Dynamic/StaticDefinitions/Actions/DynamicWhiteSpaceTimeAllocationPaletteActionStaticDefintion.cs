using System;
using System.Collections.Generic;
using WorkSuite.Library.Asp.Net.Mvc.Server.Urls;

namespace WTS.WorkSuite.Web.ThinClient.Components.WhiteSpaceTimeAllocationPalettes.Dynamic.StaticDefinitions.Actions 
{
    public class DynamicWhiteSpaceTimeAllocationPaletteActionStaticDefinition<S>
    {
        public Func<S,string> title { get; set; }

        public Func<S, string> name { get; set; }

        public ICollection<Func<S, string>> classes { get; set; }

        public UrlDefinition url { get; set; } 
    }
}