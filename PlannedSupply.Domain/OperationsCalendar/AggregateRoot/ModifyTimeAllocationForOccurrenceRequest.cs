using System;
using System.Collections.Generic;
using System.Linq;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.AggregateRoot.FindOrCreate;

namespace WTS.WorkSuite.PlannedSupply.OperationsCalendar.AggregateRoot
{
    public class ModifyTimeAllocationForOccurrenceRequest : IDataOrigin
    {
        public TimeAllocationOccurrences.TimeAllocationOccurrence time_allocation_occurrence { get; set; }
        public TimeAllocations.TimeAllocation new_time_allocation { get; set; }
        public int operation_calendar_id { get; set; }
        public bool originated_from_client { get; set; }
    }

    public class ModifyTimeAllocationForOccurrenceResponse : Response { }

    public class ModifyTimeAllocationForOccurrenceSuccessResponse : ModifyTimeAllocationForOccurrenceResponse
    {
        public TimeAllocations.TimeAllocation time_allocation { get; set; }
        public TimeAllocationOccurrences.TimeAllocationOccurrence time_allocation_occurrence { get; set; }
    }

    public enum modify_time_allocation_error_types
    {
        internal_shift,
        client_shift,
        internal_break,
        client_break
    }

    public class ModifyTimeAllocationForOccurrenceErrorResponse : ModifyTimeAllocationForOccurrenceResponse
    {
        public HashSet<modify_time_allocation_error_types> error_types_found { get; set; }

        public void Any(HashSet<modify_time_allocation_error_types> match_on, Action what_to_do)
        {
            if (error_types_found.Intersect(match_on).Any())
            {
                what_to_do();
            }
        }
    }

    public static class ModifyTimeAllocationForOccurrenceResponseExtensions
    {
        public static void Match(this ModifyTimeAllocationForOccurrenceResponse the_response,
                                    Action<ModifyTimeAllocationForOccurrenceSuccessResponse> was_successful,
                                    Action<ModifyTimeAllocationForOccurrenceErrorResponse> had_errors)
        {

            if (the_response.has_errors)
            {
                had_errors(the_response as ModifyTimeAllocationForOccurrenceErrorResponse);
                return;
            }

            if (!the_response.has_errors)
            {
                was_successful(the_response as ModifyTimeAllocationForOccurrenceSuccessResponse);
                return;
            }

        }

        public static IEnumerable<ResponseMessage> filter_and_map_responses_by(this ModifyTimeAllocationForOccurrenceErrorResponse error_response,
                                                                                IIndex<string, IEnumerable<ResponseMessage>> criteria)
        {
            return error_response
                .messages
                .Select(msg => criteria.lookup(msg.field_name))
                .select_where_maybe_has_value()
                .SelectMany(c => c);
        }
    }

    public class ClashingShiftValidationErrors
    {
        public const string SHIFT_CLASHE_WITH_PEER = "SHIFT_CLASHE_WITH_PEER";
    }
   
}