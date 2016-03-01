using System;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence.ShiftBreaks.New;

namespace WTS.WorkSuite.Web.ThinClient.Application.Operations.OperationalCalendars.PlannedSupply.ShiftCalendars.Patterns.ShiftOccurrences.ShiftBreaksForAll.Types
{

    //This class demonstrates the single/multiple occurrence pattern
    //We are increasingly needing specialised types just for presentation,
    //since we want to keep the service layer as pure as possible,
    //we have decided to keep specialised versions of classes in the application
    public class NewShiftBreakForAllOccurrencesRequest : NewShiftBreakRequest
    {

    }


    public static class NewShiftBreakRequestExtensions
    {
        public static NewShiftBreakForAllOccurrencesRequest ToNewShiftBreakForAllOccurrencesRequest(
                                                                                                this NewShiftBreakRequest source)
        {
            var mapper = new NewShiftBreakRequestForAllOccurrencesMapper();
            return mapper.Map(source);
        }
    }

    public class NewShiftBreakRequestForAllOccurrencesMapper
    {
        public Func<NewShiftBreakRequest, NewShiftBreakForAllOccurrencesRequest> Map
        {
            get
            {
                return details => new NewShiftBreakForAllOccurrencesRequest()
                {
                    operations_calendar_id = details.operations_calendar_id,
                    shift_calendar_id = details.shift_calendar_id,
                    shift_calendar_pattern_id = details.shift_calendar_pattern_id,
                    shift_occurrence_id = details.shift_occurrence_id,
                    duration = details.duration,
                    is_paid = details.is_paid,
                    off_set = details.off_set
                };
            }
        }
    }
}