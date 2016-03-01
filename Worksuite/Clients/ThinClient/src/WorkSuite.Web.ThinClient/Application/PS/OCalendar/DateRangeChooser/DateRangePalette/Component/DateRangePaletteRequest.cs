using System;
using WTS.WorkSuite.Library.DomainTypes;

namespace WTS.WorkSuite.Web.ThinClient.Application.Operations.OperationalCalendars.PlannedSupply.DateRangePalette.Component
{
    public class DateRangePaletteRequest
    {
        public DateTime selected_date { get; set; }

        public DateTime calendar_start_date { get; set; }

        public ShiftCalendarRange range_type { get; set; }
    }
}