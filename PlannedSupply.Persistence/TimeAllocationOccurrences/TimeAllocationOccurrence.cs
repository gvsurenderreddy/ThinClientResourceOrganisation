using System;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.PlannedSupply.TimeAllocations;

namespace WTS.WorkSuite.PlannedSupply.TimeAllocationOccurrences
{
    public class TimeAllocationOccurrence : BaseEntity<int>
    {
        public virtual DateTime start_date { get; set; }

        public virtual TimeAllocation time_allocation { get; set; }
    }
}