using System;
using System.Collections.Generic;
using System.Linq;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.DomainTypes.Colour;
using WTS.WorkSuite.Library.DomainTypes.Duration;
using WTS.WorkSuite.Library.DomainTypes.Time;

namespace WTS.WorkSuite.PlannedSupply.OperationsCalendar.AggregateRoot.FindOrCreate
{
    public class FindOrCreateAndReturnTimeAllocationRequest
    {
        public FindOrCreateAndReturnTimeAllocationShiftRequest shift { get; set; }
        public IEnumerable<FindOrCreateAndReturnTimeAllocationBreakRequest> breaks { get; set; }
    }

    public class FindOrCreateAndReturnTimeAllocationShiftRequest : IDataOrigin
    {
        public int operations_calendar_id { get; set; }
        public string shift_title { get; set; }
        public TimeRequest start_time { get; set; }
        public DurationRequest duration { get; set; }
        public RGBColourRequest colour { get; set; }

        public bool originated_from_client { get; set; }
    }

    public class FindOrCreateAndReturnTimeAllocationBreakRequest : IDataOrigin
    {
        public DurationRequest off_set { get; set; }
        public DurationRequest duration { get; set; }
        public bool is_paid { get; set; }

        public bool originated_from_client { get; set; }
    }

    public class FindOrCreateAndReturnTimeAllocationResponse : Response
    {

    }

    public class FindOrCreateAndReturnTimeAllocationSuccessResponse : FindOrCreateAndReturnTimeAllocationResponse
    {
        public TimeAllocations.TimeAllocation time_allocation { get; set; }
    }

    public enum find_or_create_error_types
    {
        internal_shift,
        client_shift,
        internal_break,
        client_break
    }

    public class FindOrCreateAndReturnTimeAllocationErrorResponse : FindOrCreateAndReturnTimeAllocationResponse
    {
        public HashSet<find_or_create_error_types> error_types_found { get; set; }


        public void Any(HashSet<find_or_create_error_types> match_on, Action what_to_do)
        {
            if (error_types_found.Intersect(match_on).Any())
            {
                what_to_do();
            }
        }

    }

    public static class FindOrCreateAndReturnTimeAllocationResponseExtensions
    {
        public static void Match(this FindOrCreateAndReturnTimeAllocationResponse the_response,
                                    Action<FindOrCreateAndReturnTimeAllocationSuccessResponse> was_successful,
                                    Action<FindOrCreateAndReturnTimeAllocationErrorResponse> had_errors)
        {

            if (the_response.has_errors)
            {
                had_errors(the_response as FindOrCreateAndReturnTimeAllocationErrorResponse);
                return;
            }

            if (!the_response.has_errors)
            {
                was_successful(the_response as FindOrCreateAndReturnTimeAllocationSuccessResponse);
                return;
            }

        }


        public static IEnumerable<ResponseMessage> filter_and_map_responses_by(this FindOrCreateAndReturnTimeAllocationErrorResponse error_response,
                                                                                IIndex<string, IEnumerable<ResponseMessage>> criteria)
        {
            return error_response
                .messages
                .Select(msg => criteria.lookup(msg.field_name))
                .select_where_maybe_has_value()
                .SelectMany(c => c);
        }
    }

    public class SanitisedTimeAllocation : IDataOrigin
    {
        public string title { get; set; }
        public RgbColour colour { get; set; }
        public int duration_in_seconds { get; set; }
        public int start_time_in_seconds_from_midnight { get; set; }

        public bool originated_from_client { get; set; }

        public IEnumerable<SanitisedTimeAllocationBreak> sanitised_breaks { get; set; }
    }

    public class SanitisedTimeAllocationBreak : IDataOrigin
    {
        public int offset_from_start_time_in_seconds { get; set; }
        public int duration_in_seconds { get; set; }
        public bool is_paid { get; set; }

        public bool originated_from_client { get; set; }
    }

    public interface IDataOrigin
    {
        bool originated_from_client { get; set; }
    }
}
