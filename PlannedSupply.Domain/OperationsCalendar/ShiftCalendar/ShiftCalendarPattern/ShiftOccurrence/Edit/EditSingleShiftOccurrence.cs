using System;
using System.Collections.Generic;
using System.Linq;
using Content.Services.PlannedSupply.Messages;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.DomainTypes.Duration;
using WTS.WorkSuite.Library.DomainTypes.Exceptions;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.AggregateRoot;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.AggregateRoot.FindOrCreate;

namespace WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence.Edit
{
    public class EditSingleShiftOccurrence : IEditSingleShiftOcuurrence
    {
        public EditSingleShiftOccurrenceResponse execute(EditSingleShiftOccurrenceRequest the_request)
        {
            return
                set_request(the_request)
                .get_the_shift_occurrence()
                .build_find_or_create_request()
                .find_or_create_time_allocation()
                .change_time_allocation()
                .commit()
                .build_response();
        }

        private EditSingleShiftOccurrence set_request(EditSingleShiftOccurrenceRequest the_request)
        {
            request = Guard.IsNotNull(the_request, "the_request");

            response_builder.set_response(new ShiftOccurrenceIdentity()
            {
                operations_calendar_id = request.operations_calendar_id,
                shift_calendar_id = request.shift_calendar_id,
                shift_calendar_pattern_id = request.shift_calendar_pattern_id,
                shift_occurrence_id = request.shift_occurrence_id
            });

            return this;
        }

        private EditSingleShiftOccurrence get_the_shift_occurrence()
        {
            if (response_builder.has_errors) return this;

            Guard.IsNotNull(request, "request");

            shift_occurrence = get_shift_occurrence.execute(request);

            return this;
        }

        private EditSingleShiftOccurrence build_find_or_create_request()
        {
            if (response_builder.has_errors) return this;

            Guard.IsNotNull(request, "request");
            Guard.IsNotNull(shift_occurrence, "shift_occurrence");
            Guard.IsNotNull(shift_occurrence.time_allocation, "shift_occurrence.time_allocation");

            find_or_create_request = new FindOrCreateAndReturnTimeAllocationRequest()
            {
                shift = new FindOrCreateAndReturnTimeAllocationShiftRequest()
                {
                    operations_calendar_id = request.operations_calendar_id,
                    start_time = request.start_time,
                    duration = request.duration,
                    shift_title = request.shift_title,
                    colour = request.colour,
                    originated_from_client = true
                },
                breaks = shift_occurrence.time_allocation.TimeAllocationBreaks.Select(b => new FindOrCreateAndReturnTimeAllocationBreakRequest()
                {
                    off_set = b.offset_from_start_time_in_seconds.to_duration_request(),
                    duration = b.duration_in_seconds.to_duration_request(),
                    is_paid = b.is_paid,
                    originated_from_client = false
                })
            };

            return this;
        }

        private EditSingleShiftOccurrence find_or_create_time_allocation()
        {
            if (response_builder.has_errors) return this;

            Guard.IsNotNull(find_or_create_request, "find_or_create_request");

            get_or_create_time_allocation
                .execute(find_or_create_request)
                .Match(
                    was_successful: success_response =>
                    {
                        time_allocation = success_response.time_allocation;
                    },
                   had_errors: error_response =>
                   {
                       var errors =
                            error_response.filter_and_map_responses_by(error_reporting_policy);

                       response_builder.add_errors(errors);

                       error_response.Any(new HashSet<find_or_create_error_types>()
                       {
                           find_or_create_error_types.client_break,
                           find_or_create_error_types.internal_break,
                           find_or_create_error_types.internal_shift
                       }, delegate
                       {
                           throw new InternalCorruptDataException("Internal data corruption");
                       });
                   });

            return this;
        }

        private EditSingleShiftOccurrence change_time_allocation()
        {
            if (response_builder.has_errors) return this;

            Guard.IsNotNull(request, "request");
            Guard.IsNotNull(time_allocation, "time_allocation");
            Guard.IsNotNull(shift_occurrence, "shift_occurrence");

            modify_time_allocation_for_occurrence.execute(new ModifyTimeAllocationForOccurrenceRequest()
            {
                new_time_allocation = time_allocation,
                time_allocation_occurrence = shift_occurrence,
                operation_calendar_id = request.operations_calendar_id,
            })
                .Match(

                    was_successful: success_response =>
                    {
                        time_allocation = success_response.time_allocation;
                        shift_occurrence = success_response.time_allocation_occurrence;
                    },

                    had_errors: error_response =>
                    {
                        var errors = error_response.filter_and_map_responses_by(error_reporting_policy);
                        response_builder.add_errors(errors);
                    });

            return this;
        }

        private EditSingleShiftOccurrence commit()
        {
            if (response_builder.has_errors) return this;

            unit_of_work.Commit();

            response_builder.add_message(ConfirmationMessages.confirmation_04_0040);
            return this;
        }

        private EditSingleShiftOccurrenceResponse build_response()
        {
            if (response_builder.has_errors)
                response_builder.add_error(WarningMessages.warning_03_0030);

            return response_builder.build();
        }

        public EditSingleShiftOccurrence(IUnitOfWork the_unit_of_work,
                                        GetOccurrence the_get_shift_occurrence,
                                        FindOrCreateAndReturnTimeAllocation the_get_or_create_time_allocation,
                                        ModifyTimeAllocationForOccurrence the_modify_time_allocation_for_occurrence,
                                        ShiftErrorReportingPolicy the_error_reporting_policy)
        {
            unit_of_work = Guard.IsNotNull(the_unit_of_work, "the_unit_of_work");
            get_shift_occurrence = Guard.IsNotNull(the_get_shift_occurrence, "the_get_shift_occurrence");
            get_or_create_time_allocation = Guard.IsNotNull(the_get_or_create_time_allocation, "get_or_create_time_allocation");
            modify_time_allocation_for_occurrence = Guard.IsNotNull(the_modify_time_allocation_for_occurrence, "the_modify_time_allocation_for_occurrence");
            error_reporting_policy = Guard.IsNotNull(the_error_reporting_policy, "the_error_reporting_policy");

            response_builder = new ResponseBuilder<ShiftOccurrenceIdentity, EditSingleShiftOccurrenceResponse>();
        }

        private readonly IUnitOfWork unit_of_work;
        private readonly GetOccurrence get_shift_occurrence;

        private EditSingleShiftOccurrenceRequest request;
        private readonly ResponseBuilder<ShiftOccurrenceIdentity, EditSingleShiftOccurrenceResponse> response_builder;
        private TimeAllocationOccurrences.TimeAllocationOccurrence shift_occurrence;
        private TimeAllocations.TimeAllocation time_allocation;
        private FindOrCreateAndReturnTimeAllocationRequest find_or_create_request;
        private readonly FindOrCreateAndReturnTimeAllocation get_or_create_time_allocation;
        private readonly ModifyTimeAllocationForOccurrence modify_time_allocation_for_occurrence;
        private readonly ShiftErrorReportingPolicy error_reporting_policy;
    }
}