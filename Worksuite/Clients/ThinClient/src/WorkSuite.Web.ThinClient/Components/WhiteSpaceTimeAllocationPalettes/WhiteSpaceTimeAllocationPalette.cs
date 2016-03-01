using System.Collections.Generic;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Fields.HiddenField;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Fields.LookupField;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.UserActions;

namespace WTS.WorkSuite.Web.ThinClient.Components.WhiteSpaceTimeAllocationPalettes
{
    public class WhiteSpaceTimeAllocationPalette : IsAViewElement
    {
        public string title { get; set; }

        public IEnumerable<string> classes { get; set; }

        public AHiddenField operational_calendar_id { get; set; }

        public AHiddenField shift_calendar_id { get; set; }

        public AHiddenField shift_calendar_pattern_id { get; set; }

        public AHiddenField start_date { get; set; }

        public ALookupField time_allocation_templates { get; set; }

        public RoutedAction change_time_allocation_action { get; set; }

        public RoutedAction new_shift_action { get; set; }
        
    }
}
