using System.Collections.Generic;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.PlannedSupply.ShiftCalendarPatterns;

namespace WTS.WorkSuite.PlannedSupply.ShiftCalendars
{
    public class ShiftCalendar
                    : BaseEntity<int>
    {
        public virtual string calendar_name { get; set; }

        public virtual ICollection<ShiftCalendarPattern> ShiftCalendarPatterns
        {
            get { return shift_calendar_patterns ?? (shift_calendar_patterns = new HashSet<ShiftCalendarPattern>()); }
            set { shift_calendar_patterns = value; }
        }

        private ICollection<ShiftCalendarPattern> shift_calendar_patterns;
    }
}