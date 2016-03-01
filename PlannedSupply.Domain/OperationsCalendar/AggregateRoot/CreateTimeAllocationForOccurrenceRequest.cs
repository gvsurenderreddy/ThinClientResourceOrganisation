using System;
using System.Collections.Generic;
using System.Linq;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.AggregateRoot.FindOrCreate;

namespace WTS.WorkSuite.PlannedSupply.OperationsCalendar.AggregateRoot
{
    public class CreateTimeAllocationForOccurrenceRequest : IDataOrigin
    {
        public TimeAllocations.TimeAllocation time_allocation { get; set; }
        public DateTime start_date { get; set; }
        public ShiftCalendarPatterns.ShiftCalendarPattern shift_calendar_pattern { get; set; }
        public bool originated_from_client { get; set; }
    }

    public class CreateTimeAllocationForOccurrenceResponse : Response { }

    public class CreateTimeAllocationForOccurrenceSuccessResponse : CreateTimeAllocationForOccurrenceResponse
    {
        public TimeAllocations.TimeAllocation time_allocation { get; set; }
    }

    public enum CreateTimeAllocationErrorTypes
    {
        internal_shift,
        client_shift,
        internal_break,
        client_break
    }

    public class CreateTimeAllocationForOccurrenceErrorResponse : CreateTimeAllocationForOccurrenceResponse
    {
        public HashSet<CreateTimeAllocationErrorTypes> error_types_found { get; set; }

        public void Any(HashSet<CreateTimeAllocationErrorTypes> match_on, Action what_to_do)
        {
            if (error_types_found.Intersect(match_on).Any())
            {
                what_to_do();
            }
        }
    }

    public static class CreateTimeAllocationForOccurrenceResponseExtensions
    {
        public static void Match(this CreateTimeAllocationForOccurrenceResponse the_response,
                                    Action<CreateTimeAllocationForOccurrenceSuccessResponse> was_successful,
                                    Action<CreateTimeAllocationForOccurrenceErrorResponse> had_errors)
        {

            if (the_response.has_errors)
            {
                had_errors(the_response as CreateTimeAllocationForOccurrenceErrorResponse);
                return;
            }

            if (!the_response.has_errors)
            {
                was_successful(the_response as CreateTimeAllocationForOccurrenceSuccessResponse);
                return;
            }

        }

        public static IEnumerable<ResponseMessage> filter_and_map_responses_by(this CreateTimeAllocationForOccurrenceErrorResponse error_response,
                                                                                IIndex<string, IEnumerable<ResponseMessage>> criteria)
        {
            return error_response
                .messages
                .Select(msg => criteria.lookup(msg.field_name))
                .select_where_maybe_has_value()
                .SelectMany(c => c);
        }
    }

    public class CreateTimeAllocationForOccurrenceValidationErrors
    {
        public const string NEW_SHIFT_CLASHE_WITH_PEER = "NEW_SHIFT_CLASHE_WITH_PEER";
    }
}