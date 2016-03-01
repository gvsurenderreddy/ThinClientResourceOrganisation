using System;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.PlannedSupply.HR.Employee;

namespace WTS.WorkSuite.PlannedSupply.ResourceAllocations
{
    public class ResourceAllocation : BaseEntity<int>
    {
        public virtual EmployeePlannedSupply employee { get; set; }
        public virtual DateTime created_date { get; set; }
    }
}
