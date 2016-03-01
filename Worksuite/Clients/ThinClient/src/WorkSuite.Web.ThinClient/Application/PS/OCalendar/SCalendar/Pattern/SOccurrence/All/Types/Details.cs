
using System;
using System.Linq;
using System.Collections.Generic;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence.ShiftBreaks;

namespace WTS.WorkSuite.Web.ThinClient.Application.Operations.OperationalCalendars.PlannedSupply.ShiftCalendars.Patterns.ShiftOccurrences.ShiftBreaksForAll.Types
{
    //This class demonstrates the single/multiple occurrence pattern
    //We are increasingly needing specialised types just for presentation,
    //since we want to keep the service layer as pure as possible,
    //we have decided to keep specialised versions of classes in the application
    public class ShiftBreakDetailsForAllOccurrences : ShiftBreakDetails
    {
        
    }


    public static class ShiftBreakDetailsExtensions
    {
        public static IEnumerable<ShiftBreakDetailsForAllOccurrences> ToShiftBreakDetailsForAllOccurrences(
                                                                                            this IEnumerable<ShiftBreakDetails> source)
        {
            var mapper = new ShiftBreakDetailsForAllOccurrencesMapper();
            return source.Select(mapper.Map);
        }
    }

    public class ShiftBreakDetailsForAllOccurrencesMapper
    {
        public Func<ShiftBreakDetails, ShiftBreakDetailsForAllOccurrences> Map
        {
            get
            {
                return details => new ShiftBreakDetailsForAllOccurrences()
                {
                    operations_calendar_id = details.operations_calendar_id,
                    shift_calendar_id = details.shift_calendar_id,
                    shift_calendar_pattern_id = details.shift_calendar_pattern_id,
                    shift_occurrence_id = details.shift_occurrence_id,
                    duration = details.duration,
                    is_paid = details.is_paid,
                    offset_from_start_time = details.offset_from_start_time,
                    position = details.position,
                    shift_break_id = details.shift_break_id
                };
            }
        }
    }
}