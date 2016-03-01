using System.Linq;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern;
using WTS.WorkSuite.PlannedSupply.OperationsCalendars;

namespace WTS.WorkSuite.PlannedSupply.OperationsCalendar.AggregateRoot
{
    public class GetShiftCalendarPattern
    {
        public ShiftCalendarPatterns.ShiftCalendarPattern execute(ShiftCalendarPatternIdentity the_shift)
        {
            var operational_calendar = operational_calander_repository.Entities.Single(oc => oc.id == the_shift.operations_calendar_id);

            var shift_calendar = operational_calendar.ShiftCalendars.Single(sc => sc.id == the_shift.shift_calendar_id);

            var shift_calendar_pattern = shift_calendar.ShiftCalendarPatterns.Single(sc => sc.id == the_shift.shift_calendar_pattern_id);

            return shift_calendar_pattern;
        }

        public GetShiftCalendarPattern(IEntityRepository<OperationalCalendar> the_operational_calander_repository)
        {
            operational_calander_repository = Guard.IsNotNull(the_operational_calander_repository, "the_operational_calander_repository");            
        }

        private readonly IEntityRepository<OperationalCalendar> operational_calander_repository;
    }
}