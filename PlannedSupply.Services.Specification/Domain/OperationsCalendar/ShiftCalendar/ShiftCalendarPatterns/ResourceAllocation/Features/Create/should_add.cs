using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.SpecificationTemplates.Base;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.ShiftCalendarPatterns.ResourceAllocation.Features.Create
{
    [TestClass]
    public class should_add : PlannedSupplySpecification
    {
        [TestMethod]
        public void add_resource_to_pattern()
        {
            var request = fixture.create_request();

            //Before
            Assert.AreEqual(0, fixture.shift_calendar_pattern_a.ResourceAllocations.Count);


            fixture.command.execute(request);

            //After
            Assert.AreEqual(1, fixture.shift_calendar_pattern_a.ResourceAllocations.Count);
        }

        [TestMethod]
        public void add_an_unallocated_resource()
        {
            var request = fixture.create_request();

            //Before
            Assert.AreEqual(0, fixture.shift_calendar_pattern_a.ResourceAllocations.Count);


            fixture.command.execute(request);

            //After
            Assert.AreEqual(1, fixture.shift_calendar_pattern_a.ResourceAllocations.Count);
        }

        [TestMethod]
        public void add_an_resource_which_is_allocated_to_another_pattern_in_same_calendar()
        {
            var request = fixture.create_request_with_employee_in_different_pattern();

            //Before
            Assert.AreEqual(1, fixture.shift_calendar_pattern_a.ResourceAllocations.Count);
            Assert.AreEqual(1, fixture.shift_calendar_pattern_a.ResourceAllocations.Count);

            fixture.command.execute(request);

            //Added to A pattern

            Assert.AreEqual(2, fixture.shift_calendar_pattern_a.ResourceAllocations.Count);

            //Removed from B pattern

            Assert.AreEqual(0, fixture.shift_calendar_pattern_b.ResourceAllocations.Count);
        }

        [TestMethod]
        public void add_an_resource_which_is_allocated_to_pattern_in_different_calendar()
        {
            var return_allocation_request = fixture.add_resource_to_different_calendar();

            //Before
            Assert.AreEqual(0, fixture.shift_calendar_pattern_a.ResourceAllocations.Count);

            fixture.command.execute(return_allocation_request);

            //After
            Assert.AreEqual(1, fixture.shift_calendar_pattern_a.ResourceAllocations.Count);
        }

        [TestMethod]
        public void add_an_resource_which_is_allocated_to_same_pattern_in_same_calendar()
        {
            Assert.AreEqual(0, fixture.shift_calendar_pattern_a.ResourceAllocations.Count);

            fixture.allocate_employee_to_a_pattern();

            Assert.AreEqual(1, fixture.shift_calendar_pattern_a.ResourceAllocations.Count);

            var request = fixture.create_Allocate_Employee_To_Pattern_Request();

            fixture.command.execute(request);

            Assert.AreEqual(1, fixture.shift_calendar_pattern_a.ResourceAllocations.Count);
        }


        private AllocateResourceFixture fixture;

        protected override void test_setup()
        {
            base.test_setup();

            fixture = DependencyResolver.resolve<AllocateResourceFixture>();
        }
    }
}
