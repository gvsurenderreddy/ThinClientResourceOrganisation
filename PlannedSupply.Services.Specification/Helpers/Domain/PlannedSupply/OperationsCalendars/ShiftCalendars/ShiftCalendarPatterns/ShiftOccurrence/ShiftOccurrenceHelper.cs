using WorkSuite.Library.Service.Specification.Helpers.Entity;
using WTS.WorkSuite.PlannedSupply.TimeAllocations;

namespace WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.PlannedSupply.OperationsCalendars.ShiftCalendars.ShiftCalendarPatterns.ShiftOccurrence
{
    public class TimeAllocationHelper 
                       : EnityHelper<TimeAllocation
                                    , int
                                    , TimeAllocationBuilder
                                    , FakeTimeAllocationRepository> { }
}