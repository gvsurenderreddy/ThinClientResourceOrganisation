using WorkSuite.Library.Service.Specification.Helpers.IdentityProvider;
using WorkSuite.Library.Service.Specification.Helpers.Persistence;
using WTS.WorkSuite.PlannedSupply.TimeAllocations;

namespace WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.PlannedSupply.OperationsCalendars.ShiftCalendars.ShiftCalendarPatterns.ShiftOccurrence
{
    public class FakeTimeAllocationRepository
                             : FakeEntityRepository<TimeAllocation, int>
    {
        public FakeTimeAllocationRepository() 
                             : base(new IntIdentityProvider<TimeAllocation>())
        {
        }
    }

}