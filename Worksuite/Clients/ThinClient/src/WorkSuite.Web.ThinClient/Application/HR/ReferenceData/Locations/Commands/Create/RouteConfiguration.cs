﻿using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.ReferenceData.Locations.Commands.Create
{
    public class RouteConfiguration
                    : ARouteConfiguration<CreateLocationController>
    {
        public override string id
        {
            get { return Resources.id; }
        }

        public override string url
        {
            get { return "locations/create"; }
        }

        public override string action
        {
            get { return "SubmitRequest"; }
        }
    }
}