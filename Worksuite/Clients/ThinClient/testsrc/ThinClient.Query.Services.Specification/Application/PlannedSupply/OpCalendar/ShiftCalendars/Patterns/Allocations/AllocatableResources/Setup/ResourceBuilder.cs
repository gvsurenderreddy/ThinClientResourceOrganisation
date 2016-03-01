using System;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ResourceAllocation;

namespace WTS.WorkSuite.ThinClient.Query.Services.Application.PlannedSupply.OpCalendar.ShiftCalendars.Patterns.Allocations.AllocatableResources.Setup
{
    public class ResourceAllocationDetailsBuilder
    {
        public ResourceAllocationDetails entity {get { return resource_allocation_details; }}

        public ResourceAllocationDetailsBuilder employee_id(int employee_id)
        {
            resource_allocation_details.employee_id = employee_id;
            return this;
        }

        public ResourceAllocationDetailsBuilder date_time(DateTime date_time)
        {
            resource_allocation_details.created_date = date_time;
            return this;
        }

        public ResourceAllocationDetailsBuilder()
        {
            this.resource_allocation_details = DependencyResolver.resolve<ResourceAllocationDetails>();
        }
        public ResourceAllocationDetails resource_allocation_details;
    }
}
