﻿using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;

namespace WTS.WorkSuite.Web.ThinClient.Application.Operations.OperationalCalendars.PlannedSupply.ShiftCalendars.Patterns.ShiftOccurrences.ShiftBreaksForSingle.Presentation.Remove
{
    public class RouteConfiguration : ARouteConfiguration<RemoveShiftBreakEditorPresenter>
    {
        public override string id
        {
            get { return Resources.id; }
        }

        public override string url
        {
            get { return "operations-calendar/{operations_calendar_id}/shift-calendar/{shift_calendar_id}/shift-calendar-pattern/{shift_calendar_pattern_id}/shift-occurrence/{shift_occurrence_id}/shift-break/{shift_break_id}/remove-shift-break-editor"; }
        }

        public override string action
        {
            get { return "Editor"; }
        }
    }
}