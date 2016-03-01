using System;
using Ninject;
using Ninject.Activation;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Library.Ninject.Configuration;
using WTS.WorkSuite.PlannedSupply.ResourceAllocations;

namespace WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.PlannedSupply.OperationsCalendars.ShiftCalendars.ShiftCalendarPatterns.ResourceAllocations
{
    public class DependencyConfiguration : ADependencyConfiguration
    {
        public override void configure(IKernel kernel, Func<IContext, object> scope)
        {
            kernel
                .Rebind<IQueryRepository<ResourceAllocation>,
                    IEntityRepository<ResourceAllocation>,
                    FakeResourceAllocationRepository
                    >()
                .To<FakeResourceAllocationRepository>()
                .InScope(x => scope)
                ;

        }
    }
}
