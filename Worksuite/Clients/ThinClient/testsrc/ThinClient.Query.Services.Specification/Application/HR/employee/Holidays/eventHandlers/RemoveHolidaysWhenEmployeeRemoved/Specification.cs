﻿using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.ThinClient.Query.Services.Infrastructure;

namespace WTS.WorkSuite.ThinClient.Query.Services.Application.HR.employee.Holidays.eventHandlers.RemoveHolidaysWhenEmployeeRemoved
{
    public class RemoveEmployeeHolidaysWhenEmployeeRemovedSpecification : ThinClientQuerySpecification
    {
        protected override void test_setup()
        {
            base.test_setup();

            fixture = DependencyResolver.resolve<RemoveEmployeeHolidaysWhenEmployeeRemovedFixture>();
        }

        protected RemoveEmployeeHolidaysWhenEmployeeRemovedFixture fixture;
    }
}
