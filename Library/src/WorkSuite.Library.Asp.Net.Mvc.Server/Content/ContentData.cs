using System.Collections.Generic;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Content
{
    public class ContentData : Dictionary<string, ContentValue>
    {

    }

    public class ContentValue
    {
        public string value { get; set; }
        public string description { get; set; }
    }
}
