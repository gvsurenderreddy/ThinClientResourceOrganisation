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
    public class Should_return
                        : PlannedSupplySpecification
    {
        [TestMethod]
        public void an_empty_set_when_there_are_no_shift_calendar_patterns()
        {
            _get_details_of_all_shift_calendar_patterns
                                .execute(new ShiftCalendarIdentity { shift_calendar_id = _fixture._shift_calendar.id, operations_calendar_id = _fixture._operational_calendar.id })
                                .result
                                .Should()
                                .BeEmpty()
                                ;
        }

        [TestMethod]
        public void all_shift_calendar_patterns()
        {
            _fixture
                .add_shift_calendar_pattern()
                .pattern_name("Shift calendar pattern A")
                .priority(2)
                ;

            _fixture
                .add_shift_calendar_pattern()
                .pattern_name("Shift calendar pattern B")
                .priority(1)
                ;

            _get_details_of_all_shift_calendar_patterns
                                .execute(new ShiftCalendarIdentity { shift_calendar_id = _fixture._shift_calendar.id, operations_calendar_id = _fixture._operational_calendar.id })
                                .result
                                .Count()
                                .Should()
                                .Be(2)
                                ;
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