using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.Edit;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.Edit.GetUpdateRequest;
using WTS.WorkSuite.PlannedSupply.OperationsCalendars;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.PlannedSupply.OperationsCalendars;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.PlannedSupply.OperationsCalendars.ShiftCalendars;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.PlannedSupply.OperationsCalendars.ShiftCalendars.ShiftCalendarPatterns;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.SpecificationTemplates.Base;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.ShiftCalendarPatterns.Features.Edit
{
    [TestClass]
    public class Update_shift_calendar_pattern_should
                        : PlannedSupplySpecification
    {
        [TestMethod]
        public void update_the_shift_calendar_pattern()
        {
            fixture.execute_command();

            fixture
                .update_response
                .Match(

                    has_value:
                        response => response.has_errors.Should().Be(false),

                    nothing:
                        () => Assert.Fail()

                );
        }

        protected override void test_setup()
        {
            base.test_setup();

            fixture = DependencyResolver.resolve<UpdateShiftCalendarPatternFixture>();
        }

        private UpdateShiftCalendarPatternFixture fixture;
    }

    [TestClass]
    public class Get_update_shift_calendar_request_should
                        : PlannedSupplySpecification
    {
        [TestMethod]
        public void return_a_valid_update_shift_calendar_pattern_request()
        {
            PlannedSupply.ShiftCalendarPatterns.ShiftCalendarPattern shift_calendar_pattern = _shift_calendar_pattern_helper
                                                                                                    .add()
                                                                                                    .priority(1)
                                                                                                    .entity
                                                                                                    ;

            ShiftCalendars.ShiftCalendar shift_calendar = _shift_calendar_helper
                                                                .add()
                                                                .add_shift_calendar_pattern(shift_calendar_pattern)
                                                                .entity
                                                                ;

            OperationalCalendar operational_calendar = _operational_calendar_helper
                                                            .add()
                                                            .add_shift_calendar(shift_calendar)
                                                            .entity
                                                            ;

            Response<UpdateShiftCalendarPatternRequest> response = _get_update_shift_calendar_pattern_request
                                                                        .execute(new ShiftCalendarPatternIdentity
                                                                        {
                                                                            operations_calendar_id = operational_calendar.id,
                                                                            shift_calendar_id = shift_calendar.id,
                                                                            shift_calendar_pattern_id = shift_calendar_pattern.id
                                                                        }
                                                                                )
                                                                        ;
            UpdateShiftCalendarPatternRequest update_shift_calendar_pattern_request = response.result;

            update_shift_calendar_pattern_request.pattern_name.Should().Be(shift_calendar_pattern.name);
            update_shift_calendar_pattern_request.shift_calendar_pattern_id.Should().Be(shift_calendar_pattern.id);
            update_shift_calendar_pattern_request.shift_calendar_id.Should().Be(shift_calendar.id);
            update_shift_calendar_pattern_request.operations_calendar_id.Should().Be(operational_calendar.id);
        }

        protected override void test_setup()
        {
            base.test_setup();

            _shift_calendar_pattern_helper = DependencyResolver.resolve<ShiftCalendarPatternHelper>();
            _shift_calendar_helper = DependencyResolver.resolve<ShiftCalendarHelper>();
            _operational_calendar_helper = DependencyResolver.resolve<OperationsCalendarHelper>();
            _get_update_shift_calendar_pattern_request = DependencyResolver.resolve<IGetUpdateShiftCalendarPatternRequest>();
        }

        private IGetUpdateShiftCalendarPatternRequest _get_update_shift_calendar_pattern_request;
        private ShiftCalendarPatternHelper _shift_calendar_pattern_helper;
        private ShiftCalendarHelper _shift_calendar_helper;
        private OperationsCalendarHelper _operational_calendar_helper;
    }
}