using System.Linq;
using WorkSuite.Library.Persistence;
using WorkSuite.Library.Service.Specification.Helpers.Request;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.GetDetailsById;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.PlannedSupply.OperationsCalendars;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.PlannedSupply.OperationsCalendars.ShiftCalendars;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.PlannedSupply.OperationsCalendars.ShiftCalendars.ShiftCalendarPatterns;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.PlannedSupply.OperationsCalendars.ShiftCalendars.ShiftCalendarPatterns.ResourceAllocations;
using WTS.WorkSuite.PlannedSupply.ShiftCalendarPatterns;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.ShiftCalendarPatterns.Features.GetDetailsById
{
    public class GetShiftCalendarPatternFixture
    {
        public void execute_query()
        {
            response = query.execute(request);
        }

        public ShiftCalendarPatternBuilder get_pattern_builder()
        {
            Guard.IsNotNull(pattern_builder, "pattern_builder");
            return pattern_builder;
        }

        public GetShiftCalendarPatternFixture ( IGetShiftCalendarPatternDetailsById the_query 
                                              , OperationsCalendarHelper the_operations_calendar_helper
                                              , ShiftCalendarHelper the_shift_calendar_helper
                                                )
        {

            query = Guard.IsNotNull(the_query, "the_query");

            pattern_builder = new ShiftCalendarPatternBuilder();

            var shift_calendar = Guard.IsNotNull(the_shift_calendar_helper, "the_shift_calendar_pattern_helper")
                .add()
                .add_shift_calendar_pattern(pattern_builder.entity)
                .entity
                ;

            var operations_calendar = Guard.IsNotNull(the_operations_calendar_helper, "the_operations_calendar_helper")
                .add()
                .add_shift_calendar(shift_calendar)
                .entity;

            request = new ShiftCalendarPatternIdentity
            {
                operations_calendar_id = operations_calendar.id,
                shift_calendar_id = shift_calendar.id,
                shift_calendar_pattern_id = pattern_builder.entity.id
            };
        }

        private readonly IGetShiftCalendarPatternDetailsById query;
        private readonly ShiftCalendarPatternBuilder pattern_builder;

        public ShiftCalendarPatternIdentity request { get; set; }
        public GetShiftCalendarPatternDetailsByIdResponse response { get; set; }
    }
}