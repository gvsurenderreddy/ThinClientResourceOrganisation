using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.TimeAllocationOccurrence;

namespace WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence.GetShiftDetailsByStartDate
{
    public interface IGetShiftOccurrenceByStartDate : IQuery<TimeBlockIdentity, Response<ShiftOccurrenceDetails>> { }
}