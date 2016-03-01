using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.ShiftCalendarPatterns.Features.GetDetailsById
{
    [TestClass]
    public class ShouldReturn : GetShiftCalendarPatternSpecification
    {
        [TestMethod]
        public void shift_calendar_pattern_identity()
        {
            fixture.execute_query();
            var response = fixture.response.result;

            Assert.AreEqual(fixture.request.operations_calendar_id, response.operations_calendar_id);
            Assert.AreEqual(fixture.request.shift_calendar_id , response.shift_calendar_id);
            Assert.AreEqual(fixture.request.shift_calendar_pattern_id, response.shift_calendar_pattern_id);
        }

        [TestMethod]
        public void pattern_name()
        {
            var pattern_name = "pattern A";

            fixture
                .get_pattern_builder()
                .pattern_name(pattern_name);

            fixture.execute_query();

            Assert.AreEqual(pattern_name, fixture.response.result.shift_calendar_pattern_name);
        }

        [TestMethod]
        public void number_of_resources()
        {
            var number_of_resources = 2;

            fixture
                .get_pattern_builder()
                .number_of_resources(number_of_resources);

            fixture.execute_query();

            Assert.AreEqual(number_of_resources, fixture.response.result.number_of_resources);
        }

        [TestMethod]
        public void one_allocated_resource()
        {
            fixture
                .get_pattern_builder()
                .add_resouce_allocation(new PlannedSupply.ResourceAllocations.ResourceAllocation{id = 1});

            fixture.execute_query();

            Assert.AreEqual(1, fixture.response.result.resource_allocation_summary);
        }

        [TestMethod]
        public void three_allocated_resource()
        {
            fixture
                .get_pattern_builder()
                .add_resouce_allocation(new PlannedSupply.ResourceAllocations.ResourceAllocation { id = 1 })
                .add_resouce_allocation(new PlannedSupply.ResourceAllocations.ResourceAllocation { id = 2 })
                .add_resouce_allocation(new PlannedSupply.ResourceAllocations.ResourceAllocation { id = 3 });

            fixture.execute_query();

            Assert.AreEqual(3, fixture.response.result.resource_allocation_summary);
        }

        [TestMethod]
        public void no_allocated_resources()
        {
            fixture.execute_query();

            Assert.AreEqual(0, fixture.response.result.resource_allocation_summary);
        }
    }
}