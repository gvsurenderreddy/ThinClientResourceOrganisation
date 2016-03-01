using System;
using System.Collections.Generic;
using System.Linq;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence.ShiftBreaks.ApplyFromTemplate;

namespace WTS.WorkSuite.Web.ThinClient.Application.Operations.OperationalCalendars.PlannedSupply.ShiftCalendars.Patterns.ShiftOccurrences.ShiftBreaksForAll.Types
{

    //This class demonstrates the single/multiple occurrence pattern
    //We are increasingly needing specialised types just for presentation,
    //since we want to keep the service layer as pure as possible,
    //we have decided to keep specialised versions of classes in the application
    public class ApplyShiftBreaksFromBreakTemplateForAllOccurrencesRequest : ApplyShiftBreaksFromBreakTemplateRequest
    {

    }


    public static class ApplyShiftBreaksFromBreakTemplateRequestExtensions
    {
        public static ApplyShiftBreaksFromBreakTemplateForAllOccurrencesRequest ToApplyShiftBreaksFromBreakTemplateForAllOccurrencesRequest(
                                                                                                this ApplyShiftBreaksFromBreakTemplateRequest source)
        {
            var mapper = new ApplyShiftBreaksFromBreakTemplateRequestForAllOccurrencesMapper();
            return mapper.Map(source);
        }
    }

    public class ApplyShiftBreaksFromBreakTemplateRequestForAllOccurrencesMapper
    {
        public Func<ApplyShiftBreaksFromBreakTemplateRequest, ApplyShiftBreaksFromBreakTemplateForAllOccurrencesRequest> Map
        {
            get
            {
                return details => new ApplyShiftBreaksFromBreakTemplateForAllOccurrencesRequest()
                {
                    operations_calendar_id = details.operations_calendar_id,
                    shift_calendar_id = details.shift_calendar_id,
                    shift_calendar_pattern_id = details.shift_calendar_pattern_id,
                    shift_occurrence_id = details.shift_occurrence_id,
                    break_template_id = details.break_template_id
                };
            }
        }
    }
}