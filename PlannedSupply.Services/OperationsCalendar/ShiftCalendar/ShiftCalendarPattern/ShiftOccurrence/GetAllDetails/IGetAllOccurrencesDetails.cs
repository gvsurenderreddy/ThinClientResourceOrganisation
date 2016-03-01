using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence.GetAllDetails
{
    public interface IGetAllOccurrencesDetails : IQuery<ShiftOccurrenceIdentity, Response<AllOccurrencesDetails>> { }
}