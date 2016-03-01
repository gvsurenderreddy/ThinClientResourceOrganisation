using System;
using System.Collections.Generic;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.ShiftPatterns
{
    public class ShiftPatternGrid : IsAViewElement
    {
        public IEnumerable<ShiftPattern> shift_patterns { get; set; }

        public IEnumerable<DateTime> days { get; set; }

        public string grid_classes { get; set; }
    }
}
