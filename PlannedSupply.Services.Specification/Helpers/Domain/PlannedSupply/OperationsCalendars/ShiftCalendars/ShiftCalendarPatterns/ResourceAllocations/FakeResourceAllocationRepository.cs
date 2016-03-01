using WorkSuite.Library.Service.Specification.Helpers.IdentityProvider;
using WorkSuite.Library.Service.Specification.Helpers.Persistence;
using WTS.WorkSuite.PlannedSupply.ResourceAllocations;

namespace WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.PlannedSupply.OperationsCalendars.ShiftCalendars.ShiftCalendarPatterns.ResourceAllocations
{
    public class FakeResourceAllocationRepository
                        : FakeEntityRepository<ResourceAllocation, int>
    {
        public FakeResourceAllocationRepository()
            : base(new IntIdentityProvider<ResourceAllocation>()) { }
    }
}
