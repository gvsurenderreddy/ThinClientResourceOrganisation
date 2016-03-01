using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.Edit;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.Edit.GetUpdateRequest;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.New;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.New.GetCreateRequest;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.PlannedSupply.OperationsCalendars;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.PlannedSupply.OperationsCalendars.ShiftCalendars;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.PlannedSupply.OperationsCalendars.ShiftCalendars.ShiftCalendarPatterns;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.SpecificationTemplates.Base;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.ShiftCalendarPatterns.Fields.NumberOfResources
{
    [TestClass]
    public class A_default_number_of_resources_is_not_supplied_to_force_user_entry
                        : PlannedSupplySpecification
    {
        [TestMethod]
        public void number_of_resources_defaults_to_empty_on_create()
        {
            ShiftCalendars.ShiftCalendar shift_calendar = _shift_calendar_helper
                                                                            .add()
                                                                            .calendar_name("A shift calendar")
                                                                            .entity
                                                                            ;

            OperationsCalendars.OperationalCalendar operational_calendar = _operational_calendar_helper
                                                                                                .add()
                                                                                                .calendar_name("An operational calendar")
                                                                                                .add_shift_calendar(shift_calendar)
                                                                                                .entity
                                                                                                ;
            var command = DependencyResolver.resolve<IGetNewShiftCalendarPatternRequest>();
            NewShiftCalendarPatternRequest request = command
                                                        .execute(new ShiftCalendarPatternIdentity
                                                        {
                                                            operations_calendar_id = operational_calendar.id,
                                                            shift_calendar_id = shift_calendar.id
                                                        }
                                                                )
                                                        ;

            request.number_of_resources.Should().BeEmpty();
        }

        [TestMethod]
        public void number_of_resources_defaults_to_zero_on_update()
        {
            PlannedSupply.ShiftCalendarPatterns.ShiftCalendarPattern shift_calendar_pattern = _shift_calendar_pattern_helper
                                                                                                    .add()
                                                                                                    .entity;

            ShiftCalendars.ShiftCalendar shift_calendar = _shift_calendar_helper
                                                                            .add()
                                                                            .calendar_name("A shift calendar")
                                                                            .add_shift_calendar_pattern(shift_calendar_pattern)
                                                                            .entity
                                                                            ;

            OperationsCalendars.OperationalCalendar operational_calendar = _operational_calendar_helper
                                                                                                .add()
                                                                                                .calendar_name("An operational calendar")
                                                                                                .add_shift_calendar(shift_calendar)
                                                                                                .entity
                                                                                                ;

            var command = DependencyResolver.resolve<IGetUpdateShiftCalendarPatternRequest>();
            UpdateShiftCalendarPatternRequest request = command
                                                            .execute(new ShiftCalendarPatternIdentity
                                                            {
                                                                operations_calendar_id = operational_calendar.id,
                                                                shift_calendar_id = shift_calendar.id,
                                                                shift_calendar_pattern_id = shift_calendar_pattern.id,
                                                            }
                                                                    )
                                                            .result
                                                            ;

            request.number_of_resources.Should().Be("0");
        }

        protected override void test_setup()
        {
            base.test_setup();

            _operational_calendar_helper = DependencyResolver.resolve<OperationsCalendarHelper>();
            _shift_calendar_helper = DependencyResolver.resolve<ShiftCalendarHelper>();
            _shift_calendar_pattern_helper = DependencyResolver.resolve<ShiftCalendarPatternHelper>();
        }

        private OperationsCalendarHelper _operational_calendar_helper;
        private ShiftCalendarHelper _shift_calendar_helper;
        private ShiftCalendarPatternHelper _shift_calendar_pattern_helper;
    }
}