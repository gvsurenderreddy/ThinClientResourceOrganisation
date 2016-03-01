using System.Collections.Generic;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.PlannedSupply.TimeAllocationBreaks;

namespace WTS.WorkSuite.PlannedSupply.TimeAllocations
{
    public class TimeAllocation : BaseEntity<int>
    {
        public virtual string title { get; set; }
        public virtual int start_time_in_seconds_from_midnight { get; set; }
        public virtual int duration_in_seconds { get; set; }
        public virtual string colour { get; set; }

        public virtual ICollection<TimeAllocationBreak> TimeAllocationBreaks
        {
            get { return time_allocation_breaks ?? (time_allocation_breaks = new HashSet<TimeAllocationBreak>()); }
            set { time_allocation_breaks = value; }
        }

        private ICollection<TimeAllocationBreak> time_allocation_breaks;
    }
}