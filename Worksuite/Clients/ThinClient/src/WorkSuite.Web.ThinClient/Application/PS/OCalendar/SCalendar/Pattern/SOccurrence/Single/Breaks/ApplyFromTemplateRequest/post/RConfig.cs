﻿using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;

namespace WTS.WorkSuite.Web.ThinClient.Application.Operations.OperationalCalendars.PlannedSupply.ShiftCalendars.Patterns.ShiftOccurrences.ShiftBreaksForSingle.Commands.ApplyFromTemplate
{
    public class RouteConfiguration : ARouteConfiguration<ApplyShiftBreaksFromBreakTemplateController>
    {
        public override string id
        {
            get { return Resources.id; }
        }

        public override string url
        {
            get { return "operations-calendar/{operations_calendar_id}/shift-calendar/{shift_calendar_id}/shift-calendar-patterns/{shift_calendar_pattern_id}/shift-occurrence/{shift_occurrence_id}/apply-shift-breaks-from-template/submit-request"; }
        }

        public override string action
        {
            get { return "SubmitRequest"; }
        }
    }
}