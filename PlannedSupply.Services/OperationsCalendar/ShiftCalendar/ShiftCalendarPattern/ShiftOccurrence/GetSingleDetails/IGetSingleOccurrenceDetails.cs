using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence.GetSingleDetails
{
    public interface IGetSingleOccurrenceDetails : IQuery<ShiftOccurrenceIdentity, Response<SingleOccurrenceDetails>> { }
}