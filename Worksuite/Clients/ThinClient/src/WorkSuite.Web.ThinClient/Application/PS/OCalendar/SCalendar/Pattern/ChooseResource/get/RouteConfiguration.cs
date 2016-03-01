﻿using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;
using WTS.WorkSuite.Web.ThinClient.Application.Operations.OperationalCalendars.PlannedSupply.ShiftCalendars.Patterns.Allocations.AllResources.get;

namespace WTS.WorkSuite.Web.ThinClient.Application.Ops.OpCalendars.PlannedSupply.ShiftCalendars.Patterns.Allocations.allResources.get
{
    public class RouteConfiguration : APageRouteConfiguration<AllResourcesPagePresenter>
    {
        public override string id
        {
            get { return Resources.page_id; }
        }

        public override string url
        {
            get { return "operations-calendar/{operations_calendar_id}/shift-calendar/{shift_calendar_id}/shift-calendar-pattern/{shift_calendar_pattern_id}/resources"; }
        }
    }
}