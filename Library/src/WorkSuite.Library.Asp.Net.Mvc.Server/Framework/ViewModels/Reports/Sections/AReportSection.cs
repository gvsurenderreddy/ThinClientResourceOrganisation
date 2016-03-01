using System.Collections.Generic;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Reports.Sections
{
    public class AReportSection : IsAViewElement
    {
        public IEnumerable<IsAViewElement> elements { get; set; }
    }
}