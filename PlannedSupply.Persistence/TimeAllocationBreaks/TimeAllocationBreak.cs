using WorkSuite.Library.Persistence;

namespace WTS.WorkSuite.PlannedSupply.TimeAllocationBreaks
{
    public class TimeAllocationBreak : BaseEntity<int>
    {
        public virtual int offset_from_start_time_in_seconds { get; set; }

        public virtual int duration_in_seconds { get; set; }

        public virtual bool is_paid { get; set; }
    }
}
