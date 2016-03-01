using System.Collections.Generic;
using System.Linq;
using Content.Services.PlannedSupply.Messages;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.DomainTypes.Duration;
using WTS.WorkSuite.Library.DomainTypes.Exceptions;
using WTS.WorkSuite.Library.DomainTypes.Time;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.AggregateRoot;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.AggregateRoot.FindOrCreate;

namespace WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence.ShiftBreaks.New
{
    public class NewShiftBreak : INewShiftBreak
    {
        public NewShiftBreakResponse execute(NewShiftBreakRequest the_request)
        {
            return
                set_request(the_request)
                .get_the_shift_occurrence()
                .build_combined_find_or_create_request()
                .find_or_create_time_allocation()
                .find_single_occurrence_and_change_time_allocation()
                .commit()
                .build_response();

        }

        private NewShiftBreak set_request(NewShiftBreakRequest the_request)
        {
            request = Guard.IsNotNull(the_request, "the_request");

            response_builder.set_response(new ShiftOccurrenceIdentity
            {
                operations_calendar_id = request.operations_calendar_id,
                shift_calendar_id = request.shift_calendar_id,
                shift_calendar_pattern_id = request.shift_calendar_pattern_id,
                shift_occurrence_id = request.shift_occurrence_id

            });

            return this;
        }

        private NewShiftBreak get_the_shift_occurrence()
        {
            if (response_builder.has_errors) return this;

            Guard.IsNotNull(request, "request");
            shift_occurrence = get_shift_occurrence.execute(request);

            return this;
        }

        private NewShiftBreak build_combined_find_or_create_request()
        {
            if (response_builder.has_errors) return this;
            Guard.IsNotNull(request, "request");


            find_or_create_request = new FindOrCreateAndReturnTimeAllocationRequest
            {
                shift = new FindOrCreateAndReturnTimeAllocationShiftRequest()
                {
                    operations_calendar_id = request.operations_calendar_id,
                    shift_title = shift_occurrence.time_allocation.title,
                    colour = shift_occurrence.time_allocation.colour.to_rgb_colour_request_from_persistence_format(),
                    duration = shift_occurrence.time_allocation.duration_in_seconds.to_duration_request(),
                    start_time = shift_occurrence.time_allocation.start_time_in_seconds_from_midnight.ToTimeRequestFromSeconds(),
                    originated_from_client = false
                },
                breaks = shift_occurrence.time_allocation.TimeAllocationBreaks.Select(br => new FindOrCreateAndReturnTimeAllocationBreakRequest
                {
                    off_set = br.offset_from_start_time_in_seconds.to_duration_request(),
                    duration = br.duration_in_seconds.to_duration_request(),
                    is_paid = br.is_paid,
                    originated_from_client = false
                }).Union(new FindOrCreateAndReturnTimeAllocationBreakRequest
                {
                    off_set = request.off_set,
                    duration = request.duration,
                    is_paid = request.is_paid,
                    originated_from_client = true
                }.ToEnumerable())
            };

            return this;
        }

        private NewShiftBreak find_or_create_time_allocation()
        {
            if (response_builder.has_errors) return this;

            Guard.IsNotNull(request, "request");

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
                           find_or_create_error_types.internal_break,
                           find_or_create_error_types.internal_shift,
                           find_or_create_error_types.client_shift
                       }, delegate
                       {
                           throw new InternalCorruptDataException("Internal data corruption");
                       });
                });
            return this;
        }

        private NewShiftBreak find_single_occurrence_and_change_time_allocation()
        {
            if (response_builder.has_errors) return this;
            Guard.IsNotNull(request, "request");

            modify_time_allocation_for_occurrence.execute(new ModifyTimeAllocationForOccurrenceRequest()
            {
                new_time_allocation = time_allocation,
                time_allocation_occurrence = shift_occurrence
            });

            return this;
        }

        private NewShiftBreak commit()
        {
            if (response_builder.has_errors) return this;

            unit_of_work.Commit();

            response_builder.set_response(new ShiftBreakIdentity
            {
                operations_calendar_id = request.operations_calendar_id,
                shift_calendar_id = request.shift_calendar_id,
                shift_calendar_pattern_id = request.shift_calendar_pattern_id,
                shift_occurrence_id = request.shift_occurrence_id

            });
            response_builder.add_message(ConfirmationMessages.confirmation_201501071429);
            return this;
        }

        private NewShiftBreakResponse build_response()
        {
            if (response_builder.has_errors)
            {
                response_builder.add_error(WarningMessages.warning_03_0043);
            }

            return response_builder.build();
        }

        public NewShiftBreak(IUnitOfWork the_unit_of_work,
                               GetOccurrence the_get_shift_occurrence,
                               FindOrCreateAndReturnTimeAllocation the_get_or_create_time_allocation,
                                ModifyTimeAllocationForOccurrence the_modify_time_allocation_for_occurrence,
                                ShiftBreakErrorReportingPolicy the_error_reporting_policy)
        {
            unit_of_work = Guard.IsNotNull(the_unit_of_work, "the_unit_of_work");
            get_shift_occurrence = Guard.IsNotNull(the_get_shift_occurrence, "the_get_shift_occurrence");
            get_or_create_time_allocation = Guard.IsNotNull(the_get_or_create_time_allocation, "get_or_create_time_allocation");
            modify_time_allocation_for_occurrence = Guard.IsNotNull(the_modify_time_allocation_for_occurrence, "the_modify_time_allocation_for_occurrence");
            error_reporting_policy = Guard.IsNotNull(the_error_reporting_policy, "the_error_reporting_policy");

            response_builder = new ResponseBuilder<ShiftOccurrenceIdentity, NewShiftBreakResponse>();
        }

        private NewShiftBreakRequest request;
        private readonly GetOccurrence get_shift_occurrence;
        private readonly IUnitOfWork unit_of_work;
        private readonly ResponseBuilder<ShiftOccurrenceIdentity, NewShiftBreakResponse> response_builder;

        private TimeAllocationOccurrences.TimeAllocationOccurrence shift_occurrence;
        private FindOrCreateAndReturnTimeAllocationRequest find_or_create_request;
        private readonly FindOrCreateAndReturnTimeAllocation get_or_create_time_allocation;
        private TimeAllocations.TimeAllocation time_allocation;

        private readonly ModifyTimeAllocationForOccurrence modify_time_allocation_for_occurrence;
        private readonly ShiftBreakErrorReportingPolicy error_reporting_policy;

    }
}
