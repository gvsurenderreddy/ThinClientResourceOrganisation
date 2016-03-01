using System;
using WorkSuite.Library.Service.Specification.Helpers.Entity;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ResourceAllocation;

namespace WTS.WorkSuite.ThinClient.Query.Services.Application.PlannedSupply.OpCalendar.ShiftCalendars.Patterns.Allocations.AllocatedResources.Setup
{
    public class AllocatedResourcesDetailsBuilder : IEntityBuilder<ResourceAllocationDetails>
    {
        public ResourceAllocationDetails entity {get { return resource_allocation_details; }}


        public AllocatedResourcesDetailsBuilder employee_id(int id)
        {
            resource_allocation_details.employee_id = id;
            return this;
        }

        public AllocatedResourcesDetailsBuilder date_time(DateTime date_time)
        {
             resource_allocation_details.created_date = date_time;
            return this;
        }

        public AllocatedResourcesDetailsBuilder()
        {
           resource_allocation_details=new ResourceAllocationDetails(); 
        }

        public readonly ResourceAllocationDetails resource_allocation_details;
    }
}
