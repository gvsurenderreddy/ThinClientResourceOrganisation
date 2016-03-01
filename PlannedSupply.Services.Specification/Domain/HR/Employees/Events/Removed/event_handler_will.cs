using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.SpecificationTemplates.Base;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.HR.Employees.Events.Removed
{
    [TestClass]
    public class event_handler_will : PlannedSupplySpecification
    {
        [TestMethod]
        public void remove_any_resource_allocations_for_the_employee()
        {
            var removed_event = fixture.simulate_event();

            fixture.event_handler.handle(removed_event);

            fixture.operational_calendars
                    .SelectMany(opc => opc.ShiftCalendars)
                    .SelectMany(sp => sp.ShiftCalendarPatterns)
                    .SelectMany(scp => scp.ResourceAllocations)
                    .Count(ra => ra.employee.employee_id == removed_event.employee_id)
                    .Should()
                    .Be(0);

        }

        [TestMethod]
        public void remove_the_planned_supply_employee()
        {
            var removed_event = fixture.simulate_event();

            fixture.event_handler.handle(removed_event);

            fixture.planning_employees
                    .Count(e => e.employee_id == removed_event.employee_id)
                    .Should()
                    .Be(0);

        }


        private EmployeeRemovedEventFixture fixture;

        protected override void test_setup()
        {
            base.test_setup();

            fixture = DependencyResolver.resolve<EmployeeRemovedEventFixture>();
        }
    }
}
