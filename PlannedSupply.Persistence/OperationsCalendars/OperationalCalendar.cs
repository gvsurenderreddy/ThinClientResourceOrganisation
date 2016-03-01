using System.Collections.Generic;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.PlannedSupply.ShiftCalendars;
using WTS.WorkSuite.PlannedSupply.TimeAllocations;

namespace WTS.WorkSuite.PlannedSupply.OperationsCalendars
{
    public class OperationalCalendar
                        : BaseEntity<int>
    {
        public virtual string calendar_name { get; set; }

        public virtual ICollection<ShiftCalendar> ShiftCalendars
        {
            get { return shift_calendars ?? (shift_calendars = new HashSet<ShiftCalendar>()); }
            set { shift_calendars = value; }
        }

        public virtual ICollection<TimeAllocation> TimeAllocations
        {
            get { return time_allocations ?? (time_allocations = new HashSet<TimeAllocation>()); }
            set { time_allocations = value; }
        }

        private ICollection<TimeAllocation> time_allocations;
        private ICollection<ShiftCalendar> shift_calendars;
    }
}