using System.Collections.Generic;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Fields;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Tables
{
    public class ATableRow
    {
        public string id { get; set; }
       
        public string url { get; set; }

        public IEnumerable<Field> fields { get; set; }  
    }
}