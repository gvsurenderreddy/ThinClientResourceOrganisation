using Content.Services.PlannedSupply.Messages;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ResourceAllocation.RemoveAllocationFromPattern.post
{
    public class RemoveResourceAllocationFromPattern : IRemoveResourceAllocationFromPatternRequestHandler
    {
        public RemoveResourceAllocationFromPatternResponse execute(RemoveResourceAllocationFromPatternRequest the_request)
        {
           
            return
                 set_request(the_request)
                .remove_resource()
                .commit()
                .build_response();
        }

        private RemoveResourceAllocationFromPattern set_request(RemoveResourceAllocationFromPatternRequest the_request)
        {
            request = Guard.IsNotNull(the_request, "the_request");

            request = new ResourceAllocationIdentity
            {
                operations_calendar_id = the_request.operations_calendar_id,
                shift_calendar_id = the_request.shift_calendar_id,
                shift_calendar_pattern_id = the_request.shift_calendar_pattern_id,
                resource_allocation_id = the_request.resource_allocation_id
            };

            return this;
        }

        private RemoveResourceAllocationFromPattern remove_resource()
        {
            Guard.IsNotNull(request, "request");
            var allocation_response = remove_resource_allocation_for_shift_pattern.execute(request);

            response_builder.add_errors(allocation_response.messages);
            return this;
        }

        private RemoveResourceAllocationFromPattern commit()
        {
            if (response_builder.has_errors) return this;
            unit_of_work.Commit();
            return this;
        }

        private RemoveResourceAllocationFromPatternResponse build_response()
        {
            if (response_builder.has_errors)
                response_builder.add_error(WarningMessages.warning_1002151228);
            else
                response_builder.add_message(ConfirmationMessages.confirmation_1102151130);

            return response_builder.build();
        }


        public RemoveResourceAllocationFromPattern(AggregateRoot.RemoveResourceAllocation the_remove_resource_allocation_for_shift_pattern, IUnitOfWork the_unit_of_work)
        {
            remove_resource_allocation_for_shift_pattern = Guard.IsNotNull(the_remove_resource_allocation_for_shift_pattern, "the_remove_resource_allocation_for_shift_pattern");
            unit_of_work = Guard.IsNotNull(the_unit_of_work, "the_unit_of_work");

            response_builder = new ResponseBuilder<RemoveResourceAllocationFromPatternResponse>();
        }

        private readonly AggregateRoot.RemoveResourceAllocation remove_resource_allocation_for_shift_pattern;
        private readonly IUnitOfWork unit_of_work;

        private readonly ResponseBuilder<RemoveResourceAllocationFromPatternResponse> response_builder;
        private ResourceAllocationIdentity request;
    }
}
