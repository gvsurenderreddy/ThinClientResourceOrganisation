using System;
using System.Collections.Generic;
using System.Linq;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.OperationsCalendars;
using WTS.WorkSuite.PlannedSupply.TimeAllocationBreaks;

namespace WTS.WorkSuite.PlannedSupply.OperationsCalendar.AggregateRoot.FindOrCreate
{
    public class FindOrCreateAndReturnTimeAllocation
    {
        public FindOrCreateAndReturnTimeAllocationResponse execute(FindOrCreateAndReturnTimeAllocationRequest the_request)
        {
            return
                 set_request(the_request)
                .validate_request()
                .find_or_create_time_allocation()
                .build_response();
        }

        private FindOrCreateAndReturnTimeAllocation set_request(FindOrCreateAndReturnTimeAllocationRequest the_request)
        {
            request = Guard.IsNotNull(the_request, "the_request");

            return this;
        }

        private FindOrCreateAndReturnTimeAllocation validate_request()
        {
            if (response_builder.has_errors) return this;
            Guard.IsNotNull(request, "request");

            var find_or_create_request_sanitiser_response = find_or_create_request_sanitiser.execute(request);

            sanitised_request = find_or_create_request_sanitiser_response.result;

            response_builder.add_errors(find_or_create_request_sanitiser_response.messages);

            foreach (var item in find_or_create_request_sanitiser_response.error_types_found)
            {
                error_types_found.Add(item);
            }

            return this;
        }

        private FindOrCreateAndReturnTimeAllocation find_or_create_time_allocation()
        {
            if (response_builder.has_errors) return this;

            Guard.IsNotNull(request, "request");
            Guard.IsNotNull(sanitised_request, "sanitised_request");

            var operational_calendar = operational_calendar_repository
                                            .Entities
                                            .Single(oc => oc.id == request.shift.operations_calendar_id)
                                            ;


            time_allocation = find_single_with_this_signature_or_return_this(operational_calendar.TimeAllocations,
                                    new TimeAllocations.TimeAllocation
                                    {
                                        colour = sanitised_request.colour.ToString(),
                                        start_time_in_seconds_from_midnight = sanitised_request.start_time_in_seconds_from_midnight,
                                        duration_in_seconds = sanitised_request.duration_in_seconds,
                                        title = sanitised_request.title,
                                        TimeAllocationBreaks = sanitised_request.sanitised_breaks.Select(sb => new TimeAllocationBreak
                                        {
                                            duration_in_seconds = sb.duration_in_seconds,
                                            is_paid = sb.is_paid,
                                            offset_from_start_time_in_seconds = sb.offset_from_start_time_in_seconds
                                        }).ToList()
                                    });

            operational_calendar.TimeAllocations.Add(time_allocation);

            return this;
        }

        private FindOrCreateAndReturnTimeAllocationResponse build_response()
        {
            var the_response = response_builder.build();

            if (response_builder.has_errors)
            {
                return new FindOrCreateAndReturnTimeAllocationErrorResponse
                {
                    has_errors = the_response.has_errors,
                    messages = the_response.messages,
                    error_types_found = error_types_found
                };
            }
            return new FindOrCreateAndReturnTimeAllocationSuccessResponse
            {
                has_errors = the_response.has_errors,
                messages = the_response.messages,
                time_allocation = time_allocation
            };
        }

        public FindOrCreateAndReturnTimeAllocation(IEntityRepository<OperationalCalendar> the_operational_calendar_repository
                                                   , FindOrCreateRequestValidator the_find_or_create_request_sanitiser)
        {

            operational_calendar_repository = Guard.IsNotNull(the_operational_calendar_repository, "the_operational_calendar_repository");
            find_or_create_request_sanitiser = Guard.IsNotNull(the_find_or_create_request_sanitiser, "the_find_or_create_request_sanitiser");
            sanitised_request = new SanitisedTimeAllocation();
            error_types_found = new HashSet<find_or_create_error_types>();
            response_builder = new ResponseBuilder<FindOrCreateAndReturnTimeAllocationResponse>();
        }

        private readonly FindOrCreateRequestValidator find_or_create_request_sanitiser;
        private SanitisedTimeAllocation sanitised_request;
        private FindOrCreateAndReturnTimeAllocationRequest request;
        private TimeAllocations.TimeAllocation time_allocation;
        private readonly IEntityRepository<OperationalCalendar> operational_calendar_repository;
        private readonly ResponseBuilder<FindOrCreateAndReturnTimeAllocationResponse> response_builder;
        private HashSet<find_or_create_error_types> error_types_found { get; set; }

        #region"private helper methods"

        private TimeAllocations.TimeAllocation find_single_with_this_signature_or_return_this(IEnumerable<TimeAllocations.TimeAllocation> where_to_search_from,
                                                                                                        TimeAllocations.TimeAllocation what_to_search_for)
        {
            var data = where_to_search_from.SingleOrDefault(ta => ta.colour == what_to_search_for.colour
                                                            && ta.start_time_in_seconds_from_midnight == what_to_search_for.start_time_in_seconds_from_midnight
                                                            && ta.duration_in_seconds == what_to_search_for.duration_in_seconds
                                                            && ta.title == what_to_search_for.title
                                                            && are_equal(ta.TimeAllocationBreaks, what_to_search_for.TimeAllocationBreaks)
                                                            );

            return data ?? what_to_search_for;

        }

        private bool are_equal(IEnumerable<TimeAllocationBreak> time_allocation_breaks, IEnumerable<TimeAllocationBreak> breaks_from_request)
        {
            if (time_allocation_breaks.Count() != breaks_from_request.Count())
            {
                return false;
            }

            return !(
                        breaks_from_request.Except(time_allocation_breaks, new TimeAllocationBreakComparer()).Any()
                            ||
                        time_allocation_breaks.Except(breaks_from_request, new TimeAllocationBreakComparer()).Any()
                    );
        }


        private class TimeAllocationBreakComparer : IEqualityComparer<TimeAllocationBreak>
        {
            public bool Equals(TimeAllocationBreak x, TimeAllocationBreak y)
            {
                //Check whether the objects are the same object.  
                if (Object.ReferenceEquals(x, y)) return true;

                //Check whether the properties are equal.  
                var value = x != null
                            && y != null
                            && x.is_paid.Equals(y.is_paid)
                            && x.duration_in_seconds.Equals(y.duration_in_seconds)
                            && x.offset_from_start_time_in_seconds
                                .Equals(y.offset_from_start_time_in_seconds);

                return value;
            }

            public int GetHashCode(TimeAllocationBreak obj)
            {
                return obj.is_paid.GetHashCode()
                       ^ obj.offset_from_start_time_in_seconds.GetHashCode()
                       ^ obj.duration_in_seconds.GetHashCode();
            }
        }

        #endregion

    }
}
