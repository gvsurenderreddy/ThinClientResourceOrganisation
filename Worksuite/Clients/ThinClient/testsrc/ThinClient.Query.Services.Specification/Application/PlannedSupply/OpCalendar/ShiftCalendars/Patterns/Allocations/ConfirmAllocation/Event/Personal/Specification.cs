﻿using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.ThinClient.Query.Services.Infrastructure;

namespace WTS.WorkSuite.ThinClient.Query.Services.Application.PlannedSupply.OpCalendar.ShiftCalendars.Patterns.Allocations.ConfirmAllocation.Event.Personal
{
    public class EmployeePersonalDetailsUpdatedEventSpecification : ThinClientQuerySpecification
    {
        protected override void test_setup()
        {
            base.test_setup();
            fixture = DependencyResolver.resolve<EmployeePersonalDetailsUpdatedEventFixture>();
        }

        protected EmployeePersonalDetailsUpdatedEventFixture fixture;
    }
}
