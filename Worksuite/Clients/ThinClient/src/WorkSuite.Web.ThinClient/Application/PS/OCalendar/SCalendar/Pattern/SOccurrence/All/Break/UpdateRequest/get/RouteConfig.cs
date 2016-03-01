﻿using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;

namespace WTS.WorkSuite.Web.ThinClient.Application.Operations.OperationalCalendars.PlannedSupply.ShiftCalendars.Patterns.ShiftOccurrences.ShiftBreaksForAll.Presentation.Edit
{
    public class RouteConfiguration : ARouteConfiguration<EditShiftBreakForAllOccurrencesEditorPresenter>
    {
        public override string id
        {
            get { return Resources.id; }
        }

        public override string url
        {
            get { return "operations-calendar/{operations_calendar_id}/shift-calendar/{shift_calendar_id}/shift-calendar-pattern/{shift_calendar_pattern_id}/shift-occurrence/{shift_occurrence_id}/shift-break/{shift_break_id}/edit-shift-break-for-all-occurrences-editor"; }
        }

        public override string action
        {
            get { return "Editor"; }
        }
    }
}