using System.Linq;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ResourceAllocation;
using WTS.WorkSuite.PlannedSupply.OperationsCalendars;
using WTS.WorkSuite.PlannedSupply.ResourceAllocations;
using WTS.WorkSuite.PlannedSupply.ShiftCalendarPatterns;

namespace WTS.WorkSuite.PlannedSupply.OperationsCalendar.AggregateRoot
{
    public class RemoveResourceAllocation
    {
        public RemoveResourceAllocationResponse execute(ResourceAllocationIdentity the_request)
        {
            return
                set_request(the_request)
                .find_pattern()
                .find_resource_allocation()
                .remove_resource_from_pattern()
                .build_response();
        }

        private RemoveResourceAllocation set_request(ResourceAllocationIdentity the_request)
        {
            request = Guard.IsNotNull(the_request, "the_request");

            return this;
        }

        private RemoveResourceAllocation find_pattern()
        {
            Guard.IsNotNull(request, "request");

            pattern = get_pattern.execute(request);

            return this;
        }

        private RemoveResourceAllocation find_resource_allocation()
        {
            if (response_builder.has_errors) return this;

            Guard.IsNotNull(request, "request");
            Guard.IsNotNull(pattern, "pattern");

            resource_allocation = pattern.ResourceAllocations.SingleOrDefault(ra => ra.id == request.resource_allocation_id);

            if (resource_allocation == null)
            {
                response_builder.add_error(
                    RemoveResourceAllocationErrors.RESOURCE_NOT_FOUND.ToResponseMessage(
                        RemoveResourceAllocationErrors.RESOURCE_NOT_FOUND));
            }
            return this;
        }

        private RemoveResourceAllocation remove_resource_from_pattern()
        {
            if (response_builder.has_errors) return this;

            Guard.IsNotNull(pattern, "pattern");
            Guard.IsNotNull(resource_allocation, "resource_allocation");

            pattern.ResourceAllocations.Remove(resource_allocation);
            operations_calendar_repository.remove(resource_allocation);

            return this;
        }

        private RemoveResourceAllocationResponse build_response()
        {
            var the_response = response_builder.build();

            return new RemoveResourceAllocationResponse
            {
                has_errors = the_response.has_errors,
                messages = the_response.messages
            };
        }

        public RemoveResourceAllocation(IEntityRepository<OperationalCalendar> the_operations_calendar_repository,
                                        GetShiftCalendarPattern the_get_pattern)
        {
            operations_calendar_repository = Guard.IsNotNull(the_operations_calendar_repository, "the_operations_calendar_repository");
            get_pattern = Guard.IsNotNull(the_get_pattern, "the_get_pattern");

            response_builder = new ResponseBuilder<RemoveResourceAllocationResponse>();
        }

        private readonly IEntityRepository<OperationalCalendar> operations_calendar_repository;
        private readonly GetShiftCalendarPattern get_pattern;

        private ResourceAllocation resource_allocation;
        private ShiftCalendarPattern pattern;

        private ResourceAllocationIdentity request;

        private readonly ResponseBuilder<RemoveResourceAllocationResponse> response_builder;
    }

    public class RemoveResourceAllocationResponse : Response { }
   
}
