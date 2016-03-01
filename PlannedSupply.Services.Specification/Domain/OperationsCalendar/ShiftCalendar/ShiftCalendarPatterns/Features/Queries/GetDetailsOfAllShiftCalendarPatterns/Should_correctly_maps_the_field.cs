using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.Queries.GetDetailsOfAllShiftCalendarPatterns;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.SpecificationTemplates.Base;
using WTS.WorkSuite.PlannedSupply.ShiftCalendarPatterns;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.ShiftCalendarPatterns.Features.Queries.GetDetailsOfAllShiftCalendarPatterns
{
    [TestClass]
    public class Should_correctly_maps_the_field
                        : PlannedSupplySpecification
    {
        [TestMethod]
        public void pattern_name()
        {
            ShiftCalendarPattern a_shift_calendar_pattern = _fixture
                                            .add_shift_calendar_pattern()
                                            .pattern_name("A shift calendar pattern name")
                                            .entity
                                            ;

            var shift_calendar_pattern = _get_details_of_all_shift_calendar_patterns
                                                    .execute(new ShiftCalendarIdentity { shift_calendar_id = _fixture._shift_calendar.id, operations_calendar_id = _fixture._operational_calendar.id })
                                                    .result
                                                    .First()
                                                    ;
            shift_calendar_pattern.shift_calendar_pattern_name.Should().Be(a_shift_calendar_pattern.name);
        }

        [TestMethod]
        public void desired_number_of_resources()
        {
            ShiftCalendarPattern a_shift_calendar_pattern = _fixture
                                            .add_shift_calendar_pattern()
                                            .pattern_name("A shift calendar pattern name")
                                            .entity
                                            ;

            var shift_calendar_pattern = _get_details_of_all_shift_calendar_patterns
                                                    .execute(new ShiftCalendarIdentity { shift_calendar_id = _fixture._shift_calendar.id, operations_calendar_id = _fixture._operational_calendar.id })
                                                    .result
                                                    .First()
                                                    ;
            shift_calendar_pattern.number_of_resources.Should().Be(a_shift_calendar_pattern.number_of_resources);
        }

        [TestMethod]
        public void actual_number_of_allocated_resources()
        {
            ShiftCalendarPattern a_shift_calendar_pattern = _fixture
                                           .add_shift_calendar_pattern()
                                           .pattern_name("A shift calendar pattern name")
                                           .entity
                                           ;

            var shift_calendar_pattern = _get_details_of_all_shift_calendar_patterns
                                                    .execute(new ShiftCalendarIdentity { shift_calendar_id = _fixture._shift_calendar.id, operations_calendar_id = _fixture._operational_calendar.id })
                                                    .result
                                                    .First()
                                                    ;

            Assert.AreEqual(shift_calendar_pattern.resource_allocation_summary, a_shift_calendar_pattern.ResourceAllocations.Count());
            Assert.AreEqual(shift_calendar_pattern.resource_allocation_summary , 1);
        }

        protected override void test_setup()
        {
            base.test_setup();

            _get_details_of_all_shift_calendar_patterns =
                DependencyResolver.resolve<IGetDetailsOfAllShiftCalendarPatterns>();

            _fixture = new GetDetailsOfAllShiftCalendarPatternsFixture();
        }

        private GetDetailsOfAllShiftCalendarPatternsFixture _fixture;
        private IGetDetailsOfAllShiftCalendarPatterns _get_details_of_all_shift_calendar_patterns;
    }
}