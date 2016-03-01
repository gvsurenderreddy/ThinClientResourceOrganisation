using System;
using System.Collections.Generic;
using System.Linq;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.DomainTypes.Time.Clocks;
using WTS.WorkSuite.Library.DomainTypes.Time.Periods;
using WTS.WorkSuite.Library.DomainTypes.Time.Periods.BatchOfViolation;
using WTS.WorkSuite.Library.DomainTypes.Time.Periods.ViolationCheck;
using WTS.WorkSuite.PlannedSupply.OperationsCalendars;

namespace WTS.WorkSuite.PlannedSupply.OperationsCalendar.AggregateRoot
{
    public class ModifyTimeAllocationForOccurrence
    {
        public ModifyTimeAllocationForOccurrenceResponse execute(ModifyTimeAllocationForOccurrenceRequest the_request)
        {
            return 
                set_request(the_request)
               .validate_against_clashing_shift()
               .modify_Time_allocation_for_occurrence_response()
               .build_response();
        }

        private ModifyTimeAllocationForOccurrence set_request( ModifyTimeAllocationForOccurrenceRequest the_request)
        {
            request = Guard.IsNotNull(the_request, "the_request");
            return this;
        }

        private ModifyTimeAllocationForOccurrence validate_against_clashing_shift()
        {
            Guard.IsNotNull(request, "request");

            var error = new HashSet<string>();
            var time_periods = new List<TimePeriod>();

            var shift_calendar_pattern = operational_calendar_repository
                                        .Entities
                                        .Where(ta => ta.id == request.operation_calendar_id)
                                        .SelectMany(x => x.ShiftCalendars.SelectMany(p => p.ShiftCalendarPatterns));

            foreach (var calendar_pattern in shift_calendar_pattern)
            {
                if (calendar_pattern.TimeAllocationOccurrences.FirstOrDefault(x => x.id == request.time_allocation_occurrence.id) == null) continue;
                var time_allocations_occurrences = calendar_pattern.TimeAllocationOccurrences.Where(s => s.start_date.AddDays(1) == request.time_allocation_occurrence.start_date
                                                                                                    || s.start_date.AddDays(-1) == request.time_allocation_occurrence.start_date);
                time_periods.AddRange(time_allocations_occurrences.Select(oc => to_time_period(oc.time_allocation, oc.start_date)));
            }

           time_periods.Add(to_time_period(request.new_time_allocation, request.time_allocation_occurrence.start_date)); 

           var result = check_shifts_between_peers.validate(time_periods);
                         result.Do(r => {
                                if (r is ViolationCheckResult.BlockClashError)
                                {
                                    error.Add(ClashingShiftValidationErrors.SHIFT_CLASHE_WITH_PEER);
                                }});

            error.Do(ef => response_builder.add_error("error".ToResponseMessage(ef)));
            add_to_hash_set(request);
            return this;
        }

        private ModifyTimeAllocationForOccurrence modify_Time_allocation_for_occurrence_response()
        {
            if (response_builder.has_errors) return this;
            Guard.IsNotNull(request, "request");
            request.time_allocation_occurrence.time_allocation = request.new_time_allocation;

            return this;
        }

        private ModifyTimeAllocationForOccurrenceResponse build_response()
        {
            var the_response = response_builder.build();

            if (response_builder.has_errors)
            {
                return new ModifyTimeAllocationForOccurrenceErrorResponse
                {
                    has_errors = the_response.has_errors,
                    messages = the_response.messages,
                    error_types_found= error_types_found
                };
            }
            return new ModifyTimeAllocationForOccurrenceSuccessResponse
            {
                has_errors = the_response.has_errors,
                messages = the_response.messages,
                time_allocation = request.new_time_allocation,
                time_allocation_occurrence = request.time_allocation_occurrence
            };
        }

        private TimePeriod to_time_period(TimeAllocations.TimeAllocation timeAllocation, DateTime date)
        {
            var date_time = new DateTime();
            date_time = date;
            var offset_to_date_time = date_time.AddSeconds(timeAllocation.start_time_in_seconds_from_midnight);
            return new TimePeriod(new UtcTime(offset_to_date_time.Year
                , offset_to_date_time.Month
                , offset_to_date_time.Day
                , offset_to_date_time.Hour
                , offset_to_date_time.Minute
                , offset_to_date_time.Second
                , offset_to_date_time.Millisecond),
                timeAllocation.duration_in_seconds);
        }

        public ModifyTimeAllocationForOccurrence( CheckBatchOfViolation the_check_bach_of_violation
                                                , IEntityRepository<OperationalCalendar> the_operational_calendar_repository)
        {
           response_builder=new ResponseBuilder<ModifyTimeAllocationForOccurrenceResponse>();
           error_types_found = new HashSet<modify_time_allocation_error_types>();
           check_shifts_between_peers = Guard.IsNotNull(the_check_bach_of_violation, "the_check_bach_of_violation");
           operational_calendar_repository = Guard.IsNotNull(the_operational_calendar_repository, "the_operational_calendar_repository");
        }

        private ModifyTimeAllocationForOccurrenceRequest request;
        private readonly ResponseBuilder<ModifyTimeAllocationForOccurrenceResponse> response_builder;
        private HashSet<modify_time_allocation_error_types> error_types_found { get; set; }
        private readonly CheckBatchOfViolation check_shifts_between_peers;
        private readonly IEntityRepository<OperationalCalendar> operational_calendar_repository;

        private void add_to_hash_set(ModifyTimeAllocationForOccurrenceRequest shift)
        {
            error_types_found.Add(shift.originated_from_client
                ? modify_time_allocation_error_types.client_shift
                : modify_time_allocation_error_types.internal_shift);
        }
    }

  
}
