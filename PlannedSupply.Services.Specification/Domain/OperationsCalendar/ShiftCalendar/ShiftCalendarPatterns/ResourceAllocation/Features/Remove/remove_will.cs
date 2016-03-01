using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.SpecificationTemplates.Base;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.ShiftCalendarPatterns.ResourceAllocation.Features.Remove
{
    [TestClass]
    public class Remove_will : PlannedSupplySpecification
    {
        [TestMethod]
        public void will_remove_resource_allocation()
        {
            var removed_resource = fixture.add_resource();

            fixture._query.execute(removed_resource);

            fixture.planning_employees.Count(e => e.employee_id == removed_resource.resource_allocation_id)
                    .Should()
                    .Be(0);
        }

        [TestMethod]
        public void will_throw_exception_if_resource_allocation_already_removed()
        {
            var removed_resource = fixture.add_resource();

            //This removes the resource.
            fixture._query.execute(removed_resource);

            //We are again trying to remove the resource.
            var return_command = fixture._query.execute(removed_resource);

            return_command.has_errors.Should().BeTrue();

        }

        private PlannedSupplyRemovedEventFixture fixture;

        protected override void test_setup()
        {
            base.test_setup();

            fixture = DependencyResolver.resolve<PlannedSupplyRemovedEventFixture>();
        }
    }
}
