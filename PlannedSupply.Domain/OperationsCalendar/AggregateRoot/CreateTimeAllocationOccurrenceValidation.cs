using System;
using System.Collections.Generic;
using System.Linq;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.DomainTypes.Time.Clocks;
using WTS.WorkSuite.Library.DomainTypes.Time.Periods;
using WTS.WorkSuite.Library.DomainTypes.Time.Periods.BatchOfViolation;
using WTS.WorkSuite.Library.DomainTypes.Time.Periods.ViolationCheck;

namespace WTS.WorkSuite.PlannedSupply.OperationsCalendar.AggregateRoot
{
    public class CreateTimeAllocationOccurrenceValidation
    {
        public CreateTimeAllocationForOccurrenceResponse execute(CreateTimeAllocationForOccurrenceRequest request)
        {
            return
                set_request(request)
                    .validate_against_clashing_shift()
                    .build_response();
        }

        private CreateTimeAllocationOccurrenceValidation set_request(CreateTimeAllocationForOccurrenceRequest the_request)
        {
            request = Guard.IsNotNull(the_request, "the_request");
            return this;
        }

        private CreateTimeAllocationOccurrenceValidation validate_against_clashing_shift()
        {
            if (response_builder.has_errors) return this;
            Guard.IsNotNull(request, "request");

            var error = new HashSet<string>();
            var time_periods = new List<TimePeriod>();

            var time_allocations_occurrences = request.shift_calendar_pattern.TimeAllocationOccurrences.Where(s => s.start_date.AddDays(1) == request.start_date
                                                                                                             || s.start_date.AddDays(-1) == request.start_date);
            time_periods.AddRange(time_allocations_occurrences.Select(oc => to_time_period(oc.time_allocation, oc.start_date)));
            time_periods.Add(to_time_period(request.time_allocation, request.start_date));

            var result = check_shifts_between_peers.validate(time_periods);
            result.Do(r =>
            {
                if (r is ViolationCheckResult.BlockClashError)
                {
                    error.Add(ClashingShiftValidationErrors.SHIFT_CLASHE_WITH_PEER);
                }
            });

            error.Do(ef => response_builder.add_error("error".ToResponseMessage(ef)));
            add_to_hash_set(request);
            return this;

        }


        private CreateTimeAllocationForOccurrenceResponse build_response()
        {
            var the_response = response_builder.build();

            if (response_builder.has_errors)
            {
                return new CreateTimeAllocationForOccurrenceErrorResponse()
                {
                    has_errors = the_response.has_errors,
                    messages = the_response.messages,
                    error_types_found = error_types_found
                };
            }
            return new CreateTimeAllocationForOccurrenceSuccessResponse()
            {
                has_errors = the_response.has_errors,
                messages = the_response.messages,
                time_allocation = request.time_allocation,
            };
        }

        private TimePeriod to_time_period(TimeAllocations.TimeAllocation time_allocation, DateTime date)
        {
            var date_time = new DateTime();
            date_time = date;
            var offset_to_date_time = date_time.AddSeconds(time_allocation.start_time_in_seconds_from_midnight);
            return new TimePeriod(new UtcTime(offset_to_date_time.Year
                , offset_to_date_time.Month
                , offset_to_date_time.Day
                , offset_to_date_time.Hour
                , offset_to_date_time.Minute
                , offset_to_date_time.Second
                , offset_to_date_time.Millisecond),
                time_allocation.duration_in_seconds);
        }

        public CreateTimeAllocationOccurrenceValidation(CheckBatchOfViolation the_check_shifts_between_peers)
        {
            response_builder = new ResponseBuilder<CreateTimeAllocationForOccurrenceResponse>();
            error_types_found = new HashSet<CreateTimeAllocationErrorTypes>();
           check_shifts_between_peers = Guard.IsNotNull(the_check_shifts_between_peers, "the_check_shifts_between_peers");
        }

        private CreateTimeAllocationForOccurrenceRequest request;
        private readonly CheckBatchOfViolation check_shifts_between_peers;
        private readonly ResponseBuilder<CreateTimeAllocationForOccurrenceResponse> response_builder;
        private HashSet<CreateTimeAllocationErrorTypes> error_types_found { get; set; }
        private void add_to_hash_set(CreateTimeAllocationForOccurrenceRequest shift)
        {
            error_types_found.Add(shift.originated_from_client
                ? CreateTimeAllocationErrorTypes.client_shift
                : CreateTimeAllocationErrorTypes.internal_shift);
        }
    }
}