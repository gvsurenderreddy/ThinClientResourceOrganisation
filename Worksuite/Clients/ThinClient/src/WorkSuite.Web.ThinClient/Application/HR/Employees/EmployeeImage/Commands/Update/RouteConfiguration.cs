﻿using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.RouteConfiguration;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.Employees.EmployeeImage.Commands.Update
{
    public class RouteConfiguration : ARouteConfiguration<UpdateEmployeeImageController>
    {
        public override string id
        {
            get { return Resources.id; }
        }

        public override string url
        {
            get { return "employee/{employee_id}/update-image-details"; }
        }

        public override string action
        {
            get { return "SubmitRequest"; }
        }
    }
}