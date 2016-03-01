using System.Collections.Generic;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.UserActions;
using WTS.WorkSuite.Library.DomainTypes.Time.Periods;

namespace WTS.WorkSuite.Web.ThinClient.Components.ShiftTimeAllocationPalettes
{
    public class ShiftTimeAllocationPalette : IsAViewElement
    {
        public string title { get; set; }
        public string shift_title{ get; set; }
        public TimePeriod time_period { get; set; }
        public IEnumerable<ShiftTimeAllocationPaletteBreak> breaks { get; set; }
        public IEnumerable<string> classes { get; set; }

        public RoutedAction remove_shift_action { get; set; }
        public RoutedAction remove_all_shift_action { get; set; }
        public RoutedAction edit_all_shift_action { get; set; }
        public RoutedAction edit_shift_action { get; set; }
    }

    public class ShiftTimeAllocationPaletteBreak
    {
        public string title { get; set; }
        public string start_time { get; set; }
        public string end_time { get; set; }
        public string payment_type { get; set; }
    }
}
