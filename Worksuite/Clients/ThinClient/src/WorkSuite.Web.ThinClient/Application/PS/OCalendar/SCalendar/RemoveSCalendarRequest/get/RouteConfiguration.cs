﻿using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;

namespace WTS.WorkSuite.Web.ThinClient.Application.Operations.OperationalCalendars.PlannedSupply.Presentation.ShiftCalendars.Presentation.Remove.Editor
{
    public class RouteConfiguration
                        : ARouteConfiguration<RemoveShiftCalendarPresenter>
    {
        public override string id
        {
            get { return Resources.id; }
        }

        public override string url
        {
            get { return "operations-calendar/{operations_calendar_id}/shift-calendar/{shift_calendar_id}/remove-shift-calendar-editor"; }
        }

        public override string action
        {
            get { return "Editor"; }
        }
    }
}