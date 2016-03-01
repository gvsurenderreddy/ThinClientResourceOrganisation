
using WorkSuite.Library.Service.Specification.Helpers.Entity;
using WTS.WorkSuite.PlannedSupply.ResourceAllocations;

namespace WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.PlannedSupply.OperationsCalendars.ShiftCalendars.ShiftCalendarPatterns.ResourceAllocations
{
    public class ResourceAllocationHelper
                        : EnityHelper<ResourceAllocation,
                                        int,
                                        ResourceAllocationBuilder,
                                        FakeResourceAllocationRepository
                                     > { }
}
