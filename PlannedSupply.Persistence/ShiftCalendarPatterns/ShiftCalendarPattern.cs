using System.Collections.Generic;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.PlannedSupply.TimeAllocationOccurrences;
using WTS.WorkSuite.PlannedSupply.ResourceAllocations;

namespace WTS.WorkSuite.PlannedSupply.ShiftCalendarPatterns
{
    public class ShiftCalendarPattern
                        : BaseEntity<int>
    {
        public virtual string name { get; set; }

        public virtual int number_of_resources { get; set; }

        public virtual int priority { get; set; }

        public virtual ICollection<TimeAllocationOccurrence> TimeAllocationOccurrences
        {
            get { return time_allocation_occurrences ?? (time_allocation_occurrences = new HashSet<TimeAllocationOccurrence>()); }
            set { time_allocation_occurrences = value; }
        }

        private ICollection<TimeAllocationOccurrence> time_allocation_occurrences;

        public virtual ICollection<ResourceAllocation> ResourceAllocations
        {
            get { return resource_allocations ?? (resource_allocations = new HashSet<ResourceAllocation>()); }
            set { resource_allocations = value; }
        }

        private ICollection<ResourceAllocation> resource_allocations;
    }
}