using System.Collections.Generic;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Tables
{
    // to do: (refactor) Change from table to summary list this keep it in line with details list
    public class Table : IsAViewElement
    {
        public string id { get; set; }
        public IEnumerable<string> columns { get; set; }
        public IEnumerable<ATableRow> rows { get; set; } 
    }
}