using WorkSuite.Library.Persistence;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.PlannedSupply.OperationsCalendars;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.PlannedSupply.OperationsCalendars;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.PlannedSupply.OperationsCalendars.ShiftCalendars;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.PlannedSupply.OperationsCalendars.ShiftCalendars.ShiftCalendarPatterns;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.PlannedSupply.OperationsCalendars.ShiftCalendars.ShiftCalendarPatterns.ResourceAllocations;
using WTS.WorkSuite.PlannedSupply.ShiftCalendarPatterns;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.ShiftCalendarPatterns.Features.Queries.GetDetailsOfAllShiftCalendarPatterns
{
    public class GetDetailsOfAllShiftCalendarPatternsFixture
    {
        public ShiftCalendarPatternBuilder add_shift_calendar_pattern()
        {
            ShiftCalendarPatternBuilder shift_calendar_pattern_builder = new ShiftCalendarPatternBuilder(new ShiftCalendarPattern());
            ShiftCalendarPattern shift_calendar_pattern = shift_calendar_pattern_builder.entity;

            var resource_allocation_builder = new ResourceAllocationBuilder();
            var resource_allocation = resource_allocation_builder.entity;

            shift_calendar_pattern.ResourceAllocations
                .Add(resource_allocation)
                ;

            _shift_calendar
                .ShiftCalendarPatterns
                .Add(shift_calendar_pattern)
                ;

            _shift_calendar_pattern_repository.add(shift_calendar_pattern);

            return shift_calendar_pattern_builder;
        }

        public GetDetailsOfAllShiftCalendarPatternsFixture()
        {
            _shift_calendar_helper = DependencyResolver.resolve<ShiftCalendarHelper>();
            _shift_calendar = _shift_calendar_helper
                                    .add()
                                    .entity
                                    ;

            _operational_calendar_helper = DependencyResolver.resolve<OperationsCalendarHelper>();
            _operational_calendar = _operational_calendar_helper
                                        .add()
                                        .add_shift_calendar(_shift_calendar)
                                        .entity
                                        ;

            _shift_calendar_pattern_repository = DependencyResolver.resolve<IEntityRepository<ShiftCalendarPattern>>();
        }

        protected OperationsCalendarHelper _operational_calendar_helper;
        protected ShiftCalendarHelper _shift_calendar_helper;

        public OperationalCalendar _operational_calendar;
        public PlannedSupply.ShiftCalendars.ShiftCalendar _shift_calendar;

        protected IEntityRepository<ShiftCalendarPattern> _shift_calendar_pattern_repository;
    }
}